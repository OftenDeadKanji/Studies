using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Crypto.Agreement.Srp;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ZarzadzanieFlota
{
    public partial class ManagerCourseCreate : BaseForm
    {
        private DateTime _startDate;
        private DateTime _endDate;
        private bool _addVehicle;
        private bool _addDriver;

        // Indeksy z tej listy z kursami
        int indexDriver = 0, indexVehicle = 1, indexTransit = 2, indexDate = 3;
        // Indeksy w bazie danych w tabeli Transits
        int indexDBTFirstStop = 2, indexDBTStartTime = 6, indexDBTCapacity = 7;

        public ManagerCourseCreate()
        {
            InitializeComponent();
            _startDate = this.startDate.Value.Date;
            _endDate = this.endDate.Value.Date;
            _addVehicle = this.addVehicles.Checked;
            _addDriver = this.addDrivers.Checked;
        }

        private void ButtonReturn_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerCourses());
        }

        private void startDate_ValueChanged(object sender, EventArgs e)
        {
            _startDate = this.startDate.Value.Date;
        }

        private void endDate_ValueChanged(object sender, EventArgs e)
        {
            _endDate = this.endDate.Value.Date;
        }

        private void addVehicles_CheckedChanged(object sender, EventArgs e)
        {
            _addVehicle = this.addVehicles.Checked;
        }

        private void addDrivers_CheckedChanged(object sender, EventArgs e)
        {
            _addDriver = this.addDrivers.Checked;
        }

        private void buttonGen_Click(object sender, EventArgs e)
        {
            GenerateCourses();
            ChangeForm(this, new ManagerCourses());
        }

        private void GenerateCourses()
        {
            //nowe kursy
            var newCourses = CreateCoursesForTransits();

            //ewentualne pojazdy
            if (_addVehicle) AddVehiclesToCourses(ref newCourses);

            //ewentualni kierowcy
            if (_addDriver) AddDriversToCoureses(ref newCourses);

            //zapisanie do DB
            PushToDB(newCourses);
        }

        private HashSet<Tuple<int, int>> GetDaysList()
        {
            var dates = GetDaysBetween(_startDate, _endDate);
            HashSet<Tuple<int, int>> toReturn = new HashSet<Tuple<int, int>>();
            foreach (var date in dates)
            {
                int dayOfWeek = (int)date.Item1 - 1;
                if (dayOfWeek == -1)
                    dayOfWeek = 6;

                int dayType = 0;
                if (date.Item3 == 7 || date.Item3 == 8)
                {
                    dayType = 1;
                }

                toReturn.Add(Tuple.Create(dayOfWeek, dayType));
            }

            return toReturn;
        }

        //autor: ktoś na stacku
        public IEnumerable<Tuple<DayOfWeek, int, int>> GetDaysBetween(DateTime startDate, DateTime endDate)
        {
            DateTime iterator;
            DateTime limit;

            if (endDate > startDate)
            {
                iterator = new DateTime(startDate.Year, startDate.Month, startDate.Day);
                limit = endDate;
            }
            else
            {
                iterator = new DateTime(endDate.Year, endDate.Month, endDate.Day);
                limit = startDate;
            }

            var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
            while (iterator <= limit)
            {
                yield return Tuple.Create(
                    iterator.DayOfWeek,
                    iterator.Day,
                    iterator.Month);
                iterator = iterator.AddDays(1);
            }
        }

        private List<string[]> GetTransits()
        {
            var days = GetDaysList();
            List<string[]> transits = new List<string[]>();

            foreach (var day in days)
            {
                transits.AddRange(DBCommunicator.SelectNoCoursesTransitsByWeekdayAndDaytype(day.Item1, day.Item2, _startDate, _endDate));
            }

            return transits;
        }

        private List<object[]> CreateCoursesForTransits()
        {
            List<object[]> newCourses = new List<object[]>();
            var courseDate = _startDate.Date;

            var transits = GetTransits();
            foreach (var transit in transits)
            {
                while (courseDate <= _endDate.Date)
                {
                    int day = int.Parse(transit[4]);
                    var dayOfWeek = DayOfWeek.Sunday;
                    if (day < 6)
                        dayOfWeek = (DayOfWeek)(day + 1);

                    // enum DayOfWeek zaczyna sie od niedzieli
                    if (courseDate.DayOfWeek == dayOfWeek)
                    {
                        var courseTime = DateTime.Parse(transit[6]);
                        var date_ = courseDate.Day.ToString() + " " + courseDate.Month.ToString() + " " + courseDate.Year.ToString();// +
                         //   " " + courseTime.Hour.ToString() + ":" + courseTime.Minute.ToString();
                        Object[] course = { null, null, int.Parse(transit[0]), DateTime.Parse(date_) };
                        newCourses.Add(course);
                    }
                    courseDate = courseDate.AddDays(1);
                }
            }
            return newCourses;
        }

        private void AddVehiclesToCourses(ref List<object[]> newCourses)
        {
            List<String[]> vehicleTaken = new List<String[]>();
            List<String[]> vehicles;
            bool foundVehicle;

            newCourses.ForEach(delegate (object[] course)
            {
                foundVehicle = false;

                List<String[]> transit = DBCommunicator.SelectFromTransitsById(int.Parse(course[indexTransit].ToString()));
                // TODO: Sprawdzenie czy istnieje przejazd 
                string preferedCapacity = transit[0][indexDBTCapacity];
                string date = course[indexDate].ToString();

                string hourStart = transit[0][indexDBTStartTime];
                TimeSpan timeAdditional = TimeSpan.Parse("01:00");
                TimeSpan timeStart = TimeSpan.Parse(hourStart);
                TimeSpan timeEnd = timeStart;
                GetTransitStartEndTime(int.Parse(transit[0][0]), ref timeStart, ref timeEnd);
                TimeSpan timeStartWithAdd = timeStart.Add(timeAdditional);
                TimeSpan timeEndWithAdd = timeEnd.Add(timeAdditional);

                TimeSpan transitStartTime = timeStart;
                TimeSpan transitEndTime = timeStart;

                vehicles = DBCommunicator.SelectFromVehiclesByCapacityAndType(int.Parse(transit[0][indexDBTCapacity]), DBCommunicator.SelectVehicleTypeByTransitId(int.Parse(transit[0][0])));

                if (vehicles != null)
                {
                    foreach (String[] vehicle in vehicles)
                    {
                        foundVehicle = true;
                        // Szukamy kursu

                        List<string[]> courses = DBCommunicator.SelectFromCourseByVehicleIdAndDate(int.Parse(vehicle[0]), (DateTime)course[indexDate]);

                        foreach (string[] cou in courses)
                        {
                            GetTransitStartEndTime(int.Parse(cou[3]), ref transitStartTime, ref transitEndTime);

                            // Sprawdzamy czy nie jest wolny
                            if (timeEndWithAdd > transitStartTime && timeStartWithAdd < transitEndTime)
                            {
                                foundVehicle = false;
                                break;
                            }
                        }

                        foreach (string[] take in vehicleTaken)
                        {
                            if (vehicle[0] == take[0] && course[indexDate].ToString() == take[3])
                            {
                                transitStartTime = TimeSpan.Parse(take[1]);
                                transitEndTime = TimeSpan.Parse(take[2]);

                                // Sprawdzamy czy nie jest wolny
                                if (timeEndWithAdd > transitStartTime && timeStartWithAdd < transitEndTime)
                                {
                                    foundVehicle = false;
                                    break;
                                }
                            }
                        }

                        if (foundVehicle)
                        {
                            course[indexVehicle] = vehicle[0];
                            String[] newTake = { vehicle[0], timeStart.ToString(), timeEnd.ToString(), course[indexDate].ToString() };
                            vehicleTaken.Add(newTake);
                            break;
                        }
                    }
                }

                if (!foundVehicle)
                {
                    vehicles = DBCommunicator.SelectFromVehiclesByNotCapacityAndType(int.Parse(transit[0][indexDBTCapacity]), DBCommunicator.SelectVehicleTypeByTransitId(int.Parse(transit[0][0])));

                    if (vehicles != null)
                    {
                        foreach (String[] vehicle in vehicles)
                        {
                            foundVehicle = true;

                            // Szukamy kursu
                            List<string[]> courses = DBCommunicator.SelectFromCourseByVehicleIdAndDate(int.Parse(vehicle[0]), (DateTime)course[indexDate]);

                            foreach (string[] cou in courses)
                            {
                                GetTransitStartEndTime(int.Parse(cou[3]), ref transitStartTime, ref transitEndTime);

                                // Sprawdzamy czy nie jest wolny
                                if (timeEndWithAdd > transitStartTime && timeStartWithAdd < transitEndTime)
                                {
                                    foundVehicle = false;
                                    break;
                                }
                            }

                            foreach (string[] take in vehicleTaken)
                            {
                                if (vehicle[0] == take[0] && course[indexDate].ToString() == take[3])
                                {
                                    transitStartTime = TimeSpan.Parse(take[1]);
                                    transitEndTime = TimeSpan.Parse(take[2]);

                                    // Sprawdzamy czy nie jest wolny
                                    if (timeEndWithAdd > transitStartTime && timeStartWithAdd < transitEndTime)
                                    {
                                        foundVehicle = false;
                                        break;
                                    }
                                }
                            }

                            if (foundVehicle)
                            {
                                course[indexVehicle] = vehicle[0];
                                String[] newTake = { vehicle[0], timeStart.ToString(), timeEnd.ToString(), course[indexDate].ToString() };
                                vehicleTaken.Add(newTake);
                                break;
                            }
                        }
                    }

                }
            });
        }

        private void GetTransitStartEndTime(int idTransit, ref TimeSpan transitStart, ref TimeSpan transitEnd)
        {
            List<string[]> transitsData = DBCommunicator.SelectFromTransitsById(idTransit);
            string hour = transitsData[0][indexDBTStartTime];
            int idFirstStop = int.Parse(transitsData[0][indexDBTFirstStop]);

            TimeSpan transitTime = TimeSpan.Parse(hour);
            transitStart = transitTime;
            int minutesToAdd;

            List<string[]> route = DBCommunicator.SelectFromStopsOnRouteById(idFirstStop);
            int idNextStop;

            // Zdobywamy kolejne przystanki na trasie, ich nazwy i czas przejazdu
            while (route != null)
            {
                idNextStop = -3;

                if (route.Count > 0)
                {
                    // Zdobycie czasu przyjazdu na przystanek
                    minutesToAdd = 0;
                    int.TryParse(route[0][5], out minutesToAdd);
                    transitTime += TimeSpan.FromMinutes(minutesToAdd);

                    int.TryParse(route[0][2], out idNextStop);
                }
                route = DBCommunicator.SelectFromStopsOnRouteById(idNextStop);
            }

            transitEnd = transitTime;
        }

        private void AddDriversToCoureses(ref List<object[]> newCourses)
        {
            List<String[]> driverTaken = new List<String[]>();
            List<String[]> drivers;
            bool foundDriver;

            TimeSpan shiftHour1 = TimeSpan.Parse("05:00");
            TimeSpan shiftHour2 = TimeSpan.Parse("13:00");
            TimeSpan shiftHour3 = TimeSpan.Parse("21:00");

            // TODO: Znalezc odpowiednie pojazdy i dodac je do kursow
            newCourses.ForEach(delegate (object[] course)
            {
                // TODO: Sprawdzić czy nie święto

                foundDriver = false;

                TimeSpan courseStartTime = TimeSpan.Parse("00:00");
                TimeSpan courseEndTime = courseStartTime;

                GetTransitStartEndTime((int)course[indexTransit], ref courseStartTime, ref courseEndTime);

                int vehicleType = DBCommunicator.SelectVehicleTypeByTransitId((int)course[indexTransit]);

                if (courseStartTime >= shiftHour1 && courseStartTime < shiftHour2)
                {
                    drivers = DBCommunicator.SelectFromDriversByVehicleAndShift(vehicleType, (int)ShiftTypes.Morning);
                }
                else if (courseStartTime >= shiftHour2 && courseStartTime < shiftHour3)
                {
                    drivers = DBCommunicator.SelectFromDriversByVehicleAndShift(vehicleType, (int)ShiftTypes.Afternoon);
                }
                else
                {
                    drivers = DBCommunicator.SelectFromDriversByVehicleAndShift(vehicleType, (int)ShiftTypes.Night);
                }

                foreach (string[] driver in drivers)
                {
                    if (DBCommunicator.DoDriverHaveAbsenceOnDate(int.Parse(driver[0]), (DateTime)course[indexDate]))
                    {
                        break;
                    }

                    foundDriver = true;

                    List<string[]> assigments = DBCommunicator.SelectFromAssignmentsByDriverIdAndDate(int.Parse(driver[0]), (DateTime)course[indexDate]);

                    foreach (string[] assigment in assigments)
                    {
                        TimeSpan startTime = TimeSpan.Parse(assigment[4]);
                        TimeSpan endTime = TimeSpan.Parse(assigment[5]);

                        // TODO: Sprawdzamy czy nie jest wolny
                        if (courseEndTime > startTime && courseStartTime < endTime)
                        {
                            foundDriver = false;
                            break;
                        }
                    }

                    if (foundDriver)
                    {
                        // Sprawdzanie w przypisaniach aktualnych
                        foreach (string[] assigment in driverTaken)
                        {
                            if (assigment[0] == driver[0] && course[indexDate].ToString() == assigment[3])
                            {
                                TimeSpan startTime = TimeSpan.Parse(assigment[1]);
                                TimeSpan endTime = TimeSpan.Parse(assigment[2]);

                                if (courseEndTime > startTime && courseStartTime < endTime)
                                {
                                    foundDriver = false;
                                    break;
                                }
                            }
                        }

                        if (foundDriver)
                        {
                            String[] taken = { driver[0], courseStartTime.ToString(), courseEndTime.ToString(), course[indexDate].ToString() };
                            driverTaken.Add(taken);
                            course[indexDriver] = driver[0];

                            
                            var transit = DBCommunicator.SelectFromTransitsById(int.Parse(course[2].ToString()))[0];
                            var line = DBCommunicator.SelectFromLinesById(int.Parse(transit[1]))[0];

                            DBCommunicator.InsertIntoAssignments(int.Parse(course[0].ToString()), int.Parse(line[0]), DateTime.Parse(course[indexDate].ToString()), courseStartTime, courseEndTime, int.Parse(transit[2]));

                            break;
                        }
                    }
                }
            });
        }

        private void PushToDB(in List<object[]> newCourses)
        {
            // TODO: Przeslac kursy do BD
            foreach (var course in newCourses)
            {
                int idDriver = course[0] == null ? -1 : int.Parse(course[0].ToString());
                int idVehicle = course[1] == null ? -1 : int.Parse(course[1].ToString());

                DBCommunicator.InsertIntoCourses(idDriver, idVehicle, int.Parse(course[2].ToString()), DateTime.Parse(course[3].ToString()));
            }
        }
    }
}

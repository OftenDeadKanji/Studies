using System;
using System.Collections.Generic;
using System.Data;

namespace ZarzadzanieFlota
{
    public partial class ManagerDriverAssigments : BaseForm
    {
        DataTable dataSource = new DataTable();
        private int driverId, assigmentId;
        private string driverName, driverSurname;

        private int lineNoInLine = 1;
        private int stopNameIndexInStop = 1, districtNameIndexInStop = 2;
        private int nextStopIndexInRout = 2, stopIndexInRout = 1, transitTimeIndexInRout = 5;
        private int idLineInAssi = 2, dateInAssi = 3, startTimeInAssi = 4, stopInAssi = 6;

        public ManagerDriverAssigments(int driverId, string driverName, string driverSurname, int assigmentId)
        {
            this.driverId = driverId;
            this.driverName = driverName;
            this.driverSurname = driverSurname;
            this.assigmentId = assigmentId;
            InitializeComponent();

            SetControlsContent();
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerDriverShow(driverId, driverName, driverSurname));
        }

        private void SetControlsContent()
        {
            List<string[]> assigments = DBCommunicator.SelectFromAssignmentsById(assigmentId);

            if (assigments == null)
            {
                return;
            }
            if (assigments.Count < 1)
            {
                return;
            }

            string hour = assigments[0][startTimeInAssi];
            int idFirstStop = int.Parse(assigments[0][stopInAssi]);
            int idLastStop = -3;

            TimeSpan transitTime = TimeSpan.Parse(hour);
            int minutesToAdd;

            List<string[]> route = DBCommunicator.SelectFromStopsOnRouteById(idFirstStop);
            int idNextStop, idStop;
            string stopName, districtName;
            List<string[]> stop;

            // Zdobywamy kolejne przystanki na trasie, ich nazwy i czas przejazdu
            while (route != null)
            {
                idNextStop = -3;
                idStop = -3;
                stopName = "";
                districtName = "";

                if (route.Count > 0)
                {
                    // Zdobycie nazwy przystanku
                    int.TryParse(route[0][stopIndexInRout], out idStop);
                    stop = DBCommunicator.SelectFromStopsById(idStop);
                    if (stop != null)
                    {
                        if (stop.Count > 0)
                        {
                            stopName = stop[0][stopNameIndexInStop];
                            districtName = stop[0][districtNameIndexInStop];

                            idLastStop = idStop;
                        }
                    }

                    // Zdobycie czasu przyjazdu na przystanek
                    minutesToAdd = 0;
                    int.TryParse(route[0][transitTimeIndexInRout], out minutesToAdd);
                    transitTime += TimeSpan.FromMinutes(minutesToAdd);

                    // Umieszczenie danych w gridzie
                    dataGridView1.Rows.Add(districtName + " " + stopName, transitTime);

                    int.TryParse(route[0][nextStopIndexInRout], out idNextStop);
                }
                route = DBCommunicator.SelectFromStopsOnRouteById(idNextStop);
            }

            // Ustawianie textboxów 
            textBoxDriver.Text = driverName + " " + driverSurname;
            textBoxDate.Text = assigments[0][dateInAssi];

            List<string[]> lines = DBCommunicator.SelectFromLinesById(int.Parse(assigments[0][idLineInAssi]));
            if (lines != null)
            {
                if (lines.Count > 0)
                {
                    textBoxLine.Text = lines[0][lineNoInLine];
                }
            }

            List<string[]> transits = DBCommunicator.SelectFromTransitsByLineWeekdayStopsTime(int.Parse(assigments[0][idLineInAssi]),
                (int)DateTime.Parse(assigments[0][dateInAssi]).DayOfWeek,
                idFirstStop,
                idLastStop,
                assigments[0][startTimeInAssi]);

            if (transits != null)
            {
                if (transits.Count > 0)
                {
                    int transitId = -1;
                    foreach (string[] transit in transits)
                    {
                        transitId = int.Parse(transit[0]);
                        List<string[]> courses = DBCommunicator.SelectFromCoursesByTransitIdDriverIdDate(transitId, driverId, assigments[0][dateInAssi]);
                        if (courses != null)
                        {
                            if (courses.Count > 0)
                            {
                                textBoxVehicle.Text = "";
                                break;
                            }
                        }
                    }
                }
            }            
        }
    }
}

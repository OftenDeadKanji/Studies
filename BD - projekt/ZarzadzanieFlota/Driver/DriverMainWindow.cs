using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class DriverMainWindow : BaseForm
    {
        DataTable dataTable;

        private int driverId;
        private string name, surname;
        private int indexHour = 0, indexMon = 1, indexTue = 3, indexWen = 5, indexThu = 7, indexFri = 9, indexSat = 11, indexSun = 13;
        private int indexDBAsId = 0, indexDBAsLine = 2, indexDBAsDate = 3, indexDBAsStart = 4, indexDBAsEnd = 5;

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex > 0)
            {
                string assigments = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value.ToString();

                if (assigments != "")
                {
                    string[] splitedAssigments = assigments.Split();
                    int assigment;

                    if (splitedAssigments.Length > 1)
                    {
                        string[] splitedLines = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Split(',');

                        if (splitedLines.Length == splitedAssigments.Length)
                        {
                            List<int> assigmentIDs = new List<int>();
                            List<int> lineNumbers = new List<int>();

                            int lineNo;

                            for (int i = 0; i < splitedAssigments.Length; i++)
                            {
                                if (int.TryParse(splitedAssigments[i], out assigment) && int.TryParse(splitedLines[i], out lineNo))
                                {
                                    assigmentIDs.Add(assigment);
                                    lineNumbers.Add(lineNo);
                                }
                            }

                            if (assigmentIDs.Count > 1)
                            {
                                ChangeForm(this, new DriverChooseLine(driverId, name, surname, assigmentIDs, lineNumbers));
                            }
                        }
                    }
                    else
                    {
                        if (int.TryParse(assigments, out assigment))
                        {
                            ChangeForm(this, new DriverTimetable(driverId, name, surname, assigment));
                        }
                    }
                }
            }
        }

        private int indexDBAbDate = 1;
        private int indexDBLNumber = 1;

        public DriverMainWindow(int driverId, string driverName = "", string driverSurname = "")
        {
            this.driverId = driverId;
            
            if(driverSurname == "" || driverName == "")
            {
                GetDriverData();
            }
            else
            {
                this.name = driverName;
                this.surname = driverSurname;
            }

            InitializeComponent();

            textBoxName.Text = name + " " + surname;

            SetComboboxDateContent();
            LoadData();
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ChoosingProffesion());
        }

        private void comboBoxDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void GetDriverData()
        {
            List<string[]> employees = DBCommunicator.SelectFromEmployeesById(driverId);
            if (employees != null)
            {
                if (employees.Count > 0)
                {
                    this.name = employees[0][1];
                    this.surname = employees[0][2];
                }
            }
        }

        private void SetComboboxDateContent()
        {
            DateTime today = DateTime.Now;
            DateTime firstDay = today;

            switch (today.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    break;
                case DayOfWeek.Tuesday:
                    firstDay = firstDay.AddDays(-1);
                    break;
                case DayOfWeek.Wednesday:
                    firstDay = firstDay.AddDays(-2);
                    break;
                case DayOfWeek.Thursday:
                    firstDay = firstDay.AddDays(-3);
                    break;
                case DayOfWeek.Friday:
                    firstDay = firstDay.AddDays(-4);
                    break;
                case DayOfWeek.Saturday:
                    firstDay = firstDay.AddDays(-5);
                    break;
                case DayOfWeek.Sunday:
                    firstDay = firstDay.AddDays(-6);
                    break;
            }

            DateTime lastDay = firstDay;
            lastDay = lastDay.AddDays(6);

            AddToCombobox(firstDay, lastDay);
            AddToCombobox(firstDay.AddDays(7), lastDay.AddDays(7));
            AddToCombobox(firstDay.AddDays(14), lastDay.AddDays(14));
            AddToCombobox(firstDay.AddDays(21), lastDay.AddDays(21));

            AddToCombobox(firstDay.AddDays(28), lastDay.AddDays(28));
            AddToCombobox(firstDay.AddDays(35), lastDay.AddDays(35));
            AddToCombobox(firstDay.AddDays(42), lastDay.AddDays(42));
            AddToCombobox(firstDay.AddDays(49), lastDay.AddDays(49));

            comboBoxDate.SelectedIndex = 0;
        }

        private void AddToCombobox(DateTime firstDate, DateTime lastDate)
        {
            int day1 = firstDate.Day;
            int day2 = lastDate.Day;
            int month1 = firstDate.Month;
            int month2 = lastDate.Month;
            int year1 = firstDate.Year;
            int year2 = lastDate.Year;
            string dateToAdd = "";

            if (day1 < 10)
            {
                dateToAdd += "0";
            }
            dateToAdd += day1 + ".";
            if (month1 < 10)
            {
                dateToAdd += "0";
            }
            dateToAdd += month1 + ".";
            dateToAdd += year1 + " - ";
            if (day2 < 10)
            {
                dateToAdd += "0";
            }
            dateToAdd += day2 + ".";
            if (month2 < 10)
            {
                dateToAdd += "0";
            }
            dateToAdd += month2 + ".";
            dateToAdd += year2;

            comboBoxDate.Items.Add(dateToAdd);
        }

        private void SetDayColumnsContent()
        {
            List<string[]> assigments = DBCommunicator.SelectFromAssignmentsByDriverId(driverId);
            List<string[]> absences = DBCommunicator.SelectFromAbsencesByDriverId(driverId);

            if (comboBoxDate.SelectedIndex < 0)
            {
                return;
            }

            string[] datesFromComboBox = comboBoxDate.SelectedItem.ToString().Split('-');
            if (datesFromComboBox.Length < 2)
            {
                return;
            }

            DateTime startDate;
            DateTime endDate;
            DateTime date;

            if (!DateTime.TryParse(datesFromComboBox[0].Trim(), out startDate))
            {
                return;
            }
            if (!DateTime.TryParse(datesFromComboBox[1].Trim(), out endDate))
            {
                return;
            }

            if (absences != null)
            {
                if (absences.Count > 0)
                {
                    absences.ForEach(delegate (string[] absence)
                    {
                        if (DateTime.TryParse(absence[indexDBAbDate], out date))
                        {
                            if (date >= startDate && date <= endDate)
                            {
                                InsertAbsenceIntoColumn(date.DayOfWeek);
                            }
                        }
                    });
                }
            }

            if (assigments != null)
            {
                if (assigments.Count > 0)
                {
                    assigments.ForEach(delegate (string[] assigment)
                    {
                        if (DateTime.TryParse(assigment[indexDBAsDate], out date))
                        {
                            if (date >= startDate && date <= endDate)
                            {
                                InsertAssigmentIntoColumn(date.DayOfWeek,
                                    assigment[indexDBAsStart],
                                    assigment[indexDBAsEnd],
                                    assigment[indexDBAsId],
                                    assigment[indexDBAsLine]);
                            }
                        }
                    });
                }
            }
        }

        private void InsertAssigmentIntoColumn(DayOfWeek dayOfWeek, string hourStart, string hourEnd, string strId, string strLineId)
        {
            int id, lineId;

            if (!int.TryParse(strId, out id))
            {
                return;
            }
            if (!int.TryParse(strLineId, out lineId))
            {
                return;
            }

            List<string[]> lines = DBCommunicator.SelectFromLinesById(lineId);

            if (lines == null)
            {
                return;
            }
            if (lines.Count < 0)
            {
                return;
            }

            int line;
            if (!int.TryParse(lines[0][indexDBLNumber], out line))
            {
                return;
            }

            int dayIndex = -1;

            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    dayIndex = indexMon;
                    break;
                case DayOfWeek.Tuesday:
                    dayIndex = indexTue;
                    break;
                case DayOfWeek.Wednesday:
                    dayIndex = indexWen;
                    break;
                case DayOfWeek.Thursday:
                    dayIndex = indexThu;
                    break;
                case DayOfWeek.Friday:
                    dayIndex = indexFri;
                    break;
                case DayOfWeek.Saturday:
                    dayIndex = indexSat;
                    break;
                case DayOfWeek.Sunday:
                    dayIndex = indexSun;
                    break;
                default:
                    break;
            }

            if (dayIndex < 0)
            {
                return;
            }

            // TODO Sprawdzanie poprawności danych
            int timeStart, timeEnd;
            string start = hourStart.Split(':')[0];
            string end = hourEnd.Split(':')[0];

            timeStart = int.Parse(start);
            timeEnd = int.Parse(end);

            for (int i = timeStart; i <= timeEnd; i++)
            {
                //Wrzucanie do tabelki
                if (dataTable.Rows[i][dayIndex + 1].ToString() != "")
                {
                    if (dataTable.Rows[i][dayIndex + 1].ToString() == "WOLNE")
                    {
                        dataTable.Rows[i][dayIndex] = line;
                        dataTable.Rows[i][dayIndex + 1] = id;
                    }
                    else
                    {
                        dataTable.Rows[i][dayIndex] = dataTable.Rows[i][dayIndex] + ", " + line;
                        dataTable.Rows[i][dayIndex + 1] = dataTable.Rows[i][dayIndex + 1] + " " + id;
                    }
                }
                else
                {
                    dataTable.Rows[i][dayIndex] = line;
                    dataTable.Rows[i][dayIndex + 1] = id;
                }
            }
        }

        private void InsertAbsenceIntoColumn(DayOfWeek dayOfWeek)
        {
            int dayIndex = -1;

            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    dayIndex = indexMon;
                    break;
                case DayOfWeek.Tuesday:
                    dayIndex = indexTue;
                    break;
                case DayOfWeek.Wednesday:
                    dayIndex = indexWen;
                    break;
                case DayOfWeek.Thursday:
                    dayIndex = indexThu;
                    break;
                case DayOfWeek.Friday:
                    dayIndex = indexFri;
                    break;
                case DayOfWeek.Saturday:
                    dayIndex = indexSat;
                    break;
                case DayOfWeek.Sunday:
                    dayIndex = indexSun;
                    break;
                default:
                    break;
            }

            if (dayIndex > -1)
            {
                for (int i = 0; i < 24; i++)
                {
                    dataTable.Rows[i][dayIndex] = "WOLNE";
                }
            }
        }

        private void LoadData()
        {
            dataTable = new DataTable();

            dataTable.Columns.Add("Godzina", typeof(string));
            dataTable.Columns.Add("PN", typeof(string));
            dataTable.Columns.Add("monId", typeof(string));
            dataTable.Columns.Add("WT", typeof(string));
            dataTable.Columns.Add("tueId", typeof(string));
            dataTable.Columns.Add("ŚR", typeof(string));
            dataTable.Columns.Add("wenId", typeof(string));
            dataTable.Columns.Add("CZW", typeof(string));
            dataTable.Columns.Add("thuId", typeof(string));
            dataTable.Columns.Add("PT", typeof(string));
            dataTable.Columns.Add("friId", typeof(string));
            dataTable.Columns.Add("SO", typeof(string));
            dataTable.Columns.Add("satId", typeof(string));
            dataTable.Columns.Add("ND", typeof(string));
            dataTable.Columns.Add("sunId", typeof(string));

            int hour = 0;
            while (hour < 10)
            {
                dataTable.Rows.Add("0" + hour + ":00");
                hour += 1;
            }
            while (hour < 24)
            {
                dataTable.Rows.Add(hour + ":00");
                hour += 1;
            }

            SetDayColumnsContent();

            dataGridView.DataSource = dataTable;

            dataGridView.Columns[indexHour].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = indexMon; i <= indexSun;)
            {
                dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                i += 2;
            }
            for (int i = indexMon + 1; i <= indexSun + 1;)
            {

                dataGridView.Columns[i].Visible = false;
                string columnName = dataGridView.Columns[i].Name;
                i += 2;
            }
        }
    }
}

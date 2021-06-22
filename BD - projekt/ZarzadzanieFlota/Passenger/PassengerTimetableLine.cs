using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class PassengerTimetableLine : BaseForm
    {
        int lineId;

        int stopIndex = 0, timeIndex = 1;
        int stopNameIndexInStop = 1, districtNameIndexInStop = 2;
        int nextStopIndexInRout = 2, stopIndexInRout = 1, transitTimeIndexInRout = 5;
        int idStartStopInTran = 2, idStopStopInTran = 3;
        int weekdayIndexInTran = 4, dayTypeIndexInTran = 5, startTimeIndexInTran = 6;

        public PassengerTimetableLine(int lineId)
        {
            this.lineId = lineId;
            InitializeComponent();

            setControlsText();
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            PassengerTimetable formNew = new PassengerTimetable();
            ChangeForm(this, formNew);
        }

        private void setControlsText()
        {
            List<string[]> lineData = DBCommunicator.SelectFromLinesById(lineId);

            if (lineData.Count > 0)
            {
                textBoxLineName.Text = lineData[0][1];
            }
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxDay.SelectedIndex >= 0)
            {
                SetComboBoxTimeContent();
            }
        }

        private void comboBoxDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxType.SelectedIndex >= 0)
            {
                SetComboBoxTimeContent();
            }
        }

        private void comboBoxTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetGridContent();
        }

        private void SetComboBoxTimeContent()
        {
            comboBoxTime.Items.Clear();
            List<string[]> transitsData = DBCommunicator.SelectFromTransitsByLineId(lineId);
            
            if(transitsData != null)
            {
                if (transitsData.Count > 0)
                {
                    int weekday;
                    int dayType;

                    transitsData.ForEach(delegate (string[] transit) {
                        weekday = -1;
                        dayType = -1;
                        int.TryParse(transit[weekdayIndexInTran], out weekday);
                        int.TryParse(transit[dayTypeIndexInTran], out dayType);

                        if (weekday == comboBoxDay.SelectedIndex && dayType == comboBoxType.SelectedIndex)
                        {
                            comboBoxTime.Items.Add(transit[startTimeIndexInTran]);
                        }
                    });
                }
            }
        }

        private void SetGridContent()
        {
            dataGridView1.Rows.Clear();

            int weekday = comboBoxDay.SelectedIndex;
            int dayType = comboBoxType.SelectedIndex;
            string hour = comboBoxTime.Text;
            int idFirstStop = -1;
            int idLastStop = -1;

            // Zdobywamy przystanek początkowy i końcowy z Przejazdów
            List<string[]> transitsData = DBCommunicator.SelectFromTransitsByLineId(lineId);
            if(transitsData != null)
            {
                if (transitsData.Count > 0)
                {
                    int weekdayDB, dayTypeDB;

                    transitsData.ForEach(delegate (string[] transit) {
                        weekdayDB = -1;
                        dayTypeDB = -1;
                        int.TryParse(transit[weekdayIndexInTran], out weekdayDB);
                        int.TryParse(transit[dayTypeIndexInTran], out dayTypeDB);
                        string hourDB = transit[startTimeIndexInTran].ToString();

                        if (weekdayDB == weekday && dayTypeDB == dayType && hour == hourDB)
                        {
                            int.TryParse(transit[idStopStopInTran], out idLastStop);
                            int.TryParse(transit[idStartStopInTran], out idFirstStop);
                        }
                    });
                }
            }

            if(idFirstStop < 0 || idLastStop < 0)
            {
                return;
            }

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
                    if(stop!= null)
                    {
                        if (stop.Count > 0)
                        {
                            stopName = stop[0][stopNameIndexInStop];
                            districtName = stop[0][districtNameIndexInStop];
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
        }
    }
}

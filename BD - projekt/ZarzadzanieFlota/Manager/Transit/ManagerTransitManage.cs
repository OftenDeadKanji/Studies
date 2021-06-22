using System;

namespace ZarzadzanieFlota
{
    public partial class ManagerTransitManage : BaseForm
    {
        int transitId;
        int firstStopId, lastStopId;

        public ManagerTransitManage(int id)
        {
            InitializeComponent();

            transitId = id;

            var result = DBCommunicator.SelectFromTransitsById(transitId)[0];
            var line = DBCommunicator.SelectFromLinesById(int.Parse(result[1]))[0];
            textBoxLine.Text = line[1];

            var firstStopOnRoute = DBCommunicator.SelectFromStopsOnRouteById(int.Parse(result[2]))[0];
            var lastStopOnRoute = DBCommunicator.SelectFromStopsOnRouteById(int.Parse(result[3]))[0];

            firstStopId = int.Parse(firstStopOnRoute[0]);
            lastStopId = int.Parse(lastStopOnRoute[0]);

            var firstStop = DBCommunicator.SelectFromStopsById(int.Parse(firstStopOnRoute[1]))[0];
            var lastStop = DBCommunicator.SelectFromStopsById(int.Parse(lastStopOnRoute[1]))[0];

            textBoxFirstStop.Text = firstStop[2] + firstStop[1];
            textBoxLastStop.Text = lastStop[2] + lastStop[1];

            DateTime startTime = DateTime.Parse(result[6]);
            startHour.Value = startTime.Hour;
            startMinute.Value = startTime.Minute;

            comboBoxWeekday.SelectedIndex = int.Parse(result[4]);
            comboBoxDayType.SelectedIndex = int.Parse(result[5]);

            capacity.Value = int.Parse(result[7]);
        }

        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerTransitShow(transitId));
        }

        private void buttonChooseRoute_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerRoutes(transitId));
        }

        private void buttonAddRouteNew_Click(object sender, EventArgs e)
        {
            var transit = DBCommunicator.SelectFromTransitsById(transitId)[0];
            ChangeForm(this, new ManagerRouteAdd(int.Parse(transit[1]), firstStopId, lastStopId, false, transitId, 2));
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            string time = "";

            if (startHour.Value < 10)
            {
                time += "0";
            }
            time += startHour.Value.ToString();

            time += ":";

            if (startMinute.Value < 10)
            {
                time += "0";
            }
            time += startMinute.Value.ToString();

            DBCommunicator.UpdateTransits(transitId, int.Parse(textBoxLine.Text), firstStopId, lastStopId, comboBoxWeekday.SelectedIndex, comboBoxDayType.SelectedIndex, DateTime.ParseExact(time, "HH:mm", System.Globalization.CultureInfo.InvariantCulture), decimal.ToInt32(capacity.Value));

            ChangeForm(this, new ManagerTransitShow(transitId));
        }
    }
}

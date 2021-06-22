using System;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class ManagerTransitShow : BaseForm
    {
        int transitId = -1;
        int lineId = -1;

        public ManagerTransitShow(int id)
        {
            InitializeComponent();

            transitId = id;

            var result = DBCommunicator.SelectFromTransitsById(id)[0];

            lineId = int.Parse(result[1]);
            var line = DBCommunicator.SelectFromLinesById(lineId)[0];
            textBoxLine.Text = line[1];

            textBoxWeekday.Text = result[4];
            textBoxDayType.Text = result[5];
            textBoxStartTime.Text = result[6];
            textBoxCapacity.Text = result[7];

            var firstStopOnRoute = DBCommunicator.SelectFromStopsOnRouteById(int.Parse(result[2]))[0];
            var lastStopOnRoute = DBCommunicator.SelectFromStopsOnRouteById(int.Parse(result[3]))[0];

            var firstStop = DBCommunicator.SelectFromStopsById(int.Parse(firstStopOnRoute[1]))[0];
            var lastStop = DBCommunicator.SelectFromStopsById(int.Parse(lastStopOnRoute[1]))[0];

            textBoxFirstStop.Text = firstStop[2] + " " + firstStop[1];
            textBoxLastStop.Text = lastStop[2] + " " + lastStop[1];
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerBusLineShow(lineId));
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerTransitManage(transitId));
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Czy na pewno chcesz usunąć ten przejazd?\nSpowoduje to usunięcie również trasy przypisanej do tego przejazdu (pod warunkiem, że nie jest ona przypisana jeszcze do innych przejazdów).", "Zapytanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                //usuwamy przejazd
                DBCommunicator.DeleteFromTransitsById(transitId);

                //usuwamy "samotne" trasy
                var result = DBCommunicator.SelectAbandonedStopsOnRoute();

                foreach (var stop in result)
                {
                    string[] stopToDel = stop;
                    while (stopToDel != null)
                    {
                        var temp = stopToDel;

                        //stopToDel = stopToDel->next
                        stopToDel = stopToDel[2].Equals("") ? null : DBCommunicator.SelectFromStopsOnRouteById(int.Parse(stopToDel[2]))[0];

                        if (stopToDel != null)
                        {
                            //temp->next->prev = NULL
                            int nextNextId = stopToDel[2].Equals("") ? -1 : int.Parse(stopToDel[2]);

                            DBCommunicator.UpdateStopsOnRoute(int.Parse(stopToDel[0]), int.Parse(stopToDel[1]), nextNextId, -1, int.Parse(stopToDel[4]), int.Parse(stopToDel[5]));
                        }
                        DBCommunicator.DeleteFromStopsOnRouteById(int.Parse(temp[0]));
                    }
                }
                if (lineId > 0)
                    ChangeForm(this, new ManagerBusLineShow(lineId));
                else
                    ChangeForm(this, new ManagerBusLine());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerRouteShow(transitId));
        }
    }
}

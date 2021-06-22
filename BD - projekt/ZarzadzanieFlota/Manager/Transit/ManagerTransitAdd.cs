using System;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class ManagerTransitAdd : BaseForm
    {
        int lineId;
        int firstStopId, lastStopId;

        public ManagerTransitAdd(int lineId, int firstStopId, int lastStopId)
        {
            InitializeComponent();
            comboBoxDayType.SelectedIndex = comboBoxWeekday.SelectedIndex = 0;
            
            if (lineId < 0)
            {
                //powrót do poprzedniego okna
            }
            else if (firstStopId < 0 || lastStopId < 0)
            {
                //dodajemy nowy przejazd, brak trasy
                this.lineId = lineId;
                this.firstStopId = this.lastStopId = -1;
                textBoxFirstStop.Text = textBoxLastStop.Text = "Brak";

                //ukrycie reszty kontrolek
                startHour.Enabled = false;
                startMinute.Enabled = false;
                comboBoxWeekday.Enabled = false;
                comboBoxDayType.Enabled = false;
                capacity.Enabled = false;
                buttonAdd.Enabled = false;
            }
            else
            {
                //trasa wybrana
                this.lineId = lineId;
                this.firstStopId = firstStopId;
                this.lastStopId = lastStopId;
                
                var firstStopOnRoute = DBCommunicator.SelectFromStopsOnRouteById(firstStopId)[0];
                var firstStop = DBCommunicator.SelectFromStopsById(int.Parse(firstStopOnRoute[1]))[0];

                var lastStopOnRoute = DBCommunicator.SelectFromStopsOnRouteById(lastStopId)[0];
                var lastStop = DBCommunicator.SelectFromStopsById(int.Parse(lastStopOnRoute[1]))[0];

                textBoxFirstStop.Text = firstStop[2] + " " + firstStop[1];
                textBoxLastStop.Text = lastStop[2] + " " + lastStop[1];

                //być może to jest niepotrzebne
                startHour.Enabled = true;
                startMinute.Enabled = true;
                comboBoxWeekday.Enabled = true;
                comboBoxDayType.Enabled = true;
                capacity.Enabled = true;
                buttonAdd.Enabled = true;
            }

            var line = DBCommunicator.SelectFromLinesById(lineId)[0];
            textBoxLine.Text = line[1];
        }
        
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string time = "";

            if(startHour.Value < 10)
            {
                time += "0";
            }
            time += startHour.Value.ToString();
            
            time += ":";
            
            if(startMinute.Value < 10)
            {
                time += "0";
            }
            time += startMinute.Value.ToString();

            int id = DBCommunicator.InsertIntoTransits(lineId, firstStopId, lastStopId, comboBoxWeekday.SelectedIndex, comboBoxDayType.SelectedIndex, DateTime.ParseExact(time, "HH:mm", System.Globalization.CultureInfo.InvariantCulture), decimal.ToInt32(capacity.Value));
            
            if(id > 0)
            {
                MessageBox.Show("Baza danych została zaktualizowana.");
            }
            
            ChangeForm(this, new ManagerBusLineShow(lineId));
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerBusLineShow(lineId));
        }

        private void buttonAddRouteNew_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerRouteAdd(lineId, -1, -1));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerRoutes(-1, lineId, firstStopId, lastStopId));
        }
    }
}

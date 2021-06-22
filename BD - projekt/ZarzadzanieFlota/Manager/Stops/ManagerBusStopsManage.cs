using System;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class ManagerBusStopsManage : BaseForm
    {
        private int stopId;

        public ManagerBusStopsManage(int id)
        {
            InitializeComponent();

            stopId = id;

            var result = DBCommunicator.SelectFromStopsById(id)[0];

            stopName.Text = result[1];
            district.Text = result[2];
            int standCount = int.Parse(result[3]);

            numericAvailable.Value = standCount;
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerBusStopShow(stopId));
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            int result = DBCommunicator.UpdateStops(stopId, stopName.Text, district.Text, decimal.ToInt32(numericAvailable.Value));
            if (result == 1)
            {
                ChangeForm(this, new ManagerBusStops());
                MessageBox.Show("Baza danych została zaktualizowana.");
            }
        }
    }
}

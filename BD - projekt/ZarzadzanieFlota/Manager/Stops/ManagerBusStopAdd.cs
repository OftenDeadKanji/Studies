using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace ZarzadzanieFlota.Manager
{
    public partial class ManagerBusStopAdd : BaseForm
    {
        public ManagerBusStopAdd()
        {
            InitializeComponent();
        }
       
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            int rows = DBCommunicator.InsertIntoStops(stopName.Text, district.Text, Decimal.ToInt32(available.Value));

            //sprawdzenie czy rows == 1, jeśli nie to co?
            if (rows == 1)
                MessageBox.Show("Pomyślnie dodano przystanek.");

            //powrót do przeglądania
            ChangeForm(this, new ManagerBusStops());
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            ManagerBusStops formNew = new ManagerBusStops();
            ChangeForm(this, formNew);
        }
    }
}

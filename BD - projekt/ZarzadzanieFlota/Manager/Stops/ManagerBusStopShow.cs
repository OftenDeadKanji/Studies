using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class ManagerBusStopShow : BaseForm
    {
        private int stopId;

        public ManagerBusStopShow(int id)
        {
            InitializeComponent();

            stopId = id;

            var results = DBCommunicator.SelectFromStopsById(id)[0];

            stopName.Text = results[1];
            district.Text = results[2];
            available.Text = results[3];
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerBusStops());
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerBusStopsManage(stopId));
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("W przypadku, gdy przystanek należy do którejkolwiek z tras, jego usunięcie nie będzie możliwe. Czy chcesz kontynuować?", "Zapytanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                try
                {
                    int rows = DBCommunicator.DeleteFromStopsById(stopId);
                    if (rows == 1)
                        MessageBox.Show("Pomyślnie usunięto przystanek.");

                    ChangeForm(this, new ManagerBusStops());
                }
                catch (SqlException)
                {
                    MessageBox.Show("Błąd przy usuwaniu (czy przystanek należy do tras(y)?), pożądana akcja nie została wykonana.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

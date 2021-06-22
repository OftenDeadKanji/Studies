using iTextSharp.text;
using Nager.Date;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class PassengerSearch : BaseForm
    {
        DataTable stops1 = new DataTable();
        DataTable stops2 = new DataTable();

        public PassengerSearch()
        {
            InitializeComponent();

            LoadStops();
            SetupGridView();
        }

        private void LoadStops()
        {
            stops1.Columns.Add("Dzielnica", typeof(string));
            stops2.Columns.Add("Dzielnica", typeof(string));
            stops1.Columns.Add("Przystanek", typeof(string));
            stops2.Columns.Add("Przystanek", typeof(string));

            List<string[]> allStops = DBCommunicator.SelectFromStopsById();
            foreach( string[] stop in allStops)
            {
                stops1.Rows.Add(stop[2], stop[1]);
                stops2.Rows.Add(stop[2], stop[1]);
            }
        }

        private void SetupGridView()
        {
            dataGridView1.DataSource = stops1;
            dataGridView2.DataSource = stops2;
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            PassengerMainWindow formNew = new PassengerMainWindow();
            ChangeForm(this, formNew);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var startStopsRow = dataGridView1.SelectedRows[0];
            string startStop = startStopsRow.Cells[0].Value.ToString() + ", " + startStopsRow.Cells[1].Value.ToString();
            var endStopsRow = dataGridView2.SelectedRows[0];
            string endStop = endStopsRow.Cells[0].Value.ToString() + ", " + endStopsRow.Cells[1].Value.ToString();

            if (endStop.Equals(startStop))
            {
                MessageBox.Show("Proszę wybrać dwa RÓŻNE przystanki.");
                return;
            }

            DateTime whenDate = dateTimePicker1.Value;
            PassengerSearchResults formNew = new PassengerSearchResults(whenDate, startStop, endStop);
            ChangeForm(this, formNew);
        }
    }
}

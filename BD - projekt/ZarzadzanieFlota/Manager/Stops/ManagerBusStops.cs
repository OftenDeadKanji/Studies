using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class ManagerBusStops : BaseForm
    {
        DataGridViewRow selectedRow = null;

        public ManagerBusStops()
        {
            InitializeComponent();
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerMainWindow());
        }

        private void buttonAddBusStop_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new Manager.ManagerBusStopAdd());
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                int id = (int)selectedRow.Cells[0].Value;
                
                ChangeForm(this, new ManagerBusStopShow(id));
            }
        }

        private void ManagerBusStops_Load(object sender, EventArgs e)
        {
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'publicTransportDataSet.Stops' . Możesz go przenieść lub usunąć.
            this.stopsTableAdapter.Fill(this.publicTransportDataSet.Stops);

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedRow = dataGridView1.SelectedRows[0];
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string name = nameToSearch.Text;
            string district = distToSearch.Text;
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "name like '%" + name + "%' AND district like '%" + district + "%'";
            dataGridView1.DataSource = bs;
        }

        private void buttonTimetable_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerTimetableStops());
        }
    }
}

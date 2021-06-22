using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class ManagerWorkers : BaseForm
    {
        DataGridViewRow selectedRow = null;

        public ManagerWorkers()
        {
            InitializeComponent();
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerMainWindow());
        }

        private void buttonAddWorker_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerWorkersManage(true));
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                int id = (int)selectedRow.Cells[0].Value;

                ChangeForm(this, new ManagerWorkersShow(id));
            }
        }

        private void ManagerWorkers_Load(object sender, EventArgs e)
        {
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'publicTransportDataSet.Employees' . Możesz go przenieść lub usunąć.
            employeesTableAdapter.Fill(this.publicTransportDataSet.Employees);

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
            string name = textBox1.Text;
            string surname = textBox2.Text;
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "name like '%" + name + "%' AND surname like '%" + surname + "%'";
            dataGridView1.DataSource = bs;
        }
    }
}

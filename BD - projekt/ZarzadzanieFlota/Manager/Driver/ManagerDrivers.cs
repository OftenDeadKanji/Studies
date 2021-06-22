using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class ManagerDrivers : BaseForm
    {
        DataGridViewRow selectedRow = null;
        DataTable dataTable = new DataTable();

        int indexId = 0, indexName = 1, indexSurname = 2;
        int indexDBId = 0, indexDBName = 1, indexDBSurname = 2, indexDBVehicle = 1;

        public ManagerDrivers()
        {
            InitializeComponent();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            dataTable.DefaultView.RowFilter = string.Format("[Imię] LIKE '%{0}%'", textBoxName.Text);
            dataTable.DefaultView.RowFilter = string.Format("[Nazwisko] LIKE '%{0}%'", textBoxSurname.Text);
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int type = -1;
            switch (comboBoxType.SelectedItem)
            {
                case "Autobus":
                    type = 0;
                    break;
                case "Tramwaj":
                    type = 1;
                    break;
                case "Trolejbus":
                    type = 2;
                    break;
                default:
                    type = -1;
                    break;
            }

            if (type >= 0)
            {
                dataTable.DefaultView.RowFilter = string.Format("[Pojazd] LIKE '%{0}%'", comboBoxType.SelectedItem);
            }
            else
            {
                dataTable.DefaultView.RowFilter = string.Format("");
            }
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerMainWindow());
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                int id = (int)selectedRow.Cells[indexId].Value;
                string name = selectedRow.Cells[indexName].Value.ToString();
                string surname = selectedRow.Cells[indexSurname].Value.ToString();
                ChangeForm(this, new ManagerDriverShow(id, name, surname));
            }
        }

        private void ManagerDrivers_Load(object sender, EventArgs e)
        {
            LoadData();
            if (dataGridView1.Rows.Count > 0)
            {
                selectedRow = dataGridView1.Rows[0];
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedRow = dataGridView1.SelectedRows[0];
            }
        }
                
        private void LoadData()
        {
            List<string[]> drivers = DBCommunicator.SelectFromDriversById(-1);
            string vehicle;

            if(drivers.Count > 0)
            {
                dataTable.Columns.Add("Id", typeof(int));
                dataTable.Columns.Add("Imię", typeof(string));
                dataTable.Columns.Add("Nazwisko", typeof(string));
                dataTable.Columns.Add("Pojazd", typeof(string));

                drivers.ForEach(delegate (string[] driver)
                {
                    vehicle = "";
                    List<string[]> employees = DBCommunicator.SelectFromEmployeesById(int.Parse(driver[indexDBId]));

                    if (employees.Count > 0)
                    {
                        if (int.Parse(driver[indexDBVehicle]).Equals((int)VehicleTypes.Bus))
                        {
                            vehicle = "Autobus";
                        }
                        else if (int.Parse(driver[indexDBVehicle]).Equals((int)VehicleTypes.NotABus))
                        {
                            vehicle = "Tramwaj";
                        }
                        else if (int.Parse(driver[indexDBVehicle]).Equals((int)VehicleTypes.MaybeBus))
                        {
                            vehicle = "Trolejbus";
                        }                        

                        dataTable.Rows.Add(driver[indexDBId], employees[0][indexDBName], employees[0][indexDBSurname], vehicle);
                    }
                });

                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns[indexDBId].Visible = false;
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class ManagerBusLine : BaseForm
    {
        DataGridViewRow selectedRow = null;
        DataTable dataTable = new DataTable();

        readonly int indexId = 2, indexLineNumber = 0, indexType = 1, indexVehicleType = 3;
        readonly int indexDbId = 0, indexDbLineNumber = 1, indexDbType = 2, indexDbVehicleType = 3;

        string typeFilter = "", vehicleFilter = "";

        public ManagerBusLine()
        {
            InitializeComponent();
            LoadData();
            comboBoxTypeFilter.SelectedIndex = comboBoxVehicleType.SelectedIndex = 0;
        }

        private void buttonReturn_Click_1(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerMainWindow());
        }

        private void buttonAddLine_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerBusLineManage(-1));
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                int id = (int)selectedRow.Cells[indexId].Value;
                ChangeForm(this, new ManagerBusLineShow(id));
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedRow = dataGridView1.SelectedRows[0];
            }
        }

        private void comboBoxVehicleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxVehicleType.SelectedItem)
            {
                case "Autobus":
                case "Tramwaj":
                case "Trolejbus":
                    vehicleFilter = "[Typ wymaganego pojazdu] LIKE '%" + comboBoxVehicleType.SelectedItem.ToString() + "%'";
                    break;
                default:
                    vehicleFilter = "";
                    break;
            }
            Filter();
        }

        private void comboBoxTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxTypeFilter.SelectedItem)
            {
                case "Zwykła":
                case "Nocna":
                    typeFilter = "[Typ] LIKE '%" + comboBoxTypeFilter.SelectedItem.ToString() + "%'";
                    break;
                default:
                    typeFilter = "";
                    break;
            }
            Filter();
        }

        private void Filter()
        {
            if (vehicleFilter.Equals("") && typeFilter.Equals(""))
            {
                dataTable.DefaultView.RowFilter = "";
            }
            else if (!vehicleFilter.Equals("") && typeFilter.Equals(""))
            {
                dataTable.DefaultView.RowFilter = vehicleFilter;
            }
            else if (vehicleFilter.Equals("") && !typeFilter.Equals(""))
            {
                dataTable.DefaultView.RowFilter = typeFilter;
            }
            else
            {
                dataTable.DefaultView.RowFilter = vehicleFilter + " AND " + typeFilter;
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            dataTable.DefaultView.RowFilter = "CONVERT([Numer linii], 'System.String') LIKE '%" + textBoxNumberFilter.Text + "%'";
        }

        private void LoadData()
        {
            var lines = DBCommunicator.SelectFromLinesById();
            string type, vehicleType;

            dataTable.Columns.Add("Numer linii", typeof(int));
            dataTable.Columns.Add("Typ", typeof(string));
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Typ wymaganego pojazdu", typeof(string));

            if (lines.Count > 0)
            {
                foreach (var line in lines)
                {
                    type = vehicleType = "";
                    switch (int.Parse(line[indexDbType]))
                    {
                        case (int)LineTypes.Normal:
                            type = "Zwykła";
                            break;
                        case (int)LineTypes.Night:
                            type = "Nocna";
                            break;
                        default:
                            type = "BŁĄD";
                            break;
                    }

                    switch (int.Parse(line[indexDbVehicleType]))
                    {
                        case (int)VehicleTypes.Bus:
                            vehicleType = "Autobus";
                            break;
                        case (int)VehicleTypes.NotABus:
                            vehicleType = "Tramwaj";
                            break;
                        case (int)VehicleTypes.MaybeBus:
                            vehicleType = "Trolejbus";
                            break;
                        default:
                            vehicleType = "BŁĄD";
                            break;
                    }
                    dataTable.Rows.Add(int.Parse(line[indexDbLineNumber]), type, int.Parse(line[indexDbId]), vehicleType);
                }

                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns[indexLineNumber].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[indexType].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[indexId].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[indexId].Visible = false;
                dataGridView1.Columns[indexVehicleType].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridView1.Sort(dataGridView1.Columns[indexLineNumber], System.ComponentModel.ListSortDirection.Ascending);
            }
        }
    }
}

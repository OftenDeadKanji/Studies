using System;
using System.Data;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class ManagerVehicles : BaseForm
    {
        DataGridViewRow selectedRow = null;
        DataTable dataTable = new DataTable();

        readonly int indexDBId = 0, indexDBReg = 1, indexDBSid = 2, indexDBTyp = 3, indexDBCap = 4;
        readonly int indexReg = 0, indexSid = 1, indexTyp = 2, indexCap = 3, indexId = 4;

        public ManagerVehicles()
        {
            InitializeComponent();
            LoadData();
            typeToSearch.SelectedIndex = 0;
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerMainWindow());
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            dataTable.DefaultView.RowFilter = string.Format("[Nr rejestracyjny] LIKE '%{0}%' AND [Nr boczny] LIKE '%{1}%'", regToSearch.Text, sideToSearch.Text);
        }

        private void buttonAddVehicle_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerVehicleManage(true));
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                string reg_no = "Błąd", side_no = "Błąd";
                int capacity = -1, type = 1, id = 0;

                if (selectedRow.Cells[indexId] != null)
                {
                    id = (int)selectedRow.Cells[indexId].Value;
                }
                if (selectedRow.Cells[indexReg] != null)
                {
                    reg_no = (string)selectedRow.Cells[indexReg].Value;
                }
                if (selectedRow.Cells[indexSid] != null)
                {
                    side_no = (string)selectedRow.Cells[indexSid].Value;
                }
                if (selectedRow.Cells[indexTyp] != null)
                {
                    switch(selectedRow.Cells[indexTyp].Value.ToString())
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
                            MessageBox.Show("Wystąpił nieoczekiwany błąd. Skontaktuj się z administratorem.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }
                }
                if (selectedRow.Cells[indexCap] != null)
                {
                    capacity = (int)selectedRow.Cells[indexCap].Value;
                }

                ManagerVehicleManage formNew = new ManagerVehicleManage(false, id, reg_no, side_no, type, capacity);
                ChangeForm(this, formNew);
            }
        }

        private void typeToSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (typeToSearch.SelectedItem)
            {
                case "Autobus":
                case "Tramwaj":
                case "Trolejbus":
                    dataTable.DefaultView.RowFilter = string.Format("[Typ pojazdu] LIKE '%{0}%'", typeToSearch.SelectedItem);
                    break;
                default:
                    dataTable.DefaultView.RowFilter = string.Format("");
                    break;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                if (selectedRow.Cells[indexId] != null)
                {
                    DialogResult answer = MessageBox.Show("Czy na pewno chcesz usunąć pojazd?.", "Zapytanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (answer == DialogResult.Yes)
                    {
                        int id = (int)selectedRow.Cells[indexId].Value;

                        DBCommunicator.DeleteFromVehiclesById(id);

                        LoadData();

                        MessageBox.Show("Baza danych została zaktualizowana.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("W celu usunięcie pojazdu należy zaznaczyć odpowiedni wiersz.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
            var vehicles = DBCommunicator.SelectFromVehiclesById();
            string type;

            dataTable.Columns.Add("Nr rejestracyjny", typeof(string));
            dataTable.Columns.Add("Nr boczny", typeof(string));
            dataTable.Columns.Add("Typ pojazdu", typeof(string));
            dataTable.Columns.Add("Pojemność", typeof(int));
            dataTable.Columns.Add("ID", typeof(int));

            if (vehicles.Count > 0)
            {
                foreach (var vehicle in vehicles)
                {
                    type = "";
                    switch (int.Parse(vehicle[indexDBTyp]))
                    {
                        case (int)VehicleTypes.Bus:
                            type = "Autobus";
                            break;
                        case (int)VehicleTypes.NotABus:
                            type = "Tramwaj";
                            break;
                        case (int)VehicleTypes.MaybeBus:
                            type = "Trolejbus";
                            break;
                        default:
                            type = "BŁĄD";
                            break;
                    }

                    dataTable.Rows.Add(vehicle[indexDBReg], vehicle[indexDBSid], type, int.Parse(vehicle[indexDBCap]), int.Parse(vehicle[indexDBId]));
                }

                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[4].Visible = false;
            }
        }
    }
}

using System;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class ManagerBusLineShow : BaseForm
    {
        private int lineId;
        DataGridViewRow selectedRow = null;

        public ManagerBusLineShow(int id)
        {
            InitializeComponent();
            
            lineId = id;
            comboBoxWeekday.SelectedIndex = 0;
            comboBoxDayType.SelectedIndex = 0;

            dataGridView.DataSource = DBCommunicator.GetTransits(lineId, comboBoxWeekday.SelectedIndex, comboBoxDayType.SelectedIndex);
            dataGridView.AllowUserToAddRows = false;

            #region ID - ukryta kolumna
            dataGridView.Columns[0].FillWeight = 8;
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[0].HeaderText = "ID";
            dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[0].ReadOnly = true;
            dataGridView.Columns[0].Visible = false;
            #endregion

            #region Przyst. początkowy.
            dataGridView.Columns[1].FillWeight = 33;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[1].HeaderText = "Przystanek początkowy";
            dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[1].ReadOnly = true;
            #endregion

            #region Przyst. końcowy
            dataGridView.Columns[2].FillWeight = 33;
            dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[2].HeaderText = "Przystanek końcowy";
            dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[2].ReadOnly = true;
            #endregion

            #region Nazwa
            dataGridView.Columns[3].FillWeight = 13;
            dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[3].HeaderText = "Czas przejazdu";
            dataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[3].ReadOnly = true;
            #endregion

            #region Czas przejazdu
            dataGridView.Columns[4].FillWeight = 13;
            dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[4].HeaderText = "Pref. pojemność";
            dataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[4].ReadOnly = true;
            #endregion

            var result = DBCommunicator.SelectFromLinesById(id)[0];
            textBoxLineNumber.Text = result[1];

            //tymczasowe rozwiązanie
            switch (int.Parse(result[2]))
            {
                case (int)LineTypes.Normal:
                    textBoxType.Text = "Zwykła";
                    break;
                case (int)LineTypes.Night:
                    textBoxType.Text = "Nocna";
                    break;
                default:
                    textBoxType.Text = "BŁĄD";
                    break;
            }
            switch (int.Parse(result[3]))
            {
                case (int)VehicleTypes.Bus:
                    textBoxVehicleType.Text = "Autobus";
                    break;
                case (int)VehicleTypes.NotABus:
                    textBoxVehicleType.Text = "Tramwaj";
                    break;
                case (int)VehicleTypes.MaybeBus:
                    textBoxVehicleType.Text = "Trolejbus";
                    break;
                default:
                    textBoxVehicleType.Text = "BŁĄD";
                    break;
            }
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                selectedRow = dataGridView.SelectedRows[0];
            }
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerBusLine());
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerBusLineManage(lineId));
        }

        private void buttonShowRide_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                ChangeForm(this, new ManagerTransitShow(int.Parse(selectedRow.Cells[0].Value.ToString())));
            }
        }

        private void buttonAddRide_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerTransitAdd(lineId, -1, -1));
        }

        private void comboBoxWeekday_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView.DataSource = DBCommunicator.GetTransits(lineId, comboBoxWeekday.SelectedIndex, comboBoxDayType.SelectedIndex);
        }

        private void comboBoxDayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView.DataSource = DBCommunicator.GetTransits(lineId, comboBoxWeekday.SelectedIndex, comboBoxDayType.SelectedIndex);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Czy na pewno chcesz usunąć linię? Spowoduje to usunięcie również wszystkich jej przejazdów i tras przypisanych tylko do tych przejazdów.", "Zapytanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer == DialogResult.Yes)
            {
                //usuwamy wszystkie przejazdy danej linii
                DBCommunicator.DeleteFromTransitsByLineId(lineId);

                //usuwamy "samotne" trasy
                var result = DBCommunicator.SelectAbandonedStopsOnRoute();

                foreach (var stop in result)
                {
                    string[] stopToDel = stop;
                    while (stopToDel != null)
                    {
                        var temp = stopToDel;

                        //stopToDel = stopToDel->next
                        stopToDel = stopToDel[2].Equals("") ? null : DBCommunicator.SelectFromStopsOnRouteById(int.Parse(stopToDel[2]))[0];

                        if (stopToDel != null)
                        {
                            //temp->next->prev = NULL
                            int nextNextId = stopToDel[2].Equals("") ? -1 : int.Parse(stopToDel[2]);

                            DBCommunicator.UpdateStopsOnRoute(int.Parse(stopToDel[0]), int.Parse(stopToDel[1]), nextNextId, -1, int.Parse(stopToDel[4]), int.Parse(stopToDel[5]));
                        }
                        DBCommunicator.DeleteFromStopsOnRouteById(int.Parse(temp[0]));
                    }
                }

                //usuwamy linię
                DBCommunicator.DeleteFromLinesById(lineId);

                ChangeForm(this, new ManagerBusLine());
                MessageBox.Show("Baza danych została zaktualizowana.");
            }
        }
    }
}

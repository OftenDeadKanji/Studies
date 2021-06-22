using System;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class ManagerBusLineManage : BaseForm
    {
        private int lineId;

        public ManagerBusLineManage(int id)
        {
            InitializeComponent();
            comboBoxType.SelectedIndex = comboBoxVehicleType.SelectedIndex = 0;

            if (id < 0)
            {
                lineId = -1;
            }
            else
            {
                lineId = id;
                var result = DBCommunicator.SelectFromLinesById(lineId)[0];

                textBoxNumber.Text = result[1];
                comboBoxType.SelectedIndex = int.Parse(result[2]);
                comboBoxVehicleType.SelectedIndex = int.Parse(result[3]);
            }
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            if (lineId != -1)
            {
                ChangeForm(this, new ManagerBusLineShow(lineId));
            }
            else
            {
                ChangeForm(this, new ManagerBusLine());
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (lineId != -1)
                {
                    DBCommunicator.UpdateLines(lineId, int.Parse(textBoxNumber.Text), comboBoxType.SelectedIndex, comboBoxVehicleType.SelectedIndex);
                    ChangeForm(this, new ManagerBusLineShow(lineId));
                }
                else
                {
                    int id = DBCommunicator.InsertIntoLines(int.Parse(textBoxNumber.Text), comboBoxType.SelectedIndex, comboBoxVehicleType.SelectedIndex);
                    ChangeForm(this, new ManagerBusLineShow(id));
                }

                MessageBox.Show("Baza danych została zaktualizowana.");
            }
            catch (FormatException)
            {
                MessageBox.Show("Błąd danych wejściowych!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

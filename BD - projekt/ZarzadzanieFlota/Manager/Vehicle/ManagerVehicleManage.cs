using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Data.Common;

namespace ZarzadzanieFlota
{
    public partial class ManagerVehicleManage : BaseForm
    {
        private bool doWeAddNew;
        private string registrationNumber, side_no;
        private int capacity, type, id;

        public ManagerVehicleManage(bool doWeAddNew, int id = 0, string registration = "", string side_no = "", int type = 1, int capacity = 30)
        {
            InitializeComponent();

            this.doWeAddNew = doWeAddNew;
            this.id = id;
            this.registrationNumber = registration;
            this.side_no = side_no;
            this.capacity = capacity;
            this.type = type;

            if (!doWeAddNew)
            {
                textBoxRegistrationNumber.Text = this.registrationNumber;
                numericCapacity.Value = this.capacity;
                textBoxSideNumber.Text = this.side_no;
                comboBoxType.SelectedIndex = this.type;
            }
            else
            {
                buttonSubmit.Text = "dodaj";
            }
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            if (doWeAddNew)
            {
                ChangeForm(this, new ManagerVehicles());
            }
            else
            {
                //ManagerVehicleShow formNew = new ManagerVehicleShow(id, registrationNumber, side_no, type, capacity);
                ManagerVehicles formNew = new ManagerVehicles();
                ChangeForm(this, formNew);
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (doWeAddNew)
            {
                var allVehicles = DBCommunicator.SelectFromVehiclesById();
                foreach(var vehicle in allVehicles)
                {
                    if(vehicle[1].Equals(textBoxRegistrationNumber.Text) || vehicle[2].Equals(textBoxSideNumber.Text))
                    {
                        MessageBox.Show("Numer rejestracyjny oraz boczny muszą być unikalne!", "Powtórzenie danych!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                if (comboBoxType.SelectedIndex == -1)
                {
                    MessageBox.Show("Należy wybrać typ pojazdu.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DBCommunicator.InsertIntoVehicles(textBoxRegistrationNumber.Text, textBoxSideNumber.Text, comboBoxType.SelectedIndex, decimal.ToInt32(numericCapacity.Value));

                    ChangeForm(this, new ManagerVehicles());
                    MessageBox.Show("Baza danych została zaktualizowana.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                DBCommunicator.UpdateVehicles(id, textBoxRegistrationNumber.Text, textBoxSideNumber.Text, comboBoxType.SelectedIndex, decimal.ToInt32(numericCapacity.Value));

                ChangeForm(this, new ManagerVehicles());
                MessageBox.Show("Baza danych została zaktualizowana.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}

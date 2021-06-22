using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ZarzadzanieFlota
{
    public partial class ManagerWorkersShow : BaseForm
    {
        int workerId;
        bool itIsDriver = false;

        public ManagerWorkersShow(int id)
        {
            InitializeComponent();

            workerId = id;

            setControlsText();
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerWorkers());
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show("Czy chcesz na pewno chcesz usunąć tego pracownika? Jeśli jest on również kierowcą to zostanie usunięty ze wszelkich kursów, w których aktualnie występuje.", "Zapytanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                if (itIsDriver)
                {
                    DBCommunicator.DeleteFromDriversById(workerId);
                }
                int result = DBCommunicator.DeleteFromEmployeesById(workerId);

                if (result == 1)
                    MessageBox.Show("Pomyślnie usunięto pracownika.");

                ChangeForm(this, new ManagerWorkers());
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerWorkersManage(false, workerId));
        }

        private void setControlsText()
        {
            List<string[]> workerData = DBCommunicator.SelectFromEmployeesById(workerId);

            if (workerData.Count > 0)
            {
                textBoxName.Text = workerData[0][1];
                textBoxSurname.Text = workerData[0][2];
                textBoxPhone.Text = workerData[0][3];
                textBoxMail.Text = workerData[0][4];
                textBoxLogin.Text = workerData[0][5];
                textBoxPassword.Text = workerData[0][6];
            }

            List<string[]> driverData = DBCommunicator.SelectFromDriversById(workerId);

            if (driverData.Count > 0)
            {
                itIsDriver = true;
                int vehicle = -1;
                int.TryParse(driverData[0][1], out vehicle);

                if (vehicle == (int)VehicleTypes.Bus)
                {
                    textBoxVehicle.Text = "Autobus";
                }
                else if (vehicle == (int)VehicleTypes.NotABus)
                {
                    textBoxVehicle.Text = "Tramwaj";
                }
                else if (vehicle == (int)VehicleTypes.MaybeBus)
                {
                    textBoxVehicle.Text = "Trolejbus";
                }

                int shift = -1;
                int.TryParse(driverData[0][2], out shift);

                if(shift == (int)ShiftTypes.Morning)
                {
                    textBoxShift.Text = "Poranna";
                }
                else if(shift == (int)ShiftTypes.Afternoon)
                {
                    textBoxShift.Text = "Popołudniowa";
                }
                else if(shift == (int)ShiftTypes.Night)
                {
                    textBoxShift.Text = "Nocna";
                }

                textBoxShift.Visible = true;
                textBoxShift1.Visible = true;
            }
            else
            {
                textBoxVehicle.Text = "Brak";
            }
        }
    }
}

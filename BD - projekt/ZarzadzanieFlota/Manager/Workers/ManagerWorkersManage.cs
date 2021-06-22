using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ZarzadzanieFlota
{
    public partial class ManagerWorkersManage : BaseForm
    {
        bool doWeAddNew;
        int vehicleHeDrive = -1;
        int id;

        public ManagerWorkersManage(bool doWeAddNew, int id = -1)
        {
            this.doWeAddNew = doWeAddNew;
            InitializeComponent();

            this.id = id;
            if (doWeAddNew)
            {
                buttonSubmit.Text = "dodaj";
            }
            else
            {
                setControlsText();
            }
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            if (doWeAddNew)
            {
                ManagerWorkers formNew = new ManagerWorkers();
                ChangeForm(this, formNew);
            }
            else
            {
                ManagerWorkersShow formNew = new ManagerWorkersShow(id);
                ChangeForm(this, formNew);
            }

        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            int phone_no;

            if (Int32.TryParse(textBoxPhone.Text, out phone_no))
            {
                if (comboBoxVehicle.SelectedIndex >= 0 && comboBoxVehicle.SelectedIndex <= 3)
                {
                    if (comboBoxVehicle.SelectedIndex == 3)
                    {
                        //To nie jest kierowca
                        if (doWeAddNew)
                        {
                            //Dodajemy nowego pracownika do bazy danych
                            DBCommunicator.InsertIntoEmployees(textBoxName.Text, textBoxSurname.Text, phone_no, textBoxMail.Text, textBoxLogin.Text, textBoxPassword.Text);
                            MessageBox.Show("Dodano nowego pracownika.");
                            ChangeForm(this, new ManagerWorkers());
                        }
                        else
                        {
                            // Update bazy danych
                            int i = DBCommunicator.UpdateEmployees(id, textBoxName.Text, textBoxSurname.Text, phone_no, textBoxMail.Text, textBoxLogin.Text, textBoxPassword.Text);

                            if (vehicleHeDrive >= 0)
                            {
                                // To był kierowca i przestał nim być
                                DBCommunicator.DeleteFromDriversById(id);
                            }

                            MessageBox.Show("Dane zostały zaktualizowane.");
                            ChangeForm(this, new ManagerWorkersShow(id));
                        }
                    }
                    else
                    {
                        if (comboBoxShift.SelectedIndex >= 0 && comboBoxShift.SelectedIndex <= 2)
                        {
                            //To jest kierowca
                            if (doWeAddNew)
                            {
                                //Dodajemy nowego pracownika i kierowcę do bazy danych
                                id = DBCommunicator.InsertIntoEmployees(textBoxName.Text, textBoxSurname.Text, phone_no, textBoxMail.Text, textBoxLogin.Text, textBoxPassword.Text);

                                DBCommunicator.InsertIntoDrivers(id, comboBoxVehicle.SelectedIndex, comboBoxShift.SelectedIndex);
                                MessageBox.Show("Dodano nowego kierowcę.");
                                ChangeForm(this, new ManagerWorkers());
                            }
                            else
                            {
                                //Update bazy danych
                                DBCommunicator.UpdateEmployees(id, textBoxName.Text, textBoxSurname.Text, phone_no, textBoxMail.Text, textBoxLogin.Text, textBoxPassword.Text);

                                if (vehicleHeDrive >= 0)
                                {
                                    // To był kierowca
                                    DBCommunicator.UpdateDrivers(id, comboBoxVehicle.SelectedIndex, comboBoxShift.SelectedIndex);
                                }
                                else
                                {
                                    // Został kierowcą
                                    DBCommunicator.InsertIntoDrivers(id, comboBoxVehicle.SelectedIndex, comboBoxShift.SelectedIndex);
                                }

                                MessageBox.Show("Dane zostały zaktualizowane.");
                                ChangeForm(this, new ManagerWorkersShow(id));
                            }
                        }
                        else
                        {
                            //Źle wybrana zmiana
                            MessageBox.Show("Proszę poprawnie wybrać zmianę.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Proszę wybrać prawidłowy typ pojazdu.");
                }
            }
            else
            {
                MessageBox.Show("Proszę podać prawidłowy numer telefonu.");
            }
        }


        private void setControlsText()
        {
            List<string[]> workerData = DBCommunicator.SelectFromEmployeesById(id);

            if (workerData.Count > 0)
            {
                textBoxName.Text = workerData[0][1];
                textBoxSurname.Text = workerData[0][2];
                textBoxPhone.Text = workerData[0][3];
                textBoxMail.Text = workerData[0][4];
                textBoxLogin.Text = workerData[0][5];
                textBoxPassword.Text = workerData[0][6];
            }

            List<string[]> driverData = DBCommunicator.SelectFromDriversById(id);

            if (driverData.Count > 0)
            {
                int vehicle = 0;
                int.TryParse(driverData[0][1], out vehicle);
                this.vehicleHeDrive = vehicle;

                comboBoxVehicle.SelectedIndex = vehicle;

                int shift = 0;
                int.TryParse(driverData[0][2], out shift);

                comboBoxShift.SelectedIndex = shift;
            }
        }

        private void comboBoxVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxVehicle.SelectedIndex >= 0 &&  comboBoxVehicle.SelectedIndex <= 2)
            {
                comboBoxShift.Visible = true;
                textBoxShift.Visible = true;
            }
            else
            {
                comboBoxShift.Visible = false;
                textBoxShift.Visible = false;
            }
        }
    }
}

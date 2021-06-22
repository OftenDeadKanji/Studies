using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class Autorization : BaseForm
    {
        private bool areWeManager;

        public Autorization(bool areWeManager)
        {
            InitializeComponent();

            this.areWeManager = areWeManager;
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ChoosingProffesion());
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (areWeManager)
            {
                string log = "admin";
                string pas = "admin";

                if (textBoxLogin.Text == log && textBoxPassword.Text == pas)
                {
                    ManagerMainWindow formNew = new ManagerMainWindow();
                    ChangeForm(this, formNew);
                }
                else
                {
                    bool logged = false
                        ;
                    List<string[]> employees = DBCommunicator.SelectFromEmployeesByLogin(textBoxLogin.Text);


                    if (employees != null)
                    {
                        if (employees.Count > 0)
                        {
                            int id;
                            employees.ForEach(delegate (string[] data)
                            {
                                id = -3;
                                Int32.TryParse(data[0], out id);
                                List<string[]> drivers = DBCommunicator.SelectFromDriversById(id);
                                if (drivers != null)
                                {
                                    if (drivers.Count <= 0)
                                    {
                                        if (data[6] == textBoxPassword.Text)
                                        {
                                            logged = true;
                                            ManagerMainWindow formNew = new ManagerMainWindow();
                                            ChangeForm(this, formNew);
                                        }
                                    }
                                }
                            });
                        }
                    }

                    if (!logged)
                    {
                        ChoosingProffesion formNew = new ChoosingProffesion();
                        ChangeForm(this, formNew);
                    }
                }
            }
            else
            {
                bool logged = false;

                List<string[]> employees = DBCommunicator.SelectFromEmployeesByLogin(textBoxLogin.Text);


                if (employees != null)
                {
                    if (employees.Count > 0)
                    {
                        int id;
                        employees.ForEach(delegate (string[] data)
                        {
                            id = -3;
                            Int32.TryParse(data[0], out id);
                            List<string[]> drivers = DBCommunicator.SelectFromDriversById(id);

                            if (drivers != null)
                            {
                                if (drivers.Count > 0)
                                {
                                    if (data[6] == textBoxPassword.Text)
                                    {
                                        logged = true;
                                        DriverMainWindow formNew = new DriverMainWindow(id);
                                        ChangeForm(this, formNew);
                                    }
                                }
                            }
                        });
                    }
                }

                if(!logged)
                {
                    ChoosingProffesion formNew = new ChoosingProffesion();
                    ChangeForm(this, formNew);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class ManagerCourseChangeDriver : BaseForm
    {
        DataGridViewRow selectedRow = null;
        DataTable dataTable = new DataTable();

        int indexId = 0, indexName = 1, indexSurname = 2;
        int indexDBId = 0, indexDBName = 1, indexDBSurname = 2, indexDBVehicle = 1;

        int courseId;
        string driver, vehicle, transit;
        DateTime date;
        int vehicleType = 0;

        public ManagerCourseChangeDriver(int courseId, string driver, string vehicle, string transit, DateTime date, int vehicleType)
        {
            InitializeComponent();

            this.courseId = courseId;
            this.driver = driver;
            this.vehicle = vehicle;
            this.transit = transit;
            this.date = date;
            this.vehicleType = vehicleType;

            LoadData();

            switch (vehicleType)
            {
                case 0:
                    dataTable.DefaultView.RowFilter = "[Pojazd] LIKE '%Autobus%'";
                    break;
                case 1:
                    dataTable.DefaultView.RowFilter = "[Pojazd] LIKE '%Tramwaj%'";
                    break;
                case 2:
                    dataTable.DefaultView.RowFilter = "[Pojazd] LIKE '%Trolejbus%'";
                    break;
                default:
                    dataTable.DefaultView.RowFilter = "";

                    break;
            }
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                var course = DBCommunicator.SelectFromCoursesById(courseId)[0];
                DBCommunicator.UpdateCourses(courseId, int.Parse(selectedRow.Cells[indexId].Value.ToString()), int.Parse(course[2]), int.Parse(course[3]), DateTime.Parse(course[4]));
                string newDriver = selectedRow.Cells[indexName].Value.ToString() + ' ' + selectedRow.Cells[indexSurname].Value.ToString();
                ChangeForm(this, new ManagerCourseManage(courseId, newDriver, vehicle, transit, date));
            }
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            dataTable.DefaultView.RowFilter = string.Format("[Imię] LIKE '%{0}%'", textBoxName.Text);
            dataTable.DefaultView.RowFilter = string.Format("[Nazwisko] LIKE '%{0}%'", textBoxSurname.Text);
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {/*
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
            }*/
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedRow = dataGridView1.SelectedRows[0];
            }
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerCourseManage(courseId, driver, vehicle, transit, date));
        }

        private void LoadData()
        {
            List<string[]> drivers = DBCommunicator.SelectFromDriversById(-1);
            string vehicle;

            if (drivers.Count > 0)
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

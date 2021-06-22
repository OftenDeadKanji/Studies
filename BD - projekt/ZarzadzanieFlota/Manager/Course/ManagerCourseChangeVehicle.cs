using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class ManagerCourseChangeVehicle : BaseForm
    {
        DataGridViewRow selectedRow = null;
        DataTable dataTable = new DataTable();

        readonly int indexDBId = 0, indexDBReg = 1, indexDBSid = 2, indexDBTyp = 3, indexDBCap = 4;
        readonly int indexReg = 0, indexSid = 1, indexTyp = 2, indexCap = 3, indexId = 4;

        private void buttonAddVehicle_Click(object sender, EventArgs e)
        {
            var course = DBCommunicator.SelectFromCoursesById(courseId)[0];
            DBCommunicator.UpdateCourses(courseId, int.Parse(course[1]), int.Parse(selectedRow.Cells[indexId].Value.ToString()), int.Parse(course[3]), DateTime.Parse(course[4]));
            string newVehicle = selectedRow.Cells[indexReg].Value.ToString();
            ChangeForm(this, new ManagerCourseManage(courseId, driver, newVehicle, transit, date));
        }

        int courseId;
        string driver, vehicle, transit;
        DateTime date;
        int vehicleType = 0;

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerCourseManage(courseId, driver, vehicle, transit, date));
        }


        public ManagerCourseChangeVehicle(int courseId, string driver, string vehicle, string transit, DateTime date, int vehicleType)
        {
            InitializeComponent();

            this.courseId = courseId;
            this.driver = driver;
            this.vehicle = vehicle;
            this.transit = transit;
            this.date = date;
            this.vehicleType = vehicleType;

            LoadData();

            switch (this.vehicleType)
            {
                case 0:
                    dataTable.DefaultView.RowFilter = "[Typ pojazdu] LIKE '%Autobus%'";
                    break;
                case 1:
                    dataTable.DefaultView.RowFilter = "[Typ pojazdu] LIKE '%Tramwaj%'";
                    break;
                case 2:
                    dataTable.DefaultView.RowFilter = "[Typ pojazdu] LIKE '%Trolejbus%'";
                    break;
                default:
                    dataTable.DefaultView.RowFilter = "";
                    break;
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

using System;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class ManagerCourseManage : BaseForm
    {
        private int courseId;
        string driver, vehicle, transit;
        int vehicleType = 0;
        DateTime date;

        public ManagerCourseManage(int courseId, string driver, string vehicle, string transit, DateTime date)
        {
            InitializeComponent();

            this.courseId = courseId;
            textBoxDriver.Text = this.driver = driver;
            textBoxVehicle.Text = this.vehicle = vehicle;
            textBoxTransit.Text = this.transit = transit;
            this.date = date;
            textBoxDate.Text = date.ToShortDateString();

            var co = DBCommunicator.SelectFromCoursesById(courseId)[0];
            var tr = DBCommunicator.SelectFromTransitsById(int.Parse(co[3]))[0];
            var li = DBCommunicator.SelectFromLinesById(int.Parse(tr[1]))[0];

            vehicleType = int.Parse(li[3]);
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerCourses());
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerCourses());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerCourseChangeVehicle(courseId, driver, vehicle, transit, date, vehicleType));
        }

        private void delete_Click(object sender, EventArgs e)
        {

            var course = DBCommunicator.SelectFromCoursesById(courseId)[0];
            var transit = DBCommunicator.SelectFromTransitsById(int.Parse(course[3]))[0];

            DBCommunicator.DeleteFromAssignmentsByDriverIdDateStartTime(int.Parse(course[1]), DateTime.Parse(course[4]), TimeSpan.Parse(transit[6]));
            DBCommunicator.DeleteFromCoursesById(courseId);

            ChangeForm(this, new ManagerCourses());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerCourseChangeDriver(courseId, driver, vehicle, transit, date, vehicleType));
        }
    }
}

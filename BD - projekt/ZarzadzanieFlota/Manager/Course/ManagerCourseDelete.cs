using System;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class ManagerCourseDelete : BaseForm
    {
        private DateTime _startDate;
        private DateTime _endDate;

        public ManagerCourseDelete()
        {
            InitializeComponent();
            _startDate = this.startDate.Value.Date;
            _endDate = this.endDate.Value.Date;
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerCourses());
        }

        private void startDate_ValueChanged(object sender, EventArgs e)
        {
            _startDate = this.startDate.Value.Date;
        }

        private void endDate_ValueChanged(object sender, EventArgs e)
        {
            _endDate = this.endDate.Value.Date;
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            DeleteCourses();
            ChangeForm(this, new ManagerCourses());
        }

        private void DeleteCourses()
        {
            _endDate.AddHours(23);
            _endDate.AddMinutes(59);
            _endDate.AddSeconds(59);
            _endDate.AddMilliseconds(999);

            int result = DBCommunicator.DeleteFromCoursesByDates(_startDate, _endDate);
            DBCommunicator.DeleteFromAssignmentsByDates(_startDate, _endDate);

            MessageBox.Show("Liczba usuniętych kursów: " + result.ToString());
        }
    }
}

using System;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class ManagerDriverAbsence : BaseForm
    {
        private int driverId;
        private string driverName, driverSurname;

        public ManagerDriverAbsence(int driverId, string driverName, string driverSurname)
        {
            this.driverId = driverId;
            this.driverName = driverName;
            this.driverSurname = driverSurname;

            InitializeComponent();
            SetControlsText();
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerDriverShow(driverId, driverName, driverSurname));
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DBCommunicator.DeleteFromAssignmentsByDates(dateTimePicker.Value.Date, dateTimePicker.Value.Date);
            DBCommunicator.UpdateCourses_DeleteDriverOnDate(driverId, dateTimePicker.Value.Date);
            int i = DBCommunicator.InsertIntoAbsences(dateTimePicker.Value, driverId);
            //TODO Komunikat
            MessageBox.Show("Dodano nową nieobecność o id " + i);

            //ChangeForm(this, new ManagerDriverShow(driverId, driverName, driverSurname));
        }

        private void SetControlsText()
        {
            textBoxName.Text = driverName;
            textBoxSurname.Text = driverSurname;
        }
    }
}

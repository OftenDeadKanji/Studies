using System;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class ManagerMainWindow : BaseForm
    {
        public ManagerMainWindow()
        {
            InitializeComponent();
        }

        private void buttonBusLine_Click(object sender, EventArgs e)
        {
            ManagerBusLine formNew = new ManagerBusLine();
            ChangeForm(this, formNew);
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            ChoosingProffesion formNew = new ChoosingProffesion();
            ChangeForm(this, formNew);
        }

        private void buttonVehicles_Click(object sender, EventArgs e)
        {
            ManagerVehicles formNew = new ManagerVehicles();
            ChangeForm(this, formNew);
        }

        private void buttonBusStops_Click(object sender, EventArgs e)
        {
            ManagerBusStops formNew = new ManagerBusStops();
            ChangeForm(this, formNew);
        }

        private void buttonRoutes_Click(object sender, EventArgs e)
        { 
            ManagerWorkers formNew = new ManagerWorkers();
            ChangeForm(this, formNew);
        }

        private void buttonDrivers_Click(object sender, EventArgs e)
        {
            ManagerDrivers formNew = new ManagerDrivers();
            ChangeForm(this, formNew);
        }

        private void buttonReturn_Click_1(object sender, EventArgs e)
        {
            ChoosingProffesion formNew = new ChoosingProffesion();
            ChangeForm(this, formNew);
        }

        private void buttonCourses_Click(object sender, EventArgs e)
        {
            ManagerCourses formNew = new ManagerCourses();
            ChangeForm(this, formNew);
        }
    }
}

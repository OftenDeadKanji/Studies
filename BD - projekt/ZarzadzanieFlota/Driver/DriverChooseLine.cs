using System;
using System.Collections.Generic;

namespace ZarzadzanieFlota
{
    public partial class DriverChooseLine : BaseForm
    {
        private int driverId;
        private string driverName, driverSurname;
        private List<int> assigmentsIds, lines;

        public DriverChooseLine(int driverId, string driverName, string driverSurname, List<int> assigmentsIds, List<int> lines)
        {
            this.driverId = driverId;
            this.driverName = driverName;
            this.driverSurname = driverSurname;
            this.assigmentsIds = assigmentsIds;
            this.lines = lines;
            InitializeComponent();

            lines.ForEach(delegate (int line)
            {
                comboBoxLine.Items.Add(line);
            });
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new DriverMainWindow(driverId, driverName, driverSurname));
        }

        private void buttonChoose_Click(object sender, EventArgs e)
        {
            if (comboBoxLine.SelectedIndex > -1)
            {
                int id = assigmentsIds[comboBoxLine.SelectedIndex];
                ChangeForm(this, new DriverTimetable(driverId, driverName, driverSurname, id));
            }
        }
    }
}

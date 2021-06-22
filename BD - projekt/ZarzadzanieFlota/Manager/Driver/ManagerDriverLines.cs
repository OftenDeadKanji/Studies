using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class ManagerDriverLines : BaseForm
    {
        private int driverId;
        private string driverName, driverSurname;
        private List<int> assigmentsIds, lines;

        public ManagerDriverLines(int driverId, string driverName, string driverSurname, List<int> assigmentsIds, List<int> lines)
        {
            this.driverId = driverId;
            this.driverName = driverName;
            this.driverSurname = driverSurname;
            this.assigmentsIds = assigmentsIds;
            this.lines = lines;
            InitializeComponent();
        }

        private void ManagerDriverLines_Load(object sender, EventArgs e)
        {
            lines.ForEach(delegate (int line)
            {
                comboBoxLine.Items.Add(line);
            });
        }

        private void buttonChoose_Click(object sender, EventArgs e)
        {
            if (comboBoxLine.SelectedIndex > -1)
            {
                int id = assigmentsIds[comboBoxLine.SelectedIndex];
                ChangeForm(this, new ManagerDriverAssigments(driverId, driverName, driverSurname, id));
            }
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerDriverShow(driverId, driverName, driverSurname));
        }
    }
}

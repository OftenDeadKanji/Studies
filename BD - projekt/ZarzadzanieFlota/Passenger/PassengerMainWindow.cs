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
    public partial class PassengerMainWindow : BaseForm
    {
        public PassengerMainWindow()
        {
            InitializeComponent();
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            ChoosingProffesion formNew = new ChoosingProffesion();
            ChangeForm(this, formNew);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            PassengerSearch formNew = new PassengerSearch();
            ChangeForm(this, formNew);
        }

        private void buttonTimetable_Click(object sender, EventArgs e)
        {
            PassengerTimetable formNew = new PassengerTimetable();
            ChangeForm(this, formNew);
        }
    }
}

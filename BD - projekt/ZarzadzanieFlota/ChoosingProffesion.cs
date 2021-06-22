using System;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{

    public partial class ChoosingProffesion : BaseForm
    {
        public ChoosingProffesion()
        {
            InitializeComponent();
            int x = this.Size.Width;
            int y = this.Size.Height;
            int xzx = 1;
        }

        private void buttonManager_Click(object sender, EventArgs e)
        {   
            Autorization formNew = new Autorization(true);
            ChangeForm(this, formNew);
        }

        private void buttonDriver_Click(object sender, EventArgs e)
        {
            Autorization formNew = new Autorization(false);
            ChangeForm(this, formNew);
        }

        private void buttonPassenger_Click(object sender, EventArgs e)
        {
            PassengerMainWindow formNew = new PassengerMainWindow();
            ChangeForm(this, formNew);
        }
    }
}

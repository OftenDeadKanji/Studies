using System;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class ManagerDriverManage : BaseForm
    {
        private bool doWeAddNew;
        private int driverId = 0;

        public ManagerDriverManage(bool doWeAddNew, int driverId, string name, string surname)
        {
            this.doWeAddNew = doWeAddNew;

            InitializeComponent();

            this.driverId = driverId;
            textBoxName.Text = name + " " + surname;

            if (doWeAddNew)
            {
                buttonSubmit.Text = "dodaj";
                buttonDelete.Hide();
            }
            else
            {
                buttonDelete.Show();
            }
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            ManagerDriverShow formNew = new ManagerDriverShow(driverId, "Jan", "kowalski");
            ChangeForm(this, formNew);
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Baza danych została zaktualizowana.");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            ManagerDriverShow formNew = new ManagerDriverShow(driverId, "Jan", "kowalski");
            ChangeForm(this, formNew);

            MessageBox.Show("Baza danych została zaktualizowana.");
        }
    }
}

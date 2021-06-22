using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class ManagerVehicleShow : BaseForm
    {
        private string registrationNumber;
        private string side_no;
        private int type, capacity, id;

        public ManagerVehicleShow(int id, string registration, string side_no, int type, int capacity)
        {
            InitializeComponent();

            this.id = id;
            this.registrationNumber = registration;
            this.side_no = side_no;
            this.type = type;
            this.capacity = capacity;

            textBoxRegistrationNumber.Text = registrationNumber;
            textBoxCapacity.Text = capacity.ToString();
            textBoxSideNumber.Text = side_no;
            comboBoxType.SelectedIndex = type;
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            ManagerVehicles formNew = new ManagerVehicles();
            ChangeForm(this, formNew);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            ManagerVehicleManage formNew = new ManagerVehicleManage(false, id, registrationNumber, side_no, type, capacity);
            ChangeForm(this, formNew);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int i = DBCommunicator.DeleteFromVehiclesById(id);

            ChangeForm(this, new ManagerVehicles());

            MessageBox.Show("Usunięto elementy: " + i.ToString());
        }
    }
}

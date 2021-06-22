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
    public partial class ManagerRouteManage : BaseForm
    {
        private bool doWeAddNew;
        private int routeId
            ;
        public ManagerRouteManage(bool doWeAddNew, int routeId = 0)
        {
            InitializeComponent();

            this.doWeAddNew = doWeAddNew;
            this.routeId = routeId;
            //DBCommunicator.SelectFromRouteByFirstAndLastStopId

        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            if (doWeAddNew)
            {
                ManagerRoutes formNew = new ManagerRoutes(1);
                ChangeForm(this, formNew);
            }
            else
            {
                ManagerRouteShow formNew = new ManagerRouteShow(routeId);
                ChangeForm(this, formNew);
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Baza danych została zaktualizowana.");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ManagerRouteManageAddStop formAdditional = new ManagerRouteManageAddStop(0, 0, 0, dataGridView1.Rows.Count);
            formAdditional.Show();
        }
    }
}

using System;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class ManagerRouteShow : BaseForm
    {
        private int transitId, firstStopOnRouteId;

        public ManagerRouteShow(int transitId)
        {
            InitializeComponent();
            this.transitId = transitId;

            if (transitId < 1 )
            {
                firstStopOnRouteId = -1;
                dataGridView1.DataSource = DBCommunicator.GetRouteByFirstStopId(0);
            }
            else
            {
                var result = DBCommunicator.SelectFromTransitsById(transitId)[0];
                firstStopOnRouteId = int.Parse(result[2]);
                dataGridView1.DataSource = DBCommunicator.GetRouteByFirstStopId(firstStopOnRouteId);
            }

            dataGridView1.AllowUserToAddRows = false;

            #region ID - ukryte
            dataGridView1.Columns[0].FillWeight = 1;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[0].Visible = false;
            #endregion

            #region L.p.
            dataGridView1.Columns[1].FillWeight = 10;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].HeaderText = "L.p.";
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].ReadOnly = true;
            #endregion

            #region Dzielnica
            dataGridView1.Columns[2].FillWeight = 40;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].HeaderText = "Dzielnica";
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].ReadOnly = true;
            #endregion

            #region Nazwa
            dataGridView1.Columns[3].FillWeight = 40;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].HeaderText = "Nazwa";
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].ReadOnly = true;
            #endregion

            #region Czas przejazdu
            dataGridView1.Columns[4].FillWeight = 10;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].HeaderText = "Czas przejazdu";
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].ReadOnly = true;
            #endregion
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerTransitShow(transitId));
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var result = DBCommunicator.SelectFromTransitsById(transitId)[0];
            
            int lineId = int.Parse(result[1]);
            int first = int.Parse(result[2]);
            int last = int.Parse(result[3]);

            ChangeForm(this, new ManagerRouteAdd(lineId, first, last, false, transitId));
        }
    }
}

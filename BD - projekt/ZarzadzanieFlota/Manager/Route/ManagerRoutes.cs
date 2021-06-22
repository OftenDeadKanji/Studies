using System;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class ManagerRoutes : BaseForm
    {
        int transitId, lineId, firstStop, lastStop;

        DataGridViewRow selectedRow = null;

        public ManagerRoutes(int transitId = -1, int lineId = -1, int firstStop = -1, int lastStop = -1)
        {
            InitializeComponent();
            dataGridView1.DataSource = DBCommunicator.GetRoutesAsFirstAndLastStops();

            #region ID pierwszego - ukryte
            dataGridView1.Columns[0].FillWeight = 1;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[0].HeaderText = "ID przystanku początkowego";
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[0].Visible = false;
            #endregion

            #region Przystanek początkowy
            dataGridView1.Columns[1].FillWeight = 50;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].HeaderText = "Przystanek początkowy";
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].ReadOnly = true;
            #endregion

            #region ID ostatniego - ukryte
            dataGridView1.Columns[2].FillWeight = 1;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].HeaderText = "ID przystanku końcowego";
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[2].Visible = false;
            #endregion

            #region Przystanek końcowy
            dataGridView1.Columns[3].FillWeight = 50;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].HeaderText = "Przystanek końcowy";
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].ReadOnly = true;
            #endregion

            if (transitId > 0)
            {
                this.transitId = transitId;
            }
            else if (lineId > 0)
            {
                this.lineId = lineId;
                this.firstStop = firstStop;
                this.lastStop = lastStop;
            }
            else
            {
                ChangeForm(this, new ManagerMainWindow());
                MessageBox.Show("Coś poszło nie tak.... Jak się tam znalazłeś?");
            }
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            if (transitId > 0)
            {
                ChangeForm(this, new ManagerTransitManage(transitId));
            }
            else if (lineId > 0)
            {
                ChangeForm(this, new ManagerTransitAdd(lineId, firstStop, lastStop));
            }
        }

        private void buttonChoose_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                int first = int.Parse(selectedRow.Cells[0].Value.ToString());
                int last = int.Parse(selectedRow.Cells[2].Value.ToString());
                if (transitId > 0)
                {
                    var transit = DBCommunicator.SelectFromTransitsById(transitId)[0];

                    DBCommunicator.UpdateTransits(int.Parse(transit[0]), int.Parse(transit[1]), first, last, int.Parse(transit[4]), int.Parse(transit[5]), DateTime.Parse(transit[6]), int.Parse(transit[7]));

                    ChangeForm(this, new ManagerTransitManage(transitId));
                }
                else
                {
                    ChangeForm(this, new ManagerTransitAdd(lineId, first, last));
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedRow = dataGridView1.SelectedRows[0];
            }
        }
    }
}

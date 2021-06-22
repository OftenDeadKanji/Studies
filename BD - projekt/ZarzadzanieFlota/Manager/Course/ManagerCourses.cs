using System;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class ManagerCourses : BaseForm
    {
        DataGridViewRow selectedRow = null;

        public ManagerCourses()
        {
            InitializeComponent();
            dataGridView.DataSource = DBCommunicator.GetCourses();

            #region ID - ukryta kolumna
            dataGridView.Columns[0].FillWeight = 1;
            dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[0].HeaderText = "ID";
            dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[0].ReadOnly = true;
            dataGridView.Columns[0].Visible = false;
            #endregion

            #region Kierowca
            dataGridView.Columns[1].FillWeight = 20;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[1].HeaderText = "Kierowca";
            dataGridView.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[1].ReadOnly = true;
            #endregion

            #region Pojazd
            dataGridView.Columns[2].FillWeight = 30;
            dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[2].HeaderText = "Pojazd";
            dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[2].ReadOnly = true;
            #endregion

            #region Linia i trasa
            dataGridView.Columns[3].FillWeight = 30;
            dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[3].HeaderText = "Linia i trasa";
            dataGridView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[3].ReadOnly = true;
            #endregion

            #region Data
            dataGridView.Columns[4].FillWeight = 20;
            dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns[4].HeaderText = "Data";
            dataGridView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Columns[4].ReadOnly = true;
            #endregion
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                selectedRow = dataGridView.SelectedRows[0];
            }
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerMainWindow());
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                ChangeForm(this, new ManagerCourseManage(int.Parse(selectedRow.Cells[0].Value.ToString()), selectedRow.Cells[1].Value.ToString(), selectedRow.Cells[2].Value.ToString(), selectedRow.Cells[3].Value.ToString(), DateTime.Parse(selectedRow.Cells[4].Value.ToString())));
            }
        }

        private void buttonGen_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerCourseCreate());
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerCourseDelete());
        }
    }
}

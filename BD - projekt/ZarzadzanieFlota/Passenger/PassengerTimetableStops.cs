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
    public partial class PassengerTimetableStops : BaseForm
    {
        int idIndex = 0, typeIndex = 2, typeNameIndex = 3;
        string stopName;

        public PassengerTimetableStops()
        {
            InitializeComponent();
            List<string[]> stops = DBCommunicator.SelectFromStopsById();
            foreach(string[] stop in stops)
                comboBoxStops.Items.Add(stop[2] + " " + stop[1]);
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            PassengerMainWindow formNew = new PassengerMainWindow();
            ChangeForm(this, formNew);
        }

        private void PassengerTimetableStops_Load(object sender, EventArgs e)
        {
            //this.linesTableAdapter.Fill(this.publicTransportDataSet.Lines);
            dataGridView1.DataSource = DBCommunicator.GetLinesByStopId(-1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable d = DBCommunicator.GetLinesByStopId(this.comboBoxStops.SelectedIndex + 1);
            dataGridView1.DataSource = d;
            //BindingSource bs = new BindingSource();
            //bs.DataSource = dataGridView1.DataSource;
            //bs.Filter = condition;
            //dataGridView1.DataSource = bs;
        }

        private void textBoxType_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewTextBoxCell cellId = (DataGridViewTextBoxCell)
                    dataGridView1.Rows[e.RowIndex].Cells[idIndex];

                int lineId = -1;
                Int32.TryParse(cellId.Value.ToString(), out lineId);

                if (lineId >= 0)
                {
                    PassengerTimetableLine formNew = new PassengerTimetableLine(lineId);
                    ChangeForm(this, formNew);
                }
            }

        }

    }
}

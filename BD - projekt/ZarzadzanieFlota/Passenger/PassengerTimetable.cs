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
    public partial class PassengerTimetable : BaseForm
    {
        int idIndex = 0, typeIndex = 2, typeNameIndex = 3;

        public PassengerTimetable()
        {
            InitializeComponent();
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            PassengerMainWindow formNew = new PassengerMainWindow();
            ChangeForm(this, formNew);
        }

        private void PassengerTimetable_Load(object sender, EventArgs e)
        {
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'publicTransportDataSet.Lines' . Możesz go przenieść lub usunąć.
            this.linesTableAdapter.Fill(this.publicTransportDataSet.Lines);

            SetLineTypeColumnContent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int type;
            switch (comboBoxType.SelectedItem)
            {
                case "Zwykła":
                    type = 0;
                    break;
                case "Nocna":
                    type = 1;
                    break;
                case "Wszystkie":
                    type = 2;
                    break;
                default:
                    type = -1;
                    break;
            }
            string condition = "";
            if (type >= 0)
            {
                if(type == 2)
                {
                    condition = "";
                }
                else
                {
                    condition = "type = " + type;
                }
                BindingSource bs = new BindingSource();
                bs.DataSource = dataGridView1.DataSource;
                bs.Filter = condition;
                dataGridView1.DataSource = bs;

                SetLineTypeColumnContent();
            }
        }

        private void buttonStops_Click(object sender, EventArgs e)
        {
            PassengerTimetableStops formNew = new PassengerTimetableStops();
            ChangeForm(this, formNew);
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

        private void SetLineTypeColumnContent()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[typeIndex].Value.Equals(0))
                {
                    row.Cells[typeNameIndex].Value = "Zwykła";
                }
                else if (row.Cells[typeIndex].Value.Equals(1))
                {
                    row.Cells[typeNameIndex].Value = "Nocna";
                }
            }
        }
    }
}

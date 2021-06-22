using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ZarzadzanieFlota
{
    public partial class ManagerTimetableStops : BaseForm
    {
        int idIndex = 0;

        public ManagerTimetableStops()
        {
            InitializeComponent();
            List<string[]> stops = DBCommunicator.SelectFromStopsById();
            foreach(string[] stop in stops)
                comboBoxStops.Items.Add(stop[2] + " " + stop[1]);
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            ManagerBusStops formNew = new ManagerBusStops();
            ChangeForm(this, formNew);
        }

        private void ManagerTimetableStops_Load(object sender, EventArgs e)
        {
            //this.linesTableAdapter.Fill(this.publicTransportDataSet.Lines);
            dataGridView1.DataSource = DBCommunicator.GetLinesByStopId(-1);
        }

        private void buttonPDF_Click(object sender, EventArgs e)
        {
            //TODO: Znaleźć ten kod eksportu do PDFa, gdyż gdzieś się zapodział.
            string path = "timetables/" + this.comboBoxStops.SelectedItem + ".pdf";
            FileInfo file = new FileInfo(path);
            file.Directory.Create();

            PdfPTable pdfTable = new PdfPTable(3);
            PdfPCell lineCell = new PdfPCell(new Phrase("Linia"));
            pdfTable.AddCell(lineCell);
            PdfPCell typeCell = new PdfPCell(new Phrase("Typ"));
            pdfTable.AddCell(typeCell);
            PdfPCell timeCell = new PdfPCell(new Phrase("Odjazdy"));
            pdfTable.AddCell(timeCell);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    PdfPCell pdfCell = new PdfPCell(new Phrase(cell.Value.ToString()));
                    pdfTable.AddCell(pdfCell);
                }
            }

            Document document = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            PdfWriter.GetInstance(document, File.OpenWrite(path));
            document.Open();
            document.Add(pdfTable);
            document.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DBCommunicator.GetLinesByStopId(this.comboBoxStops.SelectedIndex + 1);
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

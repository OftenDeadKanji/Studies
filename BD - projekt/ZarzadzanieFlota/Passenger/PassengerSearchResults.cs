using iTextSharp.text;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class PassengerSearchResults : BaseForm
    {
        List<Tuple<string, int, int>> rawPath;
        DataTable pathPresentation = new DataTable();
        DateTime when;

        public PassengerSearchResults(DateTime whenSearch, string startStop, string endStop)
        {
            when = whenSearch;
            StopsGraph graph = new StopsGraph();
            rawPath = graph.Dijkstra(startStop, endStop, whenSearch);
            InitializeComponent();

            textBox4.Text = startStop;
            textBox5.Text = endStop;
            LoadPath();
            SetupDataGrid();
            
        }

        private void SetupDataGrid()
        {
            dataGridView1.DataSource = pathPresentation;
            foreach(DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            PassengerSearch formNew = new PassengerSearch();
            ChangeForm(this, formNew);
        }

        private void LoadPath()
        {
            pathPresentation.Columns.Add("Linia", typeof(string));
            pathPresentation.Columns.Add("Cel", typeof(string));
            pathPresentation.Columns.Add("Czas", typeof(int));
            
            if (rawPath != null)
            {
                Tuple<string, int, int> lastCon = null;
                int transitTime = 0;
                foreach (Tuple<string, int, int> connection in rawPath)
                {
                    if (connection.Item1.Equals("wait"))
                    {
                        
                        if (lastCon != null)
                        {
                            List<string[]> prevStops = DBCommunicator.SelectPreviousFromStopsOnRouteById(lastCon.Item3);
                            List<string[]> nextStops = DBCommunicator.SelectNextFromStopsOnRouteById(lastCon.Item3);
                            List<string[]> transits = DBCommunicator.SelectFromTransitsByRouteAndDateTime(when.AddMinutes((int)(-when.TimeOfDay.TotalMinutes)), int.Parse(prevStops[prevStops.Count - 1][0]), int.Parse(nextStops[nextStops.Count - 1][0]));
                            List<string[]> line = DBCommunicator.SelectFromLinesById(int.Parse(transits[0][1]));
                            pathPresentation.Rows.Add(line[0][1], lastCon.Item1, transitTime);
                        }
                        pathPresentation.Rows.Add("---", "Czekaj", connection.Item2);
                    }
                    else if (connection == rawPath[rawPath.Count - 1])
                    {
                        List<string[]> prevStops = DBCommunicator.SelectPreviousFromStopsOnRouteById(connection.Item3);
                        List<string[]> nextStops = DBCommunicator.SelectNextFromStopsOnRouteById(connection.Item3);
                        List<string[]> transits = DBCommunicator.SelectFromTransitsByRouteAndDateTime(when.AddMinutes((int)(-when.TimeOfDay.TotalMinutes)), int.Parse(prevStops[prevStops.Count - 1][0]), int.Parse(nextStops[nextStops.Count - 1][0]));
                        List<string[]> line = DBCommunicator.SelectFromLinesById(int.Parse(transits[0][1]));
                        pathPresentation.Rows.Add(line[0][1], connection.Item1, connection.Item2 + transitTime);
                    }
                    else
                    {
                        lastCon = connection;
                        transitTime += connection.Item2;
                    }
                }
            }
            else
            {
                pathPresentation.Rows.Add("---", "Brak Połączenia", 0);
            }
        }
    }
}

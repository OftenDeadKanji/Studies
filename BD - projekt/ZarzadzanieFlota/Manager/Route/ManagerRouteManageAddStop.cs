using System;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class ManagerRouteManageAddStop : BaseForm
    {
        DataGridViewRow selectedRow = null;
        private readonly int lineId;
        private int firstId, lastId;

        public ManagerRouteManageAddStop(int lineId, int firstId, int lastId, int currentStopsOnRouteCount)
        {
            InitializeComponent();

            this.lineId = lineId;
            this.firstId = firstId;
            this.lastId = lastId;

            newPlaceRange.Maximum = currentStopsOnRouteCount + 1;
            newPlaceRange.Minimum = 1;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedRow = dataGridView1.SelectedRows[0];
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerRouteAdd(lineId, firstId, lastId));
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // -1 - brak wybranego przystanku
            if (selectedRow != null)
            {
                var stopToAdd = DBCommunicator.SelectFromStopsById(int.Parse(selectedRow.Cells[0].Value.ToString()))[0];
                int newPlaceNumber = decimal.ToInt32(newPlaceRange.Value);

                AddStopOnRouteAtIndex(stopToAdd, newPlaceNumber);
            }

            ChangeForm(this, new ManagerRouteAdd(lineId, firstId, lastId));
        }

        private int AddStopOnRouteAtIndex(string[] stopToAdd, int index)
        {
            if (index < 0)
            {
                return -1;
            }
            else if (firstId == -1)
            {
                //wstawiamy pierwszy przystanek na tej trasie
                firstId = lastId = DBCommunicator.InsertIntoStopsOnRoute(int.Parse(stopToAdd[0]), -1, -1, 1, decimal.ToInt32(transitTime.Value));

                return firstId;
            }
            else
            {
                int id = firstId;
                bool endOfList = false;

                //przechodzenie po liście
                for (int i = 1; i < index; i++)
                {
                    var stop = DBCommunicator.SelectFromStopsOnRouteById(id)[0];

                    if (stop[2].Equals(""))
                    {
                        if (i < index - 1)
                        {
                            return -1;
                        }
                        else
                        {
                            endOfList = true;
                            break;
                        }
                    }

                    id = int.Parse(stop[2]);
                }

                //początek listy
                if (index == 1)
                {
                    var nextStopOnRoute = DBCommunicator.SelectFromStopsOnRouteById(id)[0];
                    int newlyAddedStopOnRouteId = DBCommunicator.InsertIntoStopsOnRoute(int.Parse(stopToAdd[0]), int.Parse(nextStopOnRoute[0]), -1, index, decimal.ToInt32(transitTime.Value));

                    firstId = newlyAddedStopOnRouteId;

                    int nextNextId = nextStopOnRoute[2].Equals("") ? -1 : int.Parse(nextStopOnRoute[2]);

                    DBCommunicator.UpdateStopsOnRoute(int.Parse(nextStopOnRoute[0]), int.Parse(nextStopOnRoute[1]), nextNextId, newlyAddedStopOnRouteId, int.Parse(nextStopOnRoute[4]), int.Parse(nextStopOnRoute[5]));
                    return newlyAddedStopOnRouteId;
                }
                //środek listy
                else if (!endOfList)
                {
                    var nextStopOnRoute = DBCommunicator.SelectFromStopsOnRouteById(id)[0];
                    var prevStopOnRoute = DBCommunicator.SelectFromStopsOnRouteById(int.Parse(DBCommunicator.SelectFromStopsOnRouteById(id)[0][3]))[0];

                    int newlyAddedStopOnRouteId = DBCommunicator.InsertIntoStopsOnRoute(int.Parse(stopToAdd[0]), int.Parse(nextStopOnRoute[0]), int.Parse(prevStopOnRoute[0]), index, decimal.ToInt32(transitTime.Value));

                    int prevPrevId = prevStopOnRoute[3].Equals("") ? -1 : int.Parse(prevStopOnRoute[3]);
                    int nextNextId = nextStopOnRoute[2].Equals("") ? -1 : int.Parse(nextStopOnRoute[2]);

                    DBCommunicator.UpdateStopsOnRoute(int.Parse(nextStopOnRoute[0]), int.Parse(nextStopOnRoute[1]), nextNextId, newlyAddedStopOnRouteId, int.Parse(nextStopOnRoute[4]), int.Parse(nextStopOnRoute[5]));
                    DBCommunicator.UpdateStopsOnRoute(int.Parse(prevStopOnRoute[0]), int.Parse(prevStopOnRoute[1]), newlyAddedStopOnRouteId, prevPrevId, int.Parse(prevStopOnRoute[4]), int.Parse(prevStopOnRoute[5]));

                    return newlyAddedStopOnRouteId;
                }
                //koniec listy
                else
                {
                    var prevStopOnRoute = DBCommunicator.SelectFromStopsOnRouteById(id)[0];
                    int newlyAddedStopOnRouteId = lastId = DBCommunicator.InsertIntoStopsOnRoute(int.Parse(stopToAdd[0]), -1, int.Parse(prevStopOnRoute[0]), index, decimal.ToInt32(transitTime.Value));

                    int prevPrevId = prevStopOnRoute[3].Equals("") ? -1 : int.Parse(prevStopOnRoute[3]);

                    DBCommunicator.UpdateStopsOnRoute(int.Parse(prevStopOnRoute[0]), int.Parse(prevStopOnRoute[1]), newlyAddedStopOnRouteId, prevPrevId, int.Parse(prevStopOnRoute[4]), int.Parse(prevStopOnRoute[5]));

                    return newlyAddedStopOnRouteId;
                }
            }
        }

        private void ManagerRouteManageAddStop_Load(object sender, EventArgs e)
        {
            this.stopsTableAdapter.Fill(this.publicTransportDataSet.Stops);
        }

        private void TextBoxDistrict_TextChanged(object sender, EventArgs e)
        {
            SetFilter();
        }
        private void TextBoxName_TextChanged(object sender, EventArgs e)
        {
            SetFilter();
        }

        private void SetFilter()
        {
            string district = textBoxDistrict.Text;
            string name = textBoxName.Text;

            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "district LIKE '%" + district + "%'" + " AND name LIKE '%" + name + "%'";

            dataGridView1.DataSource = bs;
        }

    }
}

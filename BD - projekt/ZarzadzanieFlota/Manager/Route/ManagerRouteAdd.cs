using System;
using System.Windows.Forms;

namespace ZarzadzanieFlota
{
    public partial class ManagerRouteAdd : BaseForm
    {
        DataGridViewRow selectedRow = null;

        readonly int lineId;
        int firstStopOnRouteId, lastStopOnRouteId;
        bool doWeAddnew;
        int transitId;
        int notNewMode;
        public ManagerRouteAdd(int lineId, int firstStopId, int lastStopId, bool doWeAddnew = true, int transitId = -1, int notNewMode = 1)
        {
            InitializeComponent();

            this.doWeAddnew = doWeAddnew;
            this.transitId = transitId;
            this.notNewMode = notNewMode;

            this.lineId = lineId;
            if (firstStopId < 1 || lastStopId < 1)
            {
                firstStopOnRouteId = lastStopOnRouteId = -1;
                dataGridView1.DataSource = DBCommunicator.GetRouteByFirstStopId(0);
            }
            else
            {
                firstStopOnRouteId = firstStopId;
                lastStopOnRouteId = lastStopId;
                dataGridView1.DataSource = DBCommunicator.GetRouteByFirstStopId(firstStopId);
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
            dataGridView1.Columns[4].ReadOnly = false;
            #endregion

            UpdateStopsOnRouteOrder();
        }

        /// <summary>
        /// Zatwierdzenie dodania nowej trasy
        /// </summary>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (doWeAddnew)
            {
                if (notNewMode == 1)
                    ChangeForm(this, new ManagerTransitAdd(lineId, firstStopOnRouteId, lastStopOnRouteId));
                else
                    ChangeForm(this, new ManagerTransitManage(transitId));
            }
            else
            {
                ChangeForm(this, new ManagerRouteShow(transitId));
            }
        }

        private void UpdateStopsOnRouteOrder()
        {
            int ord = 1, currentStopId = firstStopOnRouteId;

            while (currentStopId != -1)
            {
                //pobranie przystanku na trasie
                var stop = DBCommunicator.SelectFromStopsOnRouteById(currentStopId)[0];

                int nextId = -1;

                if (!stop[2].Equals(""))
                {
                    nextId = int.Parse(stop[2]);
                }
                int prevId = -1;

                if (!stop[3].Equals(""))
                {
                    prevId = int.Parse(stop[3]);
                }

                //zaktualizowanie L.p.
                DBCommunicator.UpdateStopsOnRoute(int.Parse(stop[0]), int.Parse(stop[1]), nextId, prevId, ord++, int.Parse(stop[5]));

                //ustawienie kolejnego ID
                if (!stop[2].Equals(""))
                {
                    currentStopId = int.Parse(stop[2]);
                }
                else
                {
                    currentStopId = -1;
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //te trasy trzeba usunąć
            var result = DBCommunicator.SelectAbandonedStopsOnRoute();

            foreach (var stop in result)
            {
                string[] stopToDel = stop;
                while (stopToDel != null)
                {
                    var temp = stopToDel;

                    //stopToDel = stopToDel->next
                    stopToDel = stopToDel[2].Equals("") ? null : DBCommunicator.SelectFromStopsOnRouteById(int.Parse(stopToDel[2]))[0];

                    if (stopToDel != null)
                    {
                        //temp->next->prev = NULL
                        int nextNextId = stopToDel[2].Equals("") ? -1 : int.Parse(stopToDel[2]);

                        DBCommunicator.UpdateStopsOnRoute(int.Parse(stopToDel[0]), int.Parse(stopToDel[1]), nextNextId, -1, int.Parse(stopToDel[4]), int.Parse(stopToDel[5]));
                    }
                    DBCommunicator.DeleteFromStopsOnRouteById(int.Parse(temp[0]));
                }
            }

            //właściwy powrót
            if (doWeAddnew)
            {
                if (notNewMode == 1)
                    ChangeForm(this, new ManagerTransitAdd(lineId, -1, -1));
                else
                    ChangeForm(this, new ManagerTransitManage(transitId));
            }
            else
            {
                ChangeForm(this, new ManagerRouteShow(transitId));
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedRow = dataGridView1.SelectedRows[0];
            }
        }

        private int AddStopOnRouteAtIndex(string[] stopToAdd, int index)
        {
            if (index < 0)
            {
                return -1;
            }
            else if (firstStopOnRouteId == -1)
            {
                if (index != 1)
                {
                    return -1;
                }
                else
                {
                    //wstawiamy pierwszy przystanek na tej trasie
                    firstStopOnRouteId = lastStopOnRouteId = DBCommunicator.InsertIntoStopsOnRoute(int.Parse(stopToAdd[0]), -1, -1, index, 0);

                    return firstStopOnRouteId;
                }
            }
            else
            {
                int id = firstStopOnRouteId;
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
                    int newlyAddedStopOnRouteId = DBCommunicator.InsertIntoStopsOnRoute(int.Parse(stopToAdd[0]), int.Parse(nextStopOnRoute[0]), -1, index, 0);

                    firstStopOnRouteId = newlyAddedStopOnRouteId;

                    int nextNextId = nextStopOnRoute[2].Equals("") ? -1 : int.Parse(nextStopOnRoute[2]);

                    DBCommunicator.UpdateStopsOnRoute(int.Parse(nextStopOnRoute[0]), int.Parse(nextStopOnRoute[1]), nextNextId, newlyAddedStopOnRouteId, int.Parse(nextStopOnRoute[4]), int.Parse(nextStopOnRoute[5]));
                    return newlyAddedStopOnRouteId;
                }
                //środek listy
                else if (!endOfList)
                {
                    var nextStopOnRoute = DBCommunicator.SelectFromStopsOnRouteById(id)[0];
                    var prevStopOnRoute = DBCommunicator.SelectFromStopsOnRouteById(int.Parse(DBCommunicator.SelectFromStopsOnRouteById(id)[0][3]))[0];

                    int newlyAddedStopOnRouteId = DBCommunicator.InsertIntoStopsOnRoute(int.Parse(stopToAdd[0]), int.Parse(nextStopOnRoute[0]), int.Parse(prevStopOnRoute[0]), index, 0);

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
                    int newlyAddedStopOnRouteId = lastStopOnRouteId = DBCommunicator.InsertIntoStopsOnRoute(int.Parse(stopToAdd[0]), -1, int.Parse(prevStopOnRoute[0]), index, 0);

                    int prevPrevId = prevStopOnRoute[3].Equals("") ? -1 : int.Parse(prevStopOnRoute[3]);

                    DBCommunicator.UpdateStopsOnRoute(int.Parse(prevStopOnRoute[0]), int.Parse(prevStopOnRoute[1]), newlyAddedStopOnRouteId, prevPrevId, int.Parse(prevStopOnRoute[4]), int.Parse(prevStopOnRoute[5]));

                    return newlyAddedStopOnRouteId;
                }
            }
        }

        /// <summary>
        /// Wstawia przystanek na konkretnym miejscu w trasie. Index - od 1 w górę (inne wartości są błędne). Zwraca ten przystanek lub nulla.
        /// </summary>
        private string[] DeleteStopOnRouteAtIndex(int index)
        {
            string[] stopToDelete = null;

            if (index < 0 || firstStopOnRouteId == -1)
            {
                return null;
            }
            else
            {
                int id = firstStopOnRouteId;

                //przechodzenie po liście
                for (int i = 1; i < index; i++)
                {
                    var stop = DBCommunicator.SelectFromStopsOnRouteById(id)[0];
                    id = int.Parse(stop[2]);
                }

                stopToDelete = DBCommunicator.SelectFromStopsOnRouteById(id)[0];

                bool endOfList = stopToDelete[2].Equals("") ? true : false;

                //usuwamy jedyny przystanek na trasie
                if (firstStopOnRouteId == lastStopOnRouteId)
                {
                    DBCommunicator.DeleteFromStopsOnRouteById(id);
                    firstStopOnRouteId = lastStopOnRouteId = -1;
                }
                //początek listy
                else if (index == 1)
                {
                    var nextStopOnRoute = DBCommunicator.SelectFromStopsOnRouteById(int.Parse(DBCommunicator.SelectFromStopsOnRouteById(id)[0][2]))[0];

                    int nextNextId = nextStopOnRoute[2].Equals("") ? -1 : int.Parse(nextStopOnRoute[2]);

                    DBCommunicator.UpdateStopsOnRoute(int.Parse(nextStopOnRoute[0]), int.Parse(nextStopOnRoute[1]), nextNextId, -1, int.Parse(nextStopOnRoute[4]), int.Parse(nextStopOnRoute[5]));

                    firstStopOnRouteId = int.Parse(nextStopOnRoute[0]);

                    //delete
                    DBCommunicator.DeleteFromStopsOnRouteById(id);
                }
                //środek listy
                else if (!endOfList)
                {
                    var nextStopOnRoute = DBCommunicator.SelectFromStopsOnRouteById(int.Parse(DBCommunicator.SelectFromStopsOnRouteById(id)[0][2]))[0];
                    var prevStopOnRoute = DBCommunicator.SelectFromStopsOnRouteById(int.Parse(DBCommunicator.SelectFromStopsOnRouteById(id)[0][3]))[0];

                    int prevPrevId = prevStopOnRoute[3].Equals("") ? -1 : int.Parse(prevStopOnRoute[3]);
                    int nextNextId = nextStopOnRoute[2].Equals("") ? -1 : int.Parse(nextStopOnRoute[2]);

                    DBCommunicator.UpdateStopsOnRoute(int.Parse(nextStopOnRoute[0]), int.Parse(nextStopOnRoute[1]), nextNextId, int.Parse(prevStopOnRoute[0]), int.Parse(nextStopOnRoute[4]), int.Parse(nextStopOnRoute[5]));
                    DBCommunicator.UpdateStopsOnRoute(int.Parse(prevStopOnRoute[0]), int.Parse(prevStopOnRoute[1]), int.Parse(nextStopOnRoute[0]), prevPrevId, int.Parse(prevStopOnRoute[4]), int.Parse(prevStopOnRoute[5]));

                    //delete
                    DBCommunicator.DeleteFromStopsOnRouteById(id);
                }
                //koniec listy
                else
                {
                    var prevStopOnRoute = DBCommunicator.SelectFromStopsOnRouteById(int.Parse(DBCommunicator.SelectFromStopsOnRouteById(id)[0][3]))[0];

                    int prevPrevId = prevStopOnRoute[3].Equals("") ? -1 : int.Parse(prevStopOnRoute[3]);

                    DBCommunicator.UpdateStopsOnRoute(int.Parse(prevStopOnRoute[0]), int.Parse(prevStopOnRoute[1]), -1, prevPrevId, int.Parse(prevStopOnRoute[4]), int.Parse(prevStopOnRoute[5]));

                    lastStopOnRouteId = int.Parse(prevStopOnRoute[0]);

                    //delete
                    DBCommunicator.DeleteFromStopsOnRouteById(id);
                }
            }

            return stopToDelete;
        }

        /// <summary>
        /// Up czyli bliżej początku trasy
        /// </summary>
        private void MoveStopOnRouteUp(int index)
        {
            if (index > 1)
            {
                var stopOnRoute = DeleteStopOnRouteAtIndex(index);
                var stop = DBCommunicator.SelectFromStopsById(int.Parse(stopOnRoute[1]))[0];

                int id = AddStopOnRouteAtIndex(stop, index - 1);

                //zapamiętanie czasu przejazdu
                int transitTime = int.Parse(stopOnRoute[5]);

                //pobranie "nowego" przystanku na trasie
                stopOnRoute = DBCommunicator.SelectFromStopsOnRouteById(id)[0];

                int prevPrevId = stopOnRoute[3].Equals("") ? -1 : int.Parse(stopOnRoute[3]);
                int nextNextId = stopOnRoute[2].Equals("") ? -1 : int.Parse(stopOnRoute[2]);

                //zaktualizowanie czasu przejazdu
                DBCommunicator.UpdateStopsOnRoute(int.Parse(stopOnRoute[0]), int.Parse(stopOnRoute[1]), nextNextId, prevPrevId, int.Parse(stopOnRoute[4]), transitTime);

                UpdateStopsOnRouteOrder();

                dataGridView1.DataSource = DBCommunicator.GetRouteByFirstStopId(firstStopOnRouteId);

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                }
                dataGridView1.Rows[index - 2].Selected = true;
            }
        }

        /// <summary>
        /// Down czyli bliżej końca trasy
        /// </summary>
        private void MoveStopOnRouteDown(int index)
        {
            if (index < dataGridView1.Rows.Count)
            {
                var stopOnRoute = DeleteStopOnRouteAtIndex(index);
                var stop = DBCommunicator.SelectFromStopsById(int.Parse(stopOnRoute[1]))[0];

                int id = AddStopOnRouteAtIndex(stop, index + 1);

                //zapamiętanie czasu przejazdu
                int transitTime = int.Parse(stopOnRoute[5]);

                //pobranie "nowego" przystanku na trasie
                stopOnRoute = DBCommunicator.SelectFromStopsOnRouteById(id)[0];

                int prevPrevId = stopOnRoute[3].Equals("") ? -1 : int.Parse(stopOnRoute[3]);
                int nextNextId = stopOnRoute[2].Equals("") ? -1 : int.Parse(stopOnRoute[2]);

                //zaktualizowanie czasu przejazdu
                DBCommunicator.UpdateStopsOnRoute(int.Parse(stopOnRoute[0]), int.Parse(stopOnRoute[1]), nextNextId, prevPrevId, int.Parse(stopOnRoute[4]), transitTime);

                //aktualizacja liczb porządkowych
                UpdateStopsOnRouteOrder();

                dataGridView1.DataSource = DBCommunicator.GetRouteByFirstStopId(firstStopOnRouteId);

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Selected = false;
                }
                dataGridView1.Rows[index].Selected = true;
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                MoveStopOnRouteDown(selectedRow.Index + 1);
            }
            else
            {
                MessageBox.Show("Najpierw należy zaznaczyć konkretny wiersz w tabeli obok.\nWięcej informacji w zakładce Pomoc.");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DeleteStopOnRouteAtIndex(selectedRow.Index + 1);

            if (firstStopOnRouteId != -1)
            {
                UpdateStopsOnRouteOrder();
                dataGridView1.DataSource = DBCommunicator.GetRouteByFirstStopId(firstStopOnRouteId);
            }
            else
            {
                dataGridView1.DataSource = DBCommunicator.GetRouteByFirstStopId(0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeForm(this, new ManagerRouteManageAddStop(lineId, firstStopOnRouteId, lastStopOnRouteId, dataGridView1.Rows.Count));
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                int newTime = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());

                DBCommunicator.UpdateStopOnRouteTransitTime(id, newTime);
            }
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                MoveStopOnRouteUp(selectedRow.Index + 1);
            }
            else
            {
                MessageBox.Show("Najpierw należy zaznaczyć konkretny wiersz w tabeli obok.\nWięcej informacji w zakładce Pomoc.");
            }
        }
    }
}

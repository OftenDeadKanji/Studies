using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A_star
{ 
    public class A_star
    {
        static public List<Vector2Int> FindPath(Vector2Int start, Vector2Int end, Grid grid)
        {
            if (start != end)
            {
                int startCell = start.x * grid.Height + start.y;
                int endCell = end.x * grid.Height + end.y;

                HashSet<int> closedSet = new HashSet<int>();
                HashSet<int> openSet = new HashSet<int>();
                openSet.Add(startCell);

                float[] g = new float[grid.Graph.Size];
                for (int i = 0; i < grid.Graph.Size; i++)
                {
                    g[i] = float.PositiveInfinity;
                }
                g[startCell] = 0.0f;

                List<float> h = new List<float>();
                for (int i = 0; i < grid.Width; i++)
                {
                    for (int j = 0; j < grid.Height; j++)
                    {
                        if (grid.GridArray[i, j] == float.PositiveInfinity)
                        {
                            h.Add(float.PositiveInfinity);
                        }
                        else
                        {
                            int xDiff = end.x - i;
                            int yDiff = end.y - j;

                            h.Add(Mathf.Sqrt(xDiff * xDiff + yDiff * yDiff));
                        }
                    }
                }

                List<int> previousNode = new List<int>(grid.Graph.Size);
                for (int i = 0; i < grid.Graph.Size; i++)
                {
                    previousNode.Add(-1);
                }

                while (openSet.Count != 0)
                {
                    float minF = g[openSet.First()] + h[openSet.First()];
                    int cellNumber = openSet.First();
                    foreach (var cell in openSet)
                    {
                        float f = g[cell] + h[cell];
                        if (f < minF)
                        {
                            minF = f;
                            cellNumber = cell;
                        }
                    }

                    if (cellNumber == endCell)
                    {
                        break;
                    }

                    openSet.Remove(cellNumber);
                    closedSet.Add(cellNumber);

                    var cellNeighbours = grid.GetCellNeighbours(cellNumber);
                    foreach (var neighbour in cellNeighbours)
                    {
                        if (closedSet.Contains(neighbour))
                        {
                            continue;
                        }

                        float gTmp = g[cellNumber] + grid.Graph.Weight[cellNumber, neighbour];
                        bool isTmpBetter = false;
                        if (!openSet.Contains(neighbour))
                        {
                            openSet.Add(neighbour);
                            isTmpBetter = true;
                        }
                        else if (gTmp < g[neighbour])
                        {
                            isTmpBetter = true;
                        }

                        if (isTmpBetter)
                        {
                            previousNode[neighbour] = cellNumber;
                            g[neighbour] = gTmp;
                        }
                    }
                }

                int previous;
                int current = endCell;

                List<Vector2Int> path = new List<Vector2Int>();
                path.Add(grid.GetCellCoordinate(endCell));

                do
                {
                    previous = previousNode[current];
                    path.Add(grid.GetCellCoordinate(previous));
                    current = previous;
                } while (previous != startCell);

                path.Reverse();
                return path;
            }

            var toReturn = new List<Vector2Int>();
            toReturn.Add(start);

            return toReturn;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A_star
{
    public class Grid
    {
        int width;
        public int Width
        {
            get { return width; }
        }

        int height;
        public int Height
        {
            get { return height; }
        }

        float[,] gridArray;
        public float[,] GridArray
        {
            get { return gridArray; }
        }

        Graph graph;
        public Graph Graph
        {
            get { return graph; }
        }

        public Grid(int width, int height)
        {
            this.width = width;
            this.height = height;

            gridArray = new float[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    gridArray[x, y] = 0.0f;
                }
            }

            graph = new Graph(width * height);
        }

        public int GetCellNumber(int x, int y)
        {
            return x * height + y;
        }

        public Vector2Int GetCellCoordinate(int cellNumber)
        {
            int x = cellNumber / height;
            int y = cellNumber % height;
            return new Vector2Int(x, y);
        }

        public void CreateGraph()
        {
            for (int i = 0; i < graph.Size; i++)
            {
                for (int j = 0; j < graph.Size; j++)
                {
                    graph.Weight[i, j] = float.PositiveInfinity;
                }
            }

            for (int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    int cellNumber = GetCellNumber(i, j);
                    List<int> cellNeighbours = GetCellNeighbours(cellNumber);

                    foreach(int neighbour in cellNeighbours)
                    {
                        var n = GetCellCoordinate(neighbour);
                        if(gridArray[n.x, n.y] == float.PositiveInfinity)
                        {
                            graph.Weight[cellNumber, neighbour] = float.PositiveInfinity;
                        }
                        else
                        {
                            graph.Weight[cellNumber, neighbour] = gridArray[n.x, n.y];
                        }
                    }
                }
            }
        }

        public List<int> GetCellNeighbours(int cellNumber)
        {
            var cell = GetCellCoordinate(cellNumber);

            int x = cell.x;
            int y = cell.y;

            List<int> cells = new List<int>();

            if(x != 0)
            {
                if(y != 0)
                {
                    cells.Add(GetCellNumber(x - 1, y - 1));
                }
                cells.Add(GetCellNumber(x - 1, y));
                if(y != height - 1)
                {
                    cells.Add(GetCellNumber(x - 1, y + 1));
                }
            }

            if (y != 0)
            {
                cells.Add(GetCellNumber(x, y - 1));
            }
            //cells.Add(GetCellNumber(x, y));
            if (y != height - 1)
            {
                cells.Add(GetCellNumber(x, y + 1));
            }

            if (x != width - 1)
            {
                if (y != 0)
                {
                    cells.Add(GetCellNumber(x + 1, y - 1));
                }
                cells.Add(GetCellNumber(x + 1, y));
                if (y != height - 1)
                {
                    cells.Add(GetCellNumber(x + 1, y + 1));
                }
            }

            return cells;
        }
    }
}
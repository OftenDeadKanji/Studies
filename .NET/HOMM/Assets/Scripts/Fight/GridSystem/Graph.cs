using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A_star
{
    public class Graph
    {
        int size;
        public int Size
        {
            get { return size; }
        }

        float[,] weight;
        public float[,] Weight
        {
            get { return weight; }
        }
        public Graph(int size)
        {
            this.size = size;
            weight = new float[size, size];
        }
    }
}
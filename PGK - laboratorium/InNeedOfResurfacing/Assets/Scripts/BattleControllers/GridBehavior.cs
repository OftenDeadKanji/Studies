using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
public class GridBehavior : MonoBehaviour
{
    //public int gridSize = 6;
    public GridField[] fields;
    //public LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        //fields = new List<GridField>();
        //lineRenderer.useWorldSpace = false;
        //lineRenderer.startWidth = 0.025f;
        //lineRenderer.endWidth = 0.025f;
        //lineRenderer.startColor = Color.white;
        //lineRenderer.endColor = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GridField field in fields)
        {
            field.draw();
            //List<Vector3> vertices = field.getFieldVertices();
            //LineRenderer lineRenderer = field.getLineRenderer();
            ////Debug.Log(vertices[1]);
            //lineRenderer.positionCount = vertices.Count;
            //lineRenderer.SetPositions(vertices.ToArray());
            //Vector3[] linePoints = { Vector3.zero, Vector3.zero };
            //for(int i = 0; i < vertices.Count; i+=2)
            //{
            //    linePoints[0] = vertices[i];
            //    if (i + 1 == vertices.Count)
            //        linePoints[1] = vertices[0];
            //    else
            //        linePoints[1] = vertices[i + 1];
            //    lineRenderer.SetPositions(linePoints);

            //}
        }
    }
}

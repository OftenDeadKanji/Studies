using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridField : MonoBehaviour
{
    [SerializeField] private FieldShape shape = FieldShape.Rectangle;
    [SerializeField] private bool isBlocked = false;
    [SerializeField] private float sizeMultiplier = 1.0f;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private MeshCollider meshCollider;

    public GridField(FieldShape shape, float sizeMultiplier, LineRenderer lineRenderer, MeshCollider meshCollider)
    {
        this.shape = shape;
        this.sizeMultiplier = sizeMultiplier;
        this.lineRenderer = lineRenderer;
        this.meshCollider = meshCollider;
    }

    private void initLineRenderer()
    {
        lineRenderer.useWorldSpace = true;
        lineRenderer.widthMultiplier = 0.02f;
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;
    }

    public FieldShape getShape()
    {
        return shape;
    }

    public bool getBlocked()
    {
        return isBlocked;
    }

    public float getSizeMultiplier()
    {
        return sizeMultiplier;
    }

    public LineRenderer getLineRenderer()
    {
        return lineRenderer;
    }

    public List<Vector3> getFieldVertices()
    {
        List<Vector3> vertices = new List<Vector3>();
        switch(shape)
        {
            case FieldShape.Rectangle:
                {
                    vertices.Add(new Vector3(gameObject.transform.position.x - 0.5f * sizeMultiplier, 
                        gameObject.transform.position.y, gameObject.transform.position.z - 0.5f * sizeMultiplier));
                    vertices.Add(new Vector3(gameObject.transform.position.x + 0.5f * sizeMultiplier, 
                        gameObject.transform.position.y, gameObject.transform.position.z - 0.5f * sizeMultiplier));
                    vertices.Add(new Vector3(gameObject.transform.position.x + 0.5f * sizeMultiplier,
                        gameObject.transform.position.y, gameObject.transform.position.z + 0.5f * sizeMultiplier));
                    vertices.Add(new Vector3(gameObject.transform.position.x - 0.5f * sizeMultiplier,
                        gameObject.transform.position.y, gameObject.transform.position.z + 0.5f * sizeMultiplier));
                    break;
                }
            case FieldShape.Triangle:
                {
                    break;
                }
                //etc.
        }
        return vertices;
    }

    public void draw()
    {
        List<Vector3> vertices = getFieldVertices();
        lineRenderer.positionCount = vertices.Count;
        lineRenderer.SetPositions(vertices.ToArray());
        //Mesh mesh = new Mesh();
        //lineRenderer.BakeMesh(mesh, true);
        //meshCollider.sharedMesh = mesh;
        //Debug.Log(meshCollider.transform.position); // = transform.position;
    }

    public void setBlocked(bool isBlocked)
    {
        this.isBlocked = isBlocked;
    }
    private void OnTriggerEnter(Collider other)
    {
        gameObject.layer = 2;
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.layer = 8;
    }
}
 public enum FieldShape { Rectangle = 4, Triangle = 3}
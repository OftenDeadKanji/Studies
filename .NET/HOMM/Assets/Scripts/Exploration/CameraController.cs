using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    float speed = 10.0f;
    [SerializeField]
    float scrollSpeed = 1000.0f;

    [SerializeField]
    Vector3 posBoundaryMin = new Vector3(5f, 5f, -1.5f);
    [SerializeField]
    Vector3 posBoundaryMax = new Vector3(50f, 15f, 50f);

    void Update()
    {
        if(Input.GetKey(KeyCode.A) && gameObject.transform.position.x > posBoundaryMin.x)
        {
            gameObject.transform.position += new Vector3(-1.0f, 0.0f, 0.0f) * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D) && gameObject.transform.position.x < posBoundaryMax.x)
        {
            gameObject.transform.position += new Vector3(1.0f, 0.0f, 0.0f) * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S) && gameObject.transform.position.z > posBoundaryMin.z)
        {
            gameObject.transform.position += new Vector3(0.0f, 0.0f, -1.0f) * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.W) && gameObject.transform.position.z < posBoundaryMax.z)
        {
            gameObject.transform.position += new Vector3(0.0f, 0.0f, 1.0f) * Time.deltaTime * speed;
        }

        if(Input.GetKey(KeyCode.Q) && gameObject.transform.position.y < posBoundaryMax.y)
        {
            gameObject.transform.position -= gameObject.transform.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.E) && gameObject.transform.position.y > posBoundaryMin.y)
        {
            gameObject.transform.position += gameObject.transform.forward * Time.deltaTime * speed;
        }

        if(Input.GetAxis("Mouse ScrollWheel") > 0.0f && gameObject.transform.position.y > posBoundaryMin.y)
        {
            gameObject.transform.position += gameObject.transform.forward * Time.deltaTime * scrollSpeed * Input.GetAxis("Mouse ScrollWheel");
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0.0f && gameObject.transform.position.y < posBoundaryMax.y)
        {
            gameObject.transform.position += gameObject.transform.forward * Time.deltaTime * scrollSpeed * Input.GetAxis("Mouse ScrollWheel");
        }
    }
}

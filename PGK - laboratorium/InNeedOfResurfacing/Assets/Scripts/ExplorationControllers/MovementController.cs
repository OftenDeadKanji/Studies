using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    float speed = 3.0f;
    [SerializeField]
    SpriteRenderer spriteRenderer;
    [SerializeField]
    Camera mainCamera;

    void Start()
    {
        PlayerManager playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();

        if (!playerManager.gameStart)
        {
            playerManager.gameStart = true;
        }
        else gameObject.transform.position = playerManager.tempPos;

        spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer == null)
        {
            throw new System.Exception("spriteRenderer object is null!");
        }
        if (mainCamera == null)
        {
            throw new System.Exception("mainCamera object is null!");
        }
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position += new Vector3(0.0f, 1.0f, 0.0f) * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position -= new Vector3(0.0f, 1.0f, 0.0f) * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += new Vector3(1.0f, 0.0f, 0.0f) * speed * Time.deltaTime;
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position -= new Vector3(1.0f, 0.0f, 0.0f) * speed * Time.deltaTime;
            spriteRenderer.flipX = true;
        }

        var newCameraPos = mainCamera.transform.position;   
        newCameraPos.x = gameObject.transform.position.x;
        newCameraPos.y = gameObject.transform.position.y;

        mainCamera.transform.position = newCameraPos;
    }
}

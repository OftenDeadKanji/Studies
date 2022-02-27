using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour, Interactive
{
    int amount;
    
    void Start()
    {
        amount = Random.Range(1, 5);
    }


    public void Interact()
    {
        var gameManagerObject = GameObject.Find("GameManager");
        if (gameManagerObject != null)
        {
            GameManager gameManager = gameManagerObject.GetComponent<GameManager>();
            if (gameManager != null)
            {
                gameManager.settlementGeneralResources += 20;

                if(--amount == 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}

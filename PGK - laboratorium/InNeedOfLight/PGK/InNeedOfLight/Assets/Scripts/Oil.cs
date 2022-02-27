using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : MonoBehaviour, Interactive
{
    public int quantity = 3;

    public void Interact()
    {
        var gameManagerObject = GameObject.Find("GameManager");
        if (gameManagerObject != null)
        {
            GameManager gameManager = gameManagerObject.GetComponent<GameManager>();
            if (gameManager != null)
            {
                gameManager.settlementOil += quantity;
            }
        }

        Destroy(gameObject);
    }
}

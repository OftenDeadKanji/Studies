using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    ExplorationManager explorationManager;

    private void Awake()
    {
        var explorationManagerGameObject = GameObject.Find("ExplorationManager");
        if(explorationManagerGameObject != null)
        {
            explorationManager = explorationManagerGameObject.GetComponent<ExplorationManager>();
            if(explorationManager == null)
            {
                throw new Exception("explorationManager component not found!");
            }
        }
        else
        {
            throw new Exception("explorationManager GameObject not found!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            CrossSceneInformation.currentLightSource = explorationManager.NearestTorch;

            SceneManager.LoadScene(1);
        }
    }
}

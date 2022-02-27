using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceAndSupplyManager : MonoBehaviour
{
    ExplorationManager explorationManager;
    [SerializeField]
    //1 - resource, 2 - Supply (1 on default)
    int type = 1;
    [SerializeField]
    int id;

    private void Awake()
    {
        var pickables = GameObject.Find("PlayerManager").GetComponent<PlayerManager>().pickableAlreadyPicked;
        foreach(var pickable in pickables)
        {
            if(pickable == id)
            {
                this.gameObject.SetActive(false);
                return;
            }
        }
        var explorManagerGameObj = GameObject.Find("ExplorationManager");
        explorationManager = explorManagerGameObj.GetComponent<ExplorationManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(type == 1)
        {
            explorationManager.PickUpResources();
        }
        else
        {
            explorationManager.PickUpSupplies();
        }

        GameObject.Find("PlayerManager").GetComponent<PlayerManager>().pickableAlreadyPicked.Add(id);

        Destroy(gameObject);
    }
}

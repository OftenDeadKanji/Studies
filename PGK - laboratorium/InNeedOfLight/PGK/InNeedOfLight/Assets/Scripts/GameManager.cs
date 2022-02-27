using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [Header("Resources")]
    [SerializeField]
    public float settlementGeneralResources = 100.0f;
    [SerializeField]
    public float settlementOil = 200.0f;
    [SerializeField]
    public float settlementFood = 500.0f;
    float foodConsumption = 1.0f; // per sec

    [SerializeField]
    GameObject lightsParent;
    [SerializeField]
    float timeForNexEvent = 180.0f;
    [SerializeField]
    float timeForEventToEnd = 30.0f;

    [SerializeField]
    GameEvents currentEvent = GameEvents.none;

    enum GameEvents
    {
        none = -1,

        lightsOut = 0,
        moreMonsters = 1
    }

    [Header("Prefabs")]
    [SerializeField]
    GameObject torchPrefab;

    [Header("GUI elements")]
    [SerializeField]
    TMP_Text generalResourcesValue;
    [SerializeField]
    TMP_Text oilValue;
    [SerializeField]
    TMP_Text foodValue;
    [SerializeField]
    TMP_Text newEvent;

    private void Start()
    {
        if (generalResourcesValue == null || oilValue == null)
        {
            throw new System.Exception("GUI elements are null!");
        }
    }

    private void Update()
    {
        settlementFood -= foodConsumption * Time.deltaTime;

        generalResourcesValue.text = settlementGeneralResources.ToString();
        oilValue.text = settlementOil.ToString();
        foodValue.text = ((int)settlementFood).ToString();

        if (currentEvent == GameEvents.none)
        {
            timeForNexEvent -= Time.deltaTime;
            if (timeForNexEvent <= 0.0f)
            {
                releaseGameEvent();
            }
        }
        else
        {
            timeForEventToEnd -= Time.deltaTime;
            if(timeForEventToEnd <= 0.0f)
            {
                endEvent();
            }
        }
    }

    void releaseGameEvent()
    {
        currentEvent = (GameEvents)Random.Range(0, 2);

        switch (currentEvent)
        {
            case GameEvents.lightsOut:
                newEvent.text = "! CIEMNOŚĆ !";

                for (int i = 0; i < lightsParent.transform.childCount; ++i)
                {
                    var child = lightsParent.transform.GetChild(i);

                    LightSourceManager light = child.GetComponent<LightSourceManager>();
                    if (light != null)
                    {
                        light.fuelLeft = 0.08f;
                        light.fuelConsumptionSpeed *= 5;
                    }
                }
                break;
            case GameEvents.moreMonsters:
                newEvent.text = "! DEMONY !";

                var enemyBases = GameObject.FindGameObjectsWithTag("EnemyBase");
                foreach (var enemyBase in enemyBases)
                {
                    EnemyBaseManager manager = enemyBase.GetComponent<EnemyBaseManager>();
                    if (manager != null)
                    {
                        manager.maxEnemySpawned *= 5;
                        manager.spawnCooldown /= 3.0f;
                    }
                }
                break;
        }
    }

    void endEvent()
    {
        newEvent.text = "";

        switch (currentEvent)
        {
            case GameEvents.lightsOut:
                for (int i = 0; i < lightsParent.transform.childCount; ++i)
                {
                    var child = lightsParent.transform.GetChild(i);

                    LightSourceManager light = child.GetComponent<LightSourceManager>();
                    if (light != null)
                    {
                        light.fuelConsumptionSpeed /= 5;
                    }
                }
                break;
            case GameEvents.moreMonsters:
                var enemyBases = GameObject.FindGameObjectsWithTag("EnemyBase");
                foreach (var enemyBase in enemyBases)
                {
                    EnemyBaseManager manager = enemyBase.GetComponent<EnemyBaseManager>();
                    if (manager != null)
                    {
                        manager.maxEnemySpawned /= 5;
                        manager.spawnCooldown *= 3.0f;
                    }
                }
                break;
        }

        timeForNexEvent = 180f;
        timeForEventToEnd = 30.0f;
        currentEvent = GameEvents.none;
    }
    public void BuildTorch()
    {
        if (settlementGeneralResources >= 10.0f)
        {
            settlementGeneralResources -= 10.0f;

            var playerPos = player.transform.position;
            var light = Instantiate(torchPrefab, playerPos, Quaternion.Euler(new Vector3(90, 0, 0)));
            light.transform.parent = lightsParent.transform;
        }
    }

    public void PlayerEats()
    {
        if (settlementFood >= 20.0f)
        {
            PlayerController contr = player.GetComponent<PlayerController>();
            if (contr != null)
            {
                settlementFood -= 20;
                contr.currentHunger += 20;
            }
        }
    }

}

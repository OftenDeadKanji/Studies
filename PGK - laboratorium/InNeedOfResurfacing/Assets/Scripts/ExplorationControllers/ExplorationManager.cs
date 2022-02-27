using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplorationManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField]
    GameObject standingTorch;

    [Header("UI")]
    [SerializeField]
    Image nearestTorchFlame;
    [SerializeField]
    Image nearestTorchBar;
    [SerializeField]
    TMPro.TMP_Text supplies;
    [SerializeField]
    TMPro.TMP_Text resources;

    GameObject player;
    LightSource nearestTorch;
    public LightSource NearestTorch
    {
        get { return nearestTorch; }
        set { nearestTorch = value; }
    }

    private void Awake()
    {
        if(standingTorch == null)
        {
            throw new System.Exception("standingTorch prefab object is missing!");
        }

        player = GameObject.Find("MainPlayer");

        if (player == null)
        {
            throw new System.Exception("player gameobject not found!");
        }
    }

    public void callback_NewYellowTorch()
    {
        var newTorch = Instantiate(standingTorch, player.transform.position, Quaternion.identity);
        StandingTorchController torch = newTorch.GetComponent<StandingTorchController>();
        if(torch != null)
        {
            torch.LightSource.FlameColor = LightSource.Color.Yellow;
        }

        var _dynamic = GameObject.Find("_Dynamic");
        if( _dynamic != null )
        {
            newTorch.transform.parent = _dynamic.transform;
        }
    }
    public void callback_NewBlueTorch()
    {
        var newTorch = Instantiate(standingTorch, player.transform.position, Quaternion.identity);
        StandingTorchController torch = newTorch.GetComponent<StandingTorchController>();
        if (torch != null)
        {
            torch.LightSource.FlameColor = LightSource.Color.Blue;
        }

        var _dynamic = GameObject.Find("_Dynamic");
        if (_dynamic != null)
        {
            newTorch.transform.parent = _dynamic.transform;
        }
    }
    public void callback_NewGreenTorch()
    {
        var newTorch = Instantiate(standingTorch, player.transform.position, Quaternion.identity);
        StandingTorchController torch = newTorch.GetComponent<StandingTorchController>();
        if (torch != null)
        {
            torch.LightSource.FlameColor = LightSource.Color.Green;
        }

        var _dynamic = GameObject.Find("_Dynamic");
        if (_dynamic != null)
        {
            newTorch.transform.parent = _dynamic.transform;
        }
    }

    public void Update()
    {
        resources.text = CrossSceneInformation.resourcesPicked.ToString();
        supplies.text = CrossSceneInformation.suppliesPicked.ToString();

        var torches = GameObject.FindGameObjectsWithTag("Torch");
        if(torches != null && torches.Length > 0)
        {
            var nearestTorch = torches.OrderBy( torch => Vector3.Distance(player.transform.position, torch.transform.position )).FirstOrDefault();
            if (nearestTorch != null)
            {
                var torch = nearestTorch.GetComponent<StandingTorchController>();
                if (torch != null)
                {
                    if (Vector3.Distance(player.transform.position, torch.transform.position) < 5.0f)
                    {
                        this.nearestTorch = torch.LightSource;

                        if (torch.LightSource.IsActive)
                        {
                            switch (torch.LightSource.FlameColor)
                            {
                                case LightSource.Color.Yellow:
                                    nearestTorchFlame.color = Color.yellow;
                                    nearestTorchBar.color = Color.yellow;
                                    break;
                                case LightSource.Color.Blue:
                                    nearestTorchFlame.color = Color.blue;
                                    nearestTorchBar.color = Color.blue;
                                    break;
                                case LightSource.Color.Green:
                                    nearestTorchFlame.color = Color.green;
                                    nearestTorchBar.color = Color.green;
                                    break;
                            }
                        }
                        else
                        {
                            nearestTorchFlame.color = Color.black;
                            nearestTorchBar.color = Color.black;
                        }
                        nearestTorchBar.fillAmount = torch.LightSource.Fuel / torch.LightSource.MaxFuel;
                    }
                    else
                    {
                        this.nearestTorch = null;

                        nearestTorchFlame.color = Color.black;
                        nearestTorchBar.color = Color.black;

                        nearestTorchBar.fillAmount = 0.0f;
                    }
                }
            }
        }
        else
        {
            this.nearestTorch = null;

            nearestTorchFlame.color = Color.black;
            nearestTorchBar.color = Color.black;

            nearestTorchBar.fillAmount = 0.0f;
        }
    }

    public void PickUpResources(int count = 1)
    {
        CrossSceneInformation.resourcesPicked += count;
    }

    public void PickUpSupplies(int count = 1)
    {
        CrossSceneInformation.suppliesPicked += count;
    }
}

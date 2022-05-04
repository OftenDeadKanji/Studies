using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CityOverviewManager : MonoBehaviour
{
    City city = null;
    public City City
    {
        get { return city; }
    }

    [SerializeField]
    CityBuildingTownHallManager townHallManager;
    [SerializeField]
    CityBuildingUnitProductionManager meleeManager;
    [SerializeField]
    CityBuildingUnitProductionManager rangedManager;
    [SerializeField]
    CityBuildingUnitProductionManager cavalryManager;
    [SerializeField]
    CityBuildingUnitProductionManager titanManager;

    [SerializeField]
    UnitFormationsGUIManager unitFormationsGUIManager;

    [SerializeField]
    TMPro.TMP_Text goldInfo;
    [SerializeField]
    TMPro.TMP_Text woodInfo;
    [SerializeField]
    TMPro.TMP_Text stoneInfo;

    bool isAnyDialogBoxOpen = false;
    public bool IsAnyDialogBoxOpen
    {
        get { return isAnyDialogBoxOpen; }
        set { isAnyDialogBoxOpen = value;}
    }

    public void SetCity(City city)
    {
        this.city = city;
        foreach(var building in city.Buildings)
        {
            switch(building.BuildingType)
            {
                case CityBuilding.Type.TownHall:
                    townHallManager.SetCityBuilding(building);
                    break;
                case CityBuilding.Type.Melee:
                    meleeManager.SetCityBuilding(building);
                    break;
                case CityBuilding.Type.Ranged:
                    rangedManager.SetCityBuilding(building);
                    break;
                case CityBuilding.Type.Cavalry:
                    cavalryManager.SetCityBuilding(building);
                    break;
                case CityBuilding.Type.Titan:
                    titanManager.SetCityBuilding(building);
                    break;
            }
        }

        UpdateGarrision();
    }

    public void UpdateGarrision()
    {
        if (city.HeroInside != null)
        {
            unitFormationsGUIManager.heroInsideImage.sprite = city.HeroInside.Icon;
        }
        else
        {
            unitFormationsGUIManager.heroInsideImage.sprite = null;
        }

        for (int i = 0; i < city.Inside.UnitFormations.Length; ++i)
        {
            if (city.Inside.UnitFormations[i] != null && city.Inside.UnitFormations[i].Unit.Type != UnitType.None)
            {
                unitFormationsGUIManager.unitsInside[i].sprite = city.Inside.UnitFormations[i].Unit.Icon;
                unitFormationsGUIManager.unitsInsideCount[i].text = city.Inside.UnitFormations[i].Count.ToString();
            }
            else
            {
                unitFormationsGUIManager.unitsInside[i].sprite = null;
                unitFormationsGUIManager.unitsInsideCount[i].text = "";
            }
        }

        if (city.HeroOutside != null)
        {
            unitFormationsGUIManager.heroOutsideImage.sprite = city.HeroOutside.Icon;
        }
        else
        {
            unitFormationsGUIManager.heroOutsideImage.sprite= null;
        }

        for (int i = 0; i < city.Outside.UnitFormations.Length; ++i)
        {
            if (city.Outside.UnitFormations[i] != null && city.Outside.UnitFormations[i].Unit.Type != UnitType.None)
            {
                unitFormationsGUIManager.unitsOutside[i].sprite = city.Outside.UnitFormations[i].Unit.Icon;
                unitFormationsGUIManager.unitsOutsideCount[i].text = city.Outside.UnitFormations[i].Count.ToString();
            }
            else
            {
                unitFormationsGUIManager.unitsOutside[i].sprite = null;
                unitFormationsGUIManager.unitsOutsideCount[i].text = "";
            }
        }
    }
    GameManager gameManager;

    private void Awake()
    {
        var gameManagerGameObject = GameObject.Find("GameManager");
        if(gameManagerGameObject == null)
        {
            throw new System.Exception("GameManager gameobject not found!");
        }

        gameManager = gameManagerGameObject.GetComponent<GameManager>();
        if(gameManager == null)
        {
            throw new System.Exception("GameManager component not found!");
        }
    }

    private void Update()
    {
        if(city != null)
        {
            if (city.Owner != null)
            {
                goldInfo.text = city.Owner.Resources.Gold.ToString();
                woodInfo.text = city.Owner.Resources.Wood.ToString();
                stoneInfo.text = city.Owner.Resources.Stone.ToString();
            }
        }
    }

    public void callback_ExitCity()
    {
        if (city.HeroOutside != null)
        {
            for (int i = 0; i < city.HeroOutside.UnitsGroup.UnitFormations.Length; i++)
            {
                city.HeroOutside.UnitsGroup.UnitFormations[i] = city.Outside.UnitFormations[i];
                city.Outside.UnitFormations[i] = new UnitFormation(Unit.CreateUnitNone(), 0);
            }

            var players = GameObject.FindGameObjectsWithTag("Player");
            foreach (var player in players)
            {
                foreach (Transform child in player.transform)
                {
                    var heroController= child.gameObject.GetComponent<HeroController>();
                    if(heroController.Hero == city.HeroOutside)
                    {
                        child.gameObject.SetActive(true);
                    }
                }
            }

            city.HeroOutside = null;
        }
        gameManager.ExitCity();
    }

    bool isHeroOutsideClicked = false;
    public void callback_HeroOutside()
    {
        if(isUnitInsideClicked)
        {
            isUnitInsideClicked = false;
            unitFormationsGUIManager.unitsInside[unitInsideClicked].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else if (isUnitOutsideClicked)
        {
            isUnitOutsideClicked = false;
            unitFormationsGUIManager.unitsOutside[unitOutsideClicked].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else if(!isHeroOutsideClicked)
        {
            if(isHeroInsideClicked)
            {
                isHeroInsideClicked = false;
                unitFormationsGUIManager.heroInsideImage.color = new Color(1.0f, 1.0f, 1.0f);

                if(city.HeroOutside != null)
                {
                    //change hero outside <-> inside and its units
                    Hero tmp = city.HeroInside;
                    city.HeroInside = city.HeroOutside;
                    city.HeroOutside = tmp;

                    for (int i = 0; i < 10; ++i)
                    {
                        UnitFormation tmpUnit = city.Outside.UnitFormations[i];
                        city.Outside.UnitFormations[i] = city.Inside.UnitFormations[i];
                        city.Inside.UnitFormations[i] = tmpUnit;
                    }
                }
                else
                {
                    //move hero from inside to outside and all units inside to outside
                    city.HeroOutside = city.HeroInside;
                    city.HeroInside = null;

                    for(int i = 0; i < 10; ++i)
                    {
                        city.Outside.UnitFormations[i] = city.Inside.UnitFormations[i];
                        city.Inside.UnitFormations[i] = new UnitFormation(Unit.CreateUnitNone(), 0);
                    }
                }
            }
            else
            {
                if (city.HeroOutside != null)
                {
                    isHeroOutsideClicked = true;
                    unitFormationsGUIManager.heroOutsideImage.color = new Color(1.0f, 1.0f, 0.75f);
                }
            }
        }
        else
        {
            isHeroOutsideClicked = false;
            unitFormationsGUIManager.heroOutsideImage.color = new Color(1.0f, 1.0f, 1.0f);
        }

        UpdateGarrision();

    }
    
    bool isHeroInsideClicked = false;
    public void callback_HeroInside()
    {
        if (isUnitInsideClicked)
        {
            isUnitInsideClicked = false;
            unitFormationsGUIManager.unitsInside[unitInsideClicked].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else if (isUnitOutsideClicked)
        {
            isUnitOutsideClicked = false;
            unitFormationsGUIManager.unitsOutside[unitOutsideClicked].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else if (!isHeroInsideClicked)
        {
            if (isHeroOutsideClicked)
            {
                isHeroOutsideClicked = false;
                unitFormationsGUIManager.heroOutsideImage.color = new Color(1.0f, 1.0f, 1.0f);

                if (city.HeroInside != null)
                {
                    //change hero outside <-> inside and its units
                    Hero tmp = city.HeroInside;
                    city.HeroInside = city.HeroOutside;
                    city.HeroOutside = tmp;

                    for (int i = 0; i < 10; ++i)
                    {
                        UnitFormation tmpUnit = city.Outside.UnitFormations[i];
                        city.Outside.UnitFormations[i] = city.Inside.UnitFormations[i];
                        city.Inside.UnitFormations[i] = tmpUnit;
                    }
                }
                else
                {
                    //move hero from outside to inside and all units inside to inside
                    city.HeroInside = city.HeroOutside;
                    city.HeroOutside = null;

                    for (int i = 0; i < 10; ++i)
                    {
                        for(int j = 0; j < 10; j++)
                        {
                            if(city.Outside.UnitFormations[i].Unit.Type != UnitType.None)
                            {
                                if(city.Outside.UnitFormations[i].Unit.Type == city.Inside.UnitFormations[j].Unit.Type)
                                {
                                    city.Inside.UnitFormations[j].Count += city.Outside.UnitFormations[i].Count;
                                    city.Outside.UnitFormations[i] = new UnitFormation(Unit.CreateUnitNone(), 0);

                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }

                        }
                    }

                    for (int i = 0; i < 10; ++i)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (city.Outside.UnitFormations[i].Unit.Type != UnitType.None)
                            {
                                if (city.Inside.UnitFormations[j].Unit.Type == UnitType.None)
                                {
                                    city.Inside.UnitFormations[j]= city.Outside.UnitFormations[i];
                                    city.Outside.UnitFormations[i] = new UnitFormation(Unit.CreateUnitNone(), 0);

                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                if (city.HeroInside != null)
                {
                    isHeroInsideClicked = true;
                    unitFormationsGUIManager.heroInsideImage.color = new Color(1.0f, 1.0f, 0.75f);
                }
            }
        }
        else
        {
            isHeroOutsideClicked = false;
            unitFormationsGUIManager.heroOutsideImage.color = new Color(1.0f, 1.0f, 1.0f);
        }

        UpdateGarrision();
    }

    bool isUnitOutsideClicked = false;
    int unitOutsideClicked = -1;
    public void callback_UnitOutside(int index)
    {
        if (isHeroInsideClicked)
        {
            isHeroInsideClicked = false;
            unitFormationsGUIManager.heroInsideImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else if (isHeroOutsideClicked)
        {
            isHeroOutsideClicked = false;
            unitFormationsGUIManager.heroOutsideImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else
        {
            if(isUnitOutsideClicked)
            {
                if (city.Outside.UnitFormations[index].Unit.Type != UnitType.None)
                {
                    if (unitOutsideClicked == index)
                    {
                        unitFormationsGUIManager.unitsOutside[unitOutsideClicked].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

                        isUnitOutsideClicked = false;
                        unitOutsideClicked = -1;
                    }
                    else
                    {
                        unitFormationsGUIManager.unitsOutside[unitOutsideClicked].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

                        if (city.Outside.UnitFormations[unitOutsideClicked].Unit.Type == city.Outside.UnitFormations[index].Unit.Type)
                        {
                            city.Outside.UnitFormations[index].Count += city.Outside.UnitFormations[unitOutsideClicked].Count;
                            city.Outside.UnitFormations[unitOutsideClicked] = new UnitFormation(Unit.CreateUnitNone(), 0);
                        }
                        else
                        {
                            UnitFormation tmp = city.Outside.UnitFormations[unitOutsideClicked];
                            city.Outside.UnitFormations[unitOutsideClicked] = city.Outside.UnitFormations[index];
                            city.Outside.UnitFormations[index] = tmp;
                        }

                        isUnitOutsideClicked = false;
                        unitOutsideClicked = -1;
                    }
                }
                else
                {
                    unitFormationsGUIManager.unitsOutside[unitOutsideClicked].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

                    isUnitOutsideClicked = false;
                    unitOutsideClicked = -1;
                }
            }
            else if(isUnitInsideClicked)
            {
                if (city.Outside.UnitFormations[index].Unit.Type != UnitType.None)
                {
                    unitFormationsGUIManager.unitsInside[unitInsideClicked].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

                    if (city.Inside.UnitFormations[unitInsideClicked].Unit.Type == city.Outside.UnitFormations[index].Unit.Type)
                    {
                        city.Outside.UnitFormations[index].Count += city.Inside.UnitFormations[unitInsideClicked].Count;
                        city.Inside.UnitFormations[unitInsideClicked] = new UnitFormation(Unit.CreateUnitNone(), 0);
                    }
                    else
                    {
                        UnitFormation tmp = city.Inside.UnitFormations[unitInsideClicked];
                        city.Inside.UnitFormations[unitInsideClicked] = city.Outside.UnitFormations[index];
                        city.Outside.UnitFormations[index] = tmp;
                    }

                    isUnitInsideClicked = false;
                    unitInsideClicked = -1;
                }
                else
                {
                    if(city.HeroOutside != null)
                    {
                        city.Outside.UnitFormations[index] = city.Inside.UnitFormations[unitInsideClicked];
                        city.Inside.UnitFormations[unitInsideClicked] = new UnitFormation(Unit.CreateUnitNone(), 0);
                    }
                    unitFormationsGUIManager.unitsInside[unitInsideClicked].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

                    isUnitInsideClicked = false;
                    unitInsideClicked = -1;
                }
            }
            else if(city.Outside.UnitFormations[index].Unit.Type != UnitType.None)
            {
                unitFormationsGUIManager.unitsOutside[index].color = new Color(1.0f, 1.0f, 0.75f, 1.0f);

                isUnitOutsideClicked = true;
                unitOutsideClicked = index;
            }
        }

        UpdateGarrision();
    }

    bool isUnitInsideClicked = false;
    int unitInsideClicked = -1;
    public void callback_UnitInside(int index)
    {
        if (isHeroInsideClicked)
        {
            isHeroInsideClicked = false;
            unitFormationsGUIManager.heroInsideImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else if (isHeroOutsideClicked)
        {
            isHeroOutsideClicked = false;
            unitFormationsGUIManager.heroOutsideImage.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else
        {
            if (isUnitInsideClicked)
            {
                if (city.Inside.UnitFormations[index].Unit.Type != UnitType.None)
                {
                    if (unitInsideClicked == index)
                    {
                        unitFormationsGUIManager.unitsInside[unitInsideClicked].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

                        isUnitInsideClicked = false;
                        unitInsideClicked = -1;
                    }
                    else
                    {
                        unitFormationsGUIManager.unitsInside[unitInsideClicked].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

                        if (city.Inside.UnitFormations[unitInsideClicked].Unit.Type == city.Inside.UnitFormations[index].Unit.Type)
                        {
                            city.Inside.UnitFormations[index].Count += city.Inside.UnitFormations[unitInsideClicked].Count;
                            city.Inside.UnitFormations[unitInsideClicked] = new UnitFormation(Unit.CreateUnitNone(), 0);
                        }
                        else
                        {
                            UnitFormation tmp = city.Inside.UnitFormations[unitInsideClicked];
                            city.Inside.UnitFormations[unitInsideClicked] = city.Inside.UnitFormations[index];
                            city.Inside.UnitFormations[index] = tmp;
                        }

                        isUnitInsideClicked = false;
                        unitInsideClicked = -1;
                    }
                }
                else
                {
                    unitFormationsGUIManager.unitsInside[unitInsideClicked].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

                    isUnitInsideClicked = false;
                    unitInsideClicked = -1;
                }
            }
            else if (isUnitOutsideClicked)
            {
                //if (city.Inside.UnitFormations[index].Unit.Type != UnitType.None)
                //{
                    unitFormationsGUIManager.unitsOutside[unitOutsideClicked].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

                    if (city.Outside.UnitFormations[unitOutsideClicked].Unit.Type == city.Inside.UnitFormations[index].Unit.Type)
                    {
                        city.Inside.UnitFormations[index].Count += city.Outside.UnitFormations[unitOutsideClicked].Count;
                        city.Outside.UnitFormations[unitOutsideClicked] = new UnitFormation(Unit.CreateUnitNone(), 0);
                    }
                    else
                    {
                        UnitFormation tmp = city.Outside.UnitFormations[unitOutsideClicked];
                        city.Outside.UnitFormations[unitOutsideClicked] = city.Inside.UnitFormations[index];
                        city.Inside.UnitFormations[index] = tmp;
                    }

                    isUnitOutsideClicked = false;
                    unitOutsideClicked = -1;
                //}
                //else
                //{
                //    unitFormationsGUIManager.unitsOutside[unitOutsideClicked].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                //
                //    isUnitOutsideClicked = false;
                //    unitOutsideClicked = -1;
                //}
            }
            else if (city.Inside.UnitFormations[index].Unit.Type != UnitType.None)
            {
                unitFormationsGUIManager.unitsInside[index].color = new Color(1.0f, 1.0f, 0.75f, 1.0f);

                isUnitInsideClicked = true;
                unitInsideClicked = index;
            }
        }

        UpdateGarrision();
    }
}

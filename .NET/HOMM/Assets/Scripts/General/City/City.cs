using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class City
{
    [SerializeField]
    Faction faction;

    [SerializeField]
    Player owner = null;
    public Player Owner
    {
        get { return owner; }
        set { owner = value; }
    }

    Hero heroInside = null;
    public Hero HeroInside
    {
        get { return heroInside; }
        set { heroInside = value; }
    }

    Hero heroOutside = null;
    public Hero HeroOutside
    {
        get { return heroOutside; }
        set { heroOutside = value; }
    }

    [SerializeField]
    int goldPerTurn = 500;
    public int GoldPerTurn
    {
        get { return goldPerTurn; }
        set { goldPerTurn = value; }
    }

    [SerializeField]
    CityBuilding[] buildings =
        {
            new CityBuilding(CityBuilding.Type.TownHall, CityBuilding.Level.Built),
            new CityBuilding(CityBuilding.Type.Melee, CityBuilding.Level.NotExisting),
            new CityBuilding(CityBuilding.Type.Ranged, CityBuilding.Level.NotExisting),
            new CityBuilding(CityBuilding.Type.Cavalry, CityBuilding.Level.NotExisting),
            new CityBuilding(CityBuilding.Type.Titan, CityBuilding.Level.NotExisting),
        };
    public CityBuilding[] Buildings
    {
        get { return buildings; }
    }

    [SerializeField]
    UnitsGroup unitGroupInside;
    public UnitsGroup Inside
    {
        get { return unitGroupInside; }
    }

    UnitsGroup unitGroupOutside;
    public UnitsGroup Outside
    {
        get { return unitGroupOutside; }
    }

    public City()
    {
        unitGroupInside = new UnitsGroup(10);
        unitGroupOutside = new UnitsGroup(10);
    }

    public void AddVisitingHero(Hero hero)
    {
        heroOutside = hero;

        for (int i = 0; i < hero.UnitsGroup.UnitFormations.Length; i++)
        {
            unitGroupOutside.UnitFormations[i] = hero.UnitsGroup.UnitFormations[i];
            hero.UnitsGroup.UnitFormations[i] = new UnitFormation(Unit.CreateUnitNone(), 0);
        }
    }

    public void NextWeek()
    {
        foreach (var building in buildings)
        {
            building.RecrutedThisTurn = 0;
        }
    }

    public void NextDay()
    {
        foreach (var building in buildings)
        {
            if (building.BuildingLevel == CityBuilding.Level.Built)
            {
                if (owner != null)
                {
                    owner.Resources.AddResources(building.IncomePerDay);
                }
            }
            else if (building.BuildingLevel == CityBuilding.Level.Upgraded)
            {
                if (owner != null)
                {
                    owner.Resources.AddResources(building.IncomePerDayUpgraded);
                }
            }
        }
    }
}

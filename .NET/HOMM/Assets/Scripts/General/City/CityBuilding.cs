using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CityBuilding
{
    public enum Type
    {
        TownHall,
        Melee,
        Ranged,
        Cavalry,
        Titan,
    }

    public UnitType GetCompatibleUnitTypeToBuilding()
    {
        switch(type)
        {
            default:
                return UnitType.None;
            case Type.Melee:
                return BuildingLevel == Level.Upgraded ? UnitType.UpgradedMelee : UnitType.Melee;
            case Type.Ranged:
                return BuildingLevel == Level.Upgraded ? UnitType.UpgradedRanged : UnitType.Ranged;
            case Type.Cavalry:
                return BuildingLevel == Level.Upgraded ? UnitType.UpgradedCavalry : UnitType.Cavalry;
            case Type.Titan:
                return BuildingLevel == Level.Upgraded ? UnitType.UpgradedTitan : UnitType.Titan;
        }
    }

    public Resources GetRecruitCost()
    {
        switch (type)
        {
            default:
                return new Resources();
            case Type.Melee:
                return BuildingLevel == Level.Upgraded ? new Resources(150, 0, 0) : new Resources(100, 0, 0);
            case Type.Ranged:
                return BuildingLevel == Level.Upgraded ? new Resources(200, 0, 0) : new Resources(115, 0, 0);
            case Type.Cavalry:
                return BuildingLevel == Level.Upgraded ? new Resources(500, 0, 0) : new Resources(200, 0, 0);
            case Type.Titan:
                return BuildingLevel == Level.Upgraded ? new Resources(2000, 0, 0) : new Resources(1000, 0, 0);
        }
    }

    [SerializeField]
    Type type;
    public Type BuildingType
    {
        get { return type; }
        set { type = value; }
    }

    public enum Level
    {
        NotExisting,
        Built,
        Upgraded
    }
    [SerializeField]
    Level level;
    public Level BuildingLevel
    {
        get { return level; }
        set { level = value; }
    }

    [SerializeField]
    Resources buildingCost;
    public Resources BuildingCost
    {
        get { return buildingCost; }
        set { buildingCost = value; }
    }

    [SerializeField]
    Resources upgradeCost;
    public Resources UpgradeCost
    {
        get { return upgradeCost; }
        set { upgradeCost = value; }
    }

    [SerializeField]
    int maxRecruted;
    public int MaxRecruted
    {
        get { return maxRecruted; }
        set { maxRecruted = value; }
    }

    [SerializeField]
    int maxUpgradedRecruted;
    public int MaxUpgradedRecruted
    {
        get { return maxUpgradedRecruted; }
        set { maxUpgradedRecruted = value; }
    }

    [SerializeField]
    int recrutedThisTurn = 0;
    public int RecrutedThisTurn
    {
        get { return recrutedThisTurn; }
        set { recrutedThisTurn = value;}
    }

    [SerializeField]
    Resources incomePerWeek;
    public Resources IncomePerDay
    {
        get { return incomePerWeek; }
        set { incomePerWeek = value; }
    }

    [SerializeField]
    Resources incomePerWeekUpgraded;
    public Resources IncomePerDayUpgraded
    {
        get { return incomePerWeekUpgraded; }
        set { incomePerWeekUpgraded = value; }
    }
    public CityBuilding(Type type, Level level)
    {
        this.type = type;
        this.level = level;
    }

}

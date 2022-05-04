using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType
{
    None,

    Melee,
    UpgradedMelee,

    Ranged,
    UpgradedRanged,

    Cavalry,
    UpgradedCavalry,

    Titan,
    UpgradedTitan
}
[Serializable]
public class Unit
{
    public static Unit CreateUnitOfTypeAndFaction(UnitType type, Faction faction = Faction.Neutral)
    {
        switch (type)
        {
            default:
                return CreateUnitNone(faction);
            case UnitType.Melee:
                return CreateUnitMelee(faction);
            case UnitType.UpgradedMelee:
                return CreateUnitUpgradedMelee(faction);
            case UnitType.Ranged:
                return CreateUnitRanged(faction);
            case UnitType.UpgradedRanged:
                return CreateUnitUpgradedRanged(faction);
            case UnitType.Cavalry:
                return CreateUnitCavalry(faction);
            case UnitType.UpgradedCavalry:
                return CreateUnitUpgradedCavalry(faction);
            case UnitType.Titan:
                return CreateUnitTitan(faction);
            case UnitType.UpgradedTitan:
                return CreateUnitUpgradedTitan(faction);
        }
    }
    public static Unit CreateUnitNone(Faction faction = Faction.Neutral)
    {
        Unit unit = new Unit();
        unit.type = UnitType.None;

        return unit;
    }

    public static Unit CreateUnitMelee(Faction faction = Faction.Neutral)
    {
        Unit unit = new Unit();
        
        unit.type = UnitType.Melee;
        unit.faction = faction;

        switch(faction)
        {
            default:
                unit.icon = UnityEngine.Resources.Load<Sprite>("UnitsSprites/Melee");
                unit.health = 20;
                unit.attackPower = 5;
                unit.critChance = 0.05;
                unit.critMultiplyValue = 1.3;
                unit.maxAttackDistance = 1;
                unit.defensePower = 3;
                unit.maxDistancePerTurn = 4;
                break;
        }

        return unit;
    }
    public static Unit CreateUnitUpgradedMelee(Faction faction = Faction.Neutral)
    {
        Unit unit = new Unit();
        unit.type = UnitType.UpgradedMelee;
        unit.faction = faction;

        switch (faction)
        {
            default:
                unit.icon = UnityEngine.Resources.Load<Sprite>("UnitsSprites/UpgradedMelee");
                unit.health = 40;
                unit.attackPower = 7;
                unit.critChance = 0.07;
                unit.critMultiplyValue = 1.3;
                unit.maxAttackDistance = 1;
                unit.defensePower = 4;
                unit.maxDistancePerTurn = 4;
                break;
        }

        return unit;
    }
    public static Unit CreateUnitRanged(Faction faction = Faction.Neutral)
    {
        Unit unit = new Unit();
        unit.type = UnitType.Ranged;
        unit.faction = faction;

        switch (faction)
        {
            default:
                unit.icon = UnityEngine.Resources.Load<Sprite>("UnitsSprites/Ranged");
                unit.health = 10;
                unit.attackPower = 8;
                unit.critChance = 0.10;
                unit.critMultiplyValue = 1.5;
                unit.maxAttackDistance = 20;
                unit.defensePower = 0;
                unit.maxDistancePerTurn = 4;
                break;
        }

        return unit;
    }
    public static Unit CreateUnitUpgradedRanged(Faction faction = Faction.Neutral)
    {
        Unit unit = new Unit();
        unit.type = UnitType.UpgradedRanged;
        unit.faction = faction;

        switch (faction)
        {
            default:
                unit.icon = UnityEngine.Resources.Load<Sprite>("UnitsSprites/UpgradedRanged");
                unit.health = 15;
                unit.attackPower = 10;
                unit.critChance = 0.15;
                unit.critMultiplyValue = 1.5;
                unit.maxAttackDistance = 20;
                unit.defensePower = 1;
                unit.maxDistancePerTurn = 4;
                break;
        }

        return unit;
    }
    public static Unit CreateUnitCavalry(Faction faction = Faction.Neutral)
    {
        Unit unit = new Unit();
        unit.type = UnitType.Cavalry;
        unit.faction = faction;

        switch (faction)
        {
            default:
                unit.icon = UnityEngine.Resources.Load<Sprite>("UnitsSprites/Cavalry");
                unit.health = 15;
                unit.attackPower = 7;
                unit.critChance = 0.05;
                unit.critMultiplyValue = 1.3;
                unit.maxAttackDistance = 1;
                unit.defensePower = 3;
                unit.maxDistancePerTurn = 10;
                break;
        }

        return unit;
    }
    public static Unit CreateUnitUpgradedCavalry(Faction faction = Faction.Neutral)
    {
        Unit unit = new Unit();
        unit.type = UnitType.UpgradedCavalry;
        unit.faction = faction;

        switch (faction)
        {
            default:
                unit.icon = UnityEngine.Resources.Load<Sprite>("UnitsSprites/UpgradedCavalry");
                unit.health = 20;
                unit.attackPower = 9;
                unit.critChance = 0.05;
                unit.critMultiplyValue = 1.3;
                unit.maxAttackDistance = 1;
                unit.defensePower = 4;
                unit.maxDistancePerTurn = 12;
                break;
        }

        return unit;
    }
    public static Unit CreateUnitTitan(Faction faction = Faction.Neutral)
    {
        Unit unit = new Unit();
        unit.type = UnitType.Titan;
        unit.faction = faction;

        switch (faction)
        {
            default:
                unit.icon = UnityEngine.Resources.Load<Sprite>("UnitsSprites/Titan");
                unit.health = 50;
                unit.attackPower = 15;
                unit.critChance = 0.05;
                unit.critMultiplyValue = 2.0;
                unit.maxAttackDistance = 1;
                unit.defensePower = 5;
                unit.maxDistancePerTurn = 7;
                break;
        }

        return unit;
    }
    public static Unit CreateUnitUpgradedTitan(Faction faction = Faction.Neutral)
    {
        Unit unit = new Unit();
        unit.type = UnitType.UpgradedTitan;
        unit.faction = faction;

        switch (faction)
        {
            default:
                unit.icon = UnityEngine.Resources.Load<Sprite>("UnitsSprites/UpgradedTitan");
                unit.health = 80;
                unit.attackPower = 20;
                unit.critChance = 0.1;
                unit.critMultiplyValue = 2.0;
                unit.maxAttackDistance = 1;
                unit.defensePower = 8;
                unit.maxDistancePerTurn = 10;
                break;
        }

        return unit;
    }

    [SerializeField]
    Sprite icon;
    public Sprite Icon
    {
        get { return icon; }
    }

    [SerializeField]
    UnitType type;
    public UnitType Type
    {
        get { return type; }
    }

    [SerializeField]
    Faction faction;
    public Faction Faction
    {
        get { return faction; }
        set { faction = value; }
    }

    [SerializeField]
    int health;
    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    [SerializeField]
    int attackPower;
    public int AttackPower
    {
        get { return attackPower; }
        set { attackPower = value; }
    }

    [SerializeField]
    double critChance;
    public double CritChance
    {
        get { return critChance; }
        set { critChance = value; }
    }

    [SerializeField]
    double critMultiplyValue;
    public double CritMultiplyValue
    {
        get { return critMultiplyValue; }
        set { critMultiplyValue = value; }
    }

    [SerializeField]
    int maxAttackDistance;
    public int MaxAttackDistance
    {
        get { return maxAttackDistance; }
        set { maxAttackDistance = value; }
    }

    [SerializeField]
    int defensePower;
    public int DefensePower
    {
        get { return defensePower; }
        set { defensePower = value; }
    }

    [SerializeField]
    int maxDistancePerTurn;
    public int MaxDistancePerTurn
    {
        get { return maxDistancePerTurn; }
        set { maxDistancePerTurn = value; }
    }
}

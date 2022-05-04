using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Hero
{
    public enum PredefinedHero
    {
        Neutral = 0,
        Empty,

        Kanjiklub,
        BedOfChaos,
        KingOfTheGiants,
        Grandahl
    }
    public static Hero CreatePredefinedHero(PredefinedHero hero)
    {
        switch (hero)
        {
            default:
                return new Hero();
            case PredefinedHero.Neutral:
                return CreateHeroNeutral();
            case PredefinedHero.Kanjiklub:
                return CreateHeroKanjiklub();
            case PredefinedHero.BedOfChaos:
                return CreateHeroBedOfChaos();
            case PredefinedHero.KingOfTheGiants:
                return CreateHeroKingOfTheGiants();
            case PredefinedHero.Grandahl:
                return CreateHeroGrandahl();
        }
    }

    public static Hero CreateEmptyHero()
    {
        Hero hero = new Hero();

        hero.unitsGroup.UnitFormations[0] = new UnitFormation(Unit.CreateUnitCavalry(), 10);
        hero.unitsGroup.UnitFormations[1] = new UnitFormation(Unit.CreateUnitUpgradedCavalry(), 5);

        return hero;
    }

    static Hero CreateHeroNeutral()
    {
        Hero hero = new Hero();

        hero.unitsGroup.UnitFormations[0] = new UnitFormation(Unit.CreateUnitCavalry(), 10);
        hero.unitsGroup.UnitFormations[1] = new UnitFormation(Unit.CreateUnitUpgradedCavalry(), 5);

        return hero;
    }
    static Hero CreateHeroKanjiklub()
    {
        Hero hero = new Hero();
        hero.Icon = UnityEngine.Resources.Load<Sprite>("HeroesSprites/Kanjiklub");

        hero.heroStats.Level = 1;
        hero.heroStats.MaxDistancePerTurn = 10;

        hero.unitsGroup.UnitFormations[0] = new UnitFormation(Unit.CreateUnitMelee(), 30);
        hero.unitsGroup.UnitFormations[1] = new UnitFormation(Unit.CreateUnitRanged(), 20);

        return hero;
    }
    static Hero CreateHeroBedOfChaos()
    {
        Hero hero = new Hero();

        return hero;
    }
    static Hero CreateHeroKingOfTheGiants()
    {
        Hero hero = new Hero();

        return hero;
    }
    static Hero CreateHeroGrandahl()
    {
        Hero hero = new Hero();

        return hero;
    }
    
    [SerializeField]
    Sprite icon;
    public Sprite Icon
    {
        get { return icon; }
        set { icon = value; }
    }

    [NonSerialized]
    Player parent;
    public Player Parent
    {
        get { return parent; }
        set { parent = value; }
    }
    
    [SerializeField]
    HeroStats heroStats;
    public HeroStats HeroStats
    {
        get { return heroStats; }
    }

    [SerializeField]
    UnitsGroup unitsGroup;
    public UnitsGroup UnitsGroup
    {
        get { return unitsGroup; }
    }

    public void ChangeUnitsGroupSize(uint newSize)
    {
        var newGroup = new UnitsGroup(newSize);

        for (int i = 0; i < unitsGroup.UnitFormations.Length; ++i)
        {
            newGroup.UnitFormations[i] = unitsGroup.UnitFormations[i];
        }

        unitsGroup = newGroup;
    }

    private Hero()
    {
        heroStats = new HeroStats();
        unitsGroup = new UnitsGroup(10);
    }
}

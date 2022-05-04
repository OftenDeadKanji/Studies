using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    Faction faction;
    public Faction Faction
    {
        get { return faction; }
        set { faction = value; }
    }
    [SerializeField]
    List<Hero> heroList;
    public List<Hero> Heroes
    {
        get { return heroList; }
        set { heroList = value; }
    }
    [SerializeField]
    Resources resources;
    public Resources Resources
    {
        get { return resources; }
        set { resources = value; }
    }

    public Player()
    {
        heroList = new List<Hero>();
        resources = new Resources();
    }

    public Player(Faction faction)
    {
        this.faction = faction;
        heroList = new List<Hero>();
        resources = new Resources();
    }
}

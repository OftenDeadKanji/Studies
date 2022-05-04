using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HeroStats
{
    [SerializeField]
    uint level;
    public uint Level
    {
        get { return level; }
        set { level = value; }
    }

    [SerializeField]
    uint mana;
    public uint Mana
    {
        get { return mana; }
        set { mana = value; }
    }

    [SerializeField]
    uint maxMana;
    public uint MaxMana
    {
        get { return maxMana; }
        set { maxMana = value; }
    }

    [SerializeField]
    uint maxDistancePerTurn;
    public uint MaxDistancePerTurn
    {
        get { return maxDistancePerTurn; }
        set { maxDistancePerTurn = value; }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UnitFormation
{
    [SerializeField]
    Unit unit;
    public Unit Unit
    {
        get { return unit; }
        set { unit = value; }
    }

    [SerializeField]
    int count;
    public int Count
    {
        get { return count; }
        set { count = value; }
    }

    public UnitFormation(Unit unit, int count)
    {
        this.unit = unit;
        this.count = count;
    }
}

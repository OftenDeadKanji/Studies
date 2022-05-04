using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UnitsGroup
{
    [SerializeField]
    UnitFormation[] units;
    public UnitFormation[] UnitFormations
    {
        get { return units; }
    }

    public UnitsGroup(uint capacity = 7)
    {
        units = new UnitFormation[capacity];
        for(int i = 0; i < units.Length;++i)
        {
            units[i] = new UnitFormation(Unit.CreateUnitNone(), 0);
        }
    }

    public bool TryToAddUnitFormation(UnitFormation unitFormation)
    {
        for(int i = 0; i < units.Length; ++i)
        {
            if(units[i].Unit.Type == UnitType.None)
            {
                units[i] = unitFormation;

                return true;
            }
        }

        return false;
    }

    public bool IsFull()
    {
        for (int i = 0; i < units.Length; ++i)
        {
            if (units[i].Unit.Type == UnitType.None)
            {
                return false;
            }
        }

        return true;
    }

    public bool HasAnyUnits()
    {
        foreach(var unitFormation in units)
        {
            if(unitFormation.Unit.Type != UnitType.None)
            {
                if(unitFormation.Count > 0)
                {
                    return true;
                }
            }
        }

        return false;
    }
}

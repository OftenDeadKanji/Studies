using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Resources
{
    //[Serializable]
    public enum Type
    {
        Gold,
        Wood,
        Stone
    }
    [Serializable]
    private class Resource
    {
        public Resource(Type type)
        {
            this.type = type;
            amount = 0;
        }
        public Resource(Type type, int amount)
        {
            this.type = type;
            this.amount = amount;
        }

        public Type type;
        public int amount;
    };

    [SerializeField]
    Resource[] resourcesAmount;
    public int Gold
    {
        get { return resourcesAmount[0].amount; }
        set { resourcesAmount[0].amount = value; }
    }
    public int Wood
    {
        get { return resourcesAmount[1].amount; }
        set { resourcesAmount[1].amount = value; }
    }
    public int Stone
    {
        get { return resourcesAmount[2].amount; }
        set { resourcesAmount[2].amount = value; }
    }

    public Resources()
    {
        resourcesAmount = new Resource[3];
        
        resourcesAmount[0] = new Resource(Type.Gold);
        resourcesAmount[1] = new Resource(Type.Wood);
        resourcesAmount[2] = new Resource(Type.Stone);
    }

    public Resources(int gold, int wood, int stone)
    {
        resourcesAmount = new Resource[3];

        resourcesAmount[0] = new Resource(Type.Gold, gold);
        resourcesAmount[1] = new Resource(Type.Wood, wood);
        resourcesAmount[2] = new Resource(Type.Stone, stone);
    }

    public void AddResources(Type type, int amount)
    {
        switch(type)
        {
            case Type.Gold:
                resourcesAmount[0].amount += amount;
                break;
            case Type.Wood:
                resourcesAmount[1].amount += amount;
                break;
            case Type.Stone:
                resourcesAmount[2].amount += amount;
                break;
        }
    }

    public void AddResources(Resources resources)
    {
        resourcesAmount[0].amount += resources.Gold;
        resourcesAmount[1].amount += resources.Wood;
        resourcesAmount[2].amount += resources.Stone;
    }

    public void SubtractResources(Type type, int amount)
    {
        switch (type)
        {
            case Type.Gold:
                resourcesAmount[0].amount -= amount;
                break;
            case Type.Wood:
                resourcesAmount[1].amount -= amount;
                break;
            case Type.Stone:
                resourcesAmount[2].amount -= amount;
                break;
        }
    }

    public void SubtractResources(Resources resources)
    {
        resourcesAmount[0].amount -= resources.Gold;
        resourcesAmount[1].amount -= resources.Wood;
        resourcesAmount[2].amount -= resources.Stone;
    }

    public static bool operator ==(Resources left, Resources right)
    {
        return left.Gold == right.Gold && left.Wood == right.Wood && left.Stone == right.Stone;
    }
    public static bool operator !=(Resources left, Resources right)
    {
        return left.Gold != right.Gold || left.Wood != right.Wood || left.Stone != right.Stone;
    }
    public static bool operator <(Resources left, Resources right)
    {
        return left.Gold < right.Gold && left.Wood < right.Wood && left.Stone < right.Stone;
    }
    public static bool operator <=(Resources left, Resources right)
    {
        return left.Gold <= right.Gold && left.Wood <= right.Wood && left.Stone <= right.Stone;
    }

    public static bool operator >(Resources left, Resources right)
    {
        return left.Gold > right.Gold && left.Wood > right.Wood && left.Stone > right.Stone;
    }
    public static bool operator >=(Resources left, Resources right)
    {
        return left.Gold >= right.Gold && left.Wood >= right.Wood && left.Stone >= right.Stone;
    }

    public static Resources operator *(Resources r, int i)
    {
        return new Resources(r.Gold * i, r.Wood * i, r.Stone * i);
    }

    public static Resources operator *(int i, Resources r)
    {
        return new Resources(r.Gold * i, r.Wood * i, r.Stone * i);
    }
}

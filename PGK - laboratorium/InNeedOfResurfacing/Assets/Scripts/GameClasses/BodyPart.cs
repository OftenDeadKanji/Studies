using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum bodyPartType { arm, leg, head, other};
public class BodyPart //Klasa bazowa dla ekwipowalnych części ciała.
{
    public int durability = 10;
    public int maxDurability = 10;
    public int attackPoints = 0;
    public int mohsHardness = 5;
    public string partName;
    public bodyPartType type;

    public BodyPart(int maxDurability, int attackPoints, int mohsHardness, string partName, bodyPartType type)
    {
        this.maxDurability = maxDurability;
        durability = maxDurability;
        this.attackPoints = attackPoints;
        this.mohsHardness = mohsHardness;
        this.partName = partName;
        this.type = type;
    }

    public BodyPart(BodyPart bodyPart)
    {
        this.maxDurability = bodyPart.maxDurability;
        durability = maxDurability;
        this.attackPoints = bodyPart.attackPoints;
        this.mohsHardness = bodyPart.mohsHardness;
        this.partName = bodyPart.partName;
        this.type = bodyPart.type;
    }

    public int takeDamage(int damage)
    {
        damage -= mohsHardness;
        if (damage < 0) damage = 0;
        durability -= damage;
        if (durability < 0)
            durability = 0;
        return durability;
    }

    public int recover(int healing)
    {
        durability += healing;
        if (durability > maxDurability)
            durability = maxDurability;
        return healing;
    }
}

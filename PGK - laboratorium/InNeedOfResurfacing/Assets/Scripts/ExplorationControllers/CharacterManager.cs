using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    //Stats:
    [SerializeField] public int hitPoints;
    [SerializeField] public int maxHP;
    [SerializeField] protected int attackPoints;
    [SerializeField] protected int mohsHardness;
    [SerializeField] protected int speedPoints;
    protected bool isAttacking = false;
    //protected bool isCreated = false;
    public bool isPlayer = false;

    public CharacterManager(CharacterManager character)
    {
        this.hitPoints = character.hitPoints;
        this.maxHP = character.maxHP;
        this.attackPoints = character.attackPoints;
        this.mohsHardness = character.mohsHardness;
        this.speedPoints = character.speedPoints;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void takeDamage(int damage)
    {
        damage -= mohsHardness;
        if (damage < 0) damage = 0;
        hitPoints -= damage;
    }

    public void recover(int healing)
    {
        hitPoints += healing;
        if (hitPoints > maxHP) hitPoints = maxHP;
    }

    public int getSpeed()
    {
        return speedPoints;
    }

    public bool getAttacking()
    {
        return isAttacking;
    }

    public void setAttacking(bool isAttacking)
    {
        this.isAttacking = isAttacking;
    }
}

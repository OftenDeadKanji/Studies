using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : CharacterManager
{
    public bool gameStart = false;
    private static bool isCreated = false;
    public List<EnemyManager> encountered = new List<EnemyManager>();
    public List<string> encounteredStr = new List<string>();
    public List<string> defeated = new List<string>();
    public List<BodyPart> bodyPartsPrefabs;
    public List<BodyPart> bodyParts;
    public Vector3 tempPos;
    public int invincibleFlee = 0;
    public Button buttonQuest;
    public Text textButton;
    public bool isQuestToKillEnemiesActive = false;

    public List<int> pickableAlreadyPicked = new List<int>();

    private void Awake()
    {
        if (!isCreated)
        {
            DontDestroyOnLoad(this.gameObject);
            bodyPartsPrefabs = new List<BodyPart>();
            bodyParts = new List<BodyPart>();
            bodyPartsPrefabs.Add(new BodyPart(10, 4, 4, "Fluorite Arm", bodyPartType.arm));
            bodyPartsPrefabs.Add(new BodyPart(10, 4, 4, "Fluorite Arm", bodyPartType.arm));
            bodyPartsPrefabs.Add(new BodyPart(15, 1, 4, "Fluorite Leg", bodyPartType.leg));
            bodyPartsPrefabs.Add(new BodyPart(15, 1, 4, "Fluorite Leg", bodyPartType.leg));
            foreach (BodyPart bodyPart in bodyPartsPrefabs)
                bodyParts.Add(new BodyPart(bodyPart));
            isPlayer = true;
            isCreated = true;
            tempPos = transform.position;
        }
    }

    public PlayerManager(PlayerManager player) : base(player)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibleFlee > 0) --invincibleFlee;
    }

    public override void takeDamage(int damage)
    {
        if (bodyParts.Count == 0)
        {
            base.takeDamage(damage);
            Debug.Log("Player took " + (damage - base.mohsHardness) + " direct damage!");
            Debug.Log("HP remaining: " + hitPoints);
        }
        else
        {
            System.Random rng = new System.Random();
            int rand = rng.Next(0, bodyParts.Count - 1);
            Debug.Log("Player took " + (damage - bodyParts[rand].mohsHardness) + " damage to " + bodyParts[rand].partName + "!");
            if (bodyParts[rand].takeDamage(damage) <= 0)
                bodyParts.RemoveAt(rand);
        }
        if(hitPoints <= 0)
        {
            BattleManager battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
            battleManager.endBattle(false);
        }
    }

    public void attack(EnemyManager target) //, float distance)
    {
        if (bodyParts.Count == 0)
            target.takeDamage(attackPoints);
        else
        {
            int attack = bodyParts.Max( b => b.attackPoints);
            target.takeDamage(attack);
        }
        //target.takeDamage(Convert.ToInt32(attackPoints / distance));
        //Debug.Log("Attacked.");
    }

    public void acceptQuest()
    {
        this.isQuestToKillEnemiesActive = true;
        textButton.text = "Quest accepted!";
        buttonQuest.enabled = false;
    }
}

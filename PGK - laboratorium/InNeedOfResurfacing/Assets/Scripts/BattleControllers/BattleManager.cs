using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    [SerializeField] Light battleMainLight;

    private bool playerTurn = false;
    private bool isPaused = false;
    //private bool enemyTurn = false;
    [SerializeField] private GameObject battleUI;
    [SerializeField] private GameObject endUI;
    [SerializeField] private PlayerBattleMovement playerMovement;
    private PlayerManager playerManager;
    public List<EnemyManager> enemies = new List<EnemyManager>();
    public GameObject[] enemySpots;
    public TextMesh[] hps;
    private List<CharacterManager> turnQueue = new List<CharacterManager>();
    private int currentAttacker = 0;
    private int defeatedCounter = 0;
    // Start is called before the first frame update

    public TextMesh playerHP;
    public Text[] bodyPartsNames;
    public Text[] bodyPartsHps;

    void Start()
    {
        if(CrossSceneInformation.currentLightSource != null)
        {
            if (CrossSceneInformation.currentLightSource.IsActive)
            {
                switch (CrossSceneInformation.currentLightSource.FlameColor)
                {
                    case LightSource.Color.Yellow:
                        battleMainLight.color = Color.yellow;
                        break;
                    case LightSource.Color.Blue:
                        battleMainLight.color = Color.blue;
                        break;
                    case LightSource.Color.Green:
                        battleMainLight.color = Color.green;
                        break;
                }
            }
            else
            {
                battleMainLight.color = new Color(0.1f, 0.1f, 0.1f);
            }
        }
        else
        {
            battleMainLight.color = new Color(0.1f, 0.1f, 0.1f);
        }

        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        enemies = new List<EnemyManager>(playerManager.encountered.Count);
        foreach (EnemyManager enemy in playerManager.encountered)
        {
            if (CrossSceneInformation.currentLightSource != null)
            {
                enemy.hitPoints = CrossSceneInformation.currentLightSource.IsActive ? (int)(0.5f * enemy.maxHP) : (int)(1.5f * enemy.maxHP);
            }
            enemies.Add(enemy);
        }
        for (int i = 0; i < playerManager.encountered.Count; i++)
        {
            //enemySpots[i].AddComponent(enemies[i]);
            Sprite sprite = Resources.Load("Sprites/" + playerManager.encountered[i].sprite, typeof(Sprite)) as Sprite;
            enemySpots[i].GetComponent<SpriteRenderer>().sprite = sprite;
            enemySpots[i].SetActive(true);
        }
        turnQueue.Add(playerManager);
        foreach (EnemyManager enemy in enemies)
            turnQueue.Add(enemy);
        turnQueue = turnQueue.OrderByDescending(turn => turn.getSpeed()).ToList();
        refreshBodyPartsDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
            return;
        foreach(EnemyManager enemy in enemies)
            if (enemy.hitPoints <= 0)
            {
                enemySpots[enemies.IndexOf(enemy)].SetActive(false);
                defeatedCounter++;
            }
        if (defeatedCounter == enemies.Count)
            endBattle(true);

        if(!turnQueue[currentAttacker].getAttacking())
        {
            if (turnQueue[currentAttacker].isPlayer)
                startPlayerTurn();
            else
                startEnemyTurn();

            if (playerTurn)
            {
                battleUI.SetActive(true);
                playerMovement.canMove = false;
            }
            else if (!playerTurn)
            {
                battleUI.SetActive(false);
                playerMovement.canMove = true;
                StartCoroutine(enemyAttack());
            }
        }

        for(int i = 0; i < playerManager.encountered.Count; i++)
        {
            hps[i].text = playerManager.encountered[i].hitPoints.ToString();
        }
        playerHP.text = playerManager.hitPoints.ToString();
        refreshBodyPartsDisplay();
    }

    public void refreshBodyPartsDisplay()
    {
        foreach (Text name in bodyPartsNames)
            name.text = "";
        foreach (Text hp in bodyPartsHps)
            hp.text = "";
        for (int i = 0; i < playerManager.bodyParts.Count; i++)
        {
            BodyPart bodyPart = playerManager.bodyParts[i];
            bodyPartsNames[i].text = bodyPart.partName;
            bodyPartsHps[i].text = bodyPart.durability + "/" + bodyPart.maxDurability;
        }
    }

    public void advanceTurn()
    {
        currentAttacker++;
        if (currentAttacker >= turnQueue.Count)
            currentAttacker = 0;
    }

    public void attack()
    {
        battleUI.SetActive(false);
        playerMovement.canMove = true;
        playerManager.setAttacking(true);
        //playerMovement.canAttack = true;
    }

    public void defend()
    {
        advanceTurn();
    }

    public void useItem()
    {
        advanceTurn();
    }

    public void flee()
    {
        //Tutaj masz dumanie w cztery pierony tak wiec masz timeouta zanim znowu zaczniesz walczyc:
        playerManager.invincibleFlee = 50;
        SceneManager.LoadScene(0);
    }

    public IEnumerator enemyAttack()
    {
        //enemyTurn = false;
        EnemyManager enemy = turnQueue[currentAttacker] as EnemyManager;
        enemy.setAttacking(true);
        yield return StartCoroutine(enemy.attack());
        advanceTurn();
        //playerTurn = true;
    }

    public void startPlayerTurn()
    {
        playerTurn = true;
        //enemyTurn = false;
    }

    public void startEnemyTurn()
    {
        playerTurn = false;
        //enemyTurn = true;
    }

    public void endBattle(bool victory)
    {
        StopAllCoroutines();
        playerTurn = false;
        turnQueue[currentAttacker].setAttacking(false);
        isPaused = true;

        if (victory)
        {
            // O tutaj se usuwa
            foreach (string who in playerManager.encounteredStr) playerManager.defeated.Add(who);
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
        //enemyTurn = false;
        //endUI.SetActive(true);
        //Text endText = endUI.GetComponentInChildren<Text>();
        //if (victory)
        //    endText.text = "Got 'em.";
        //else
        //    endText.text = "F.";

        //Nie wiem czemu to jest okomentowane, wg mnie da³oby to wiêcej "pizzazz"!
    }

    public void restartBattle()
    {
        //turnQueue[currentAttacker].setAttacking(false);
        isPaused = false;
        endUI.SetActive(false);
        //666, srsly?
        playerManager.recover(666);
        foreach (EnemyManager enemy in enemies)
        {
            enemy.recover(666);
            enemySpots[enemies.IndexOf(enemy)].SetActive(true);
        }
        currentAttacker = 0;
    }
}
//WeŸcie dodajcie wincyj przeciwników potem to potestujê czy dzia³a lub nie
//^ Nieaktualne, wszystko dzia³a jak natura chcia³a

// WA¯NE: PRZYPISUJCIE PRZECIWNIKOM NA PLANSZY UNIKALNE NAZWY!!! Inaczej jak bêd¹ dwa nazwane tak samo to siê usun¹ naraz!
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EnemyManager : CharacterManager
{
    ExplorationManager explorationManager;

    private GridBehavior currentGrid;
    private int selectedIndex;
    private GridField selectedField;
    //private int cooldown = 0;
    public int attackDuration = 4;
    [SerializeField] private GameObject bulletType;
    [SerializeField] private int count = 1;
    //public string name;
    private GameObject currentBullet;
    public string sprite;
    //public bool isAttacking = false;

    public EnemyManager(EnemyManager enemy) : base(enemy)
    {
        this.bulletType = enemy.bulletType;
        this.count = enemy.count;
        this.sprite = enemy.sprite;
    }

    // Start is called before the first frame update
    void Start()
    {
        explorationManager = GameObject.Find("ExplorationManager").GetComponent<ExplorationManager>();
        PlayerManager playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        //Debug.Log("AAAAA: " + playerManager.defeated.Count);

        for (int i = 0; i < playerManager.defeated.Count; ++i)
        {
            //Debug.Log("BBBBB: " + playerManager.defeated[i]);
            if (playerManager.defeated[i].Equals(this.ToString())) Destroy(gameObject);
        }

        //isAttacking = false;
        sprite = gameObject.GetComponent<SpriteRenderer>().sprite.name;
        //Debug.Log("");
    }

    // Update is called once per frame
    void Update()
    {
        //if (cooldown == 0 && isAttacking && attackDuration > 0)
        //{
        //    Destroy(currentBullet);
        //    currentGrid = GameObject.Find("Grid").GetComponent<GridBehavior>();
        //    selectedIndex = Random.Range(0, currentGrid.fields.Length);
        //    selectedField = currentGrid.fields.GetValue(selectedIndex) as GridField;
        //    Vector3 temppos = selectedField.transform.position;
        //    temppos.y += 1.0f;
        //    currentBullet = Instantiate(bulletType, temppos, Quaternion.identity);
        //    cooldown = 120;
        //    attackDuration--;
        //}
        //else if (cooldown > 0)
        //    cooldown--;
        //else if (attackDuration == 0)
        //    isAttacking = false;
    }

    public IEnumerator attack()
    {
        isAttacking = true;
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < attackDuration; i++)
        {
            //yield return new WaitForSeconds(1.0f);
            Destroy(currentBullet);
            currentGrid = GameObject.Find("Grid").GetComponent<GridBehavior>();
            selectedIndex = Random.Range(0, currentGrid.fields.Length);
            selectedField = currentGrid.fields.GetValue(selectedIndex) as GridField;
            Vector3 temppos = selectedField.transform.position;
            temppos.y += 2.0f;
            currentBullet = Instantiate(bulletType, temppos, Quaternion.identity);
            yield return new WaitForSeconds(3.0f);
        }
        Destroy(currentBullet);
        isAttacking = false;
    }

    public override void takeDamage(int damage)
    {
        base.takeDamage(damage);
        Debug.Log("Enemy took " + (damage - base.mohsHardness) + " damage!");
        Debug.Log("HP remaining: " + hitPoints);
        //if (hitPoints <= 0)
        //    gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            Debug.Log("Fight!");

            PlayerManager playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
            
            //Jak masz immunitet po dumaniu:
            if (playerManager.invincibleFlee > 0) return;

            playerManager.tempPos = collision.collider.gameObject.transform.position;
            playerManager.encountered.Clear();
            playerManager.encounteredStr.Clear();
            for (int i = 0; i < count; i++)
            {
                playerManager.encountered.Add(this);
                playerManager.encounteredStr.Add(this.ToString());
            }

            CrossSceneInformation.currentLightSource = explorationManager.NearestTorch;

            SceneManager.LoadScene(1);
        }
    }
}

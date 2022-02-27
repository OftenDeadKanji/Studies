using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattleMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    //[SerializeField] CharacterController charControl;
    private Vector3 movementDirection = Vector3.zero;
    private RaycastHit hit;
    private GridBehavior currentGrid;
    PlayerManager playerManager;
    private float[] keyCheck = new float[2];  // 0 up-down   1 left-right
    private int movementLock = 0;
    public bool canMove = false;
    //public bool canAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetAxis("Horizontal") != 0.0f || Input.GetAxis("Vertical") != 0.0f) && canMove)
            handleMovement();
        else if (movementLock > 0)
            movementLock--;
        else if (Input.GetButton("Fire1") && playerManager.getAttacking())
            handleAttack();
    }

    private void handleMovement()
    {
        if (Input.GetAxis("Vertical") != 0.0f) keyCheck[0] += 1.0f;
        else keyCheck[0] = 0.0f;
        if (Input.GetAxis("Horizontal") != 0.0f) keyCheck[1] += 1.0f;
        else keyCheck[1] = 0.0f;
        if (keyCheck[0] > 2.0f) keyCheck[0] = 2.0f;
        if (keyCheck[1] > 2.0f) keyCheck[1] = 2.0f;

        currentGrid = GameObject.Find("Grid").GetComponent<GridBehavior>();
        foreach (GridField field in currentGrid.fields)
        {
            if (Vector3.Distance(field.transform.position, transform.position) <= Mathf.Epsilon)
            {
                field.gameObject.layer = 2;
            }
            else
                field.gameObject.layer = 8;
        }
        movementDirection[0] = -Input.GetAxis("Vertical") * speed;
        movementDirection[1] = 0.0f;
        movementDirection[2] = Input.GetAxis("Horizontal") * speed;
        Debug.DrawRay(transform.position, movementDirection);
        if (Physics.Raycast(transform.position, movementDirection, out hit, Mathf.Infinity, LayerMask.GetMask("Field")) && movementLock == 0)
        {
            transform.position = hit.collider.transform.position;
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
            movementLock = 1;
        }
    }

    private void handleAttack()
    {
        //Collider[] enemies = Physics.OverlapSphere(transform.position, 5.0f, LayerMask.GetMask("Enemy"));
        BattleManager battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        if (battleManager.enemies.Count > 0)
        {
            float shortestDistance = 50.0f;
            int target = -1;
            foreach(EnemyManager enemy in battleManager.enemies)
            {
                float distance = Vector3.Distance(transform.position, battleManager.enemySpots[battleManager.enemies.IndexOf(enemy)].transform.position);
                if (distance <= shortestDistance)
                    target = battleManager.enemies.IndexOf(enemy);
            }
            if(target != -1)
            {
                playerManager.attack(battleManager.enemies[target]); //, shortestDistance/5.0f);
            }
        }
        //canAttack = false;
        playerManager.setAttacking(false);
        battleManager.advanceTurn();
    }
}

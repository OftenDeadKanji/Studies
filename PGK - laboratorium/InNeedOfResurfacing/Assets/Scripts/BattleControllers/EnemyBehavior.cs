using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBehavior : MonoBehaviour
{
    private GridBehavior currentGrid;
    private int selectedIndex;
    private GridField selectedField;
    private int cooldown = 0;
    public int attackDuration = 4;
    [SerializeField] private GameObject bulletType;
    //private GameObject currentBullet;
    private int hitPoints;
    private bool isAttacking;
    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
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
        for (int i = 0; i < attackDuration; i++)
        {
            //yield return new WaitForSeconds(1.0f);
            currentGrid = GameObject.Find("Grid").GetComponent<GridBehavior>();
            selectedIndex = Random.Range(0, currentGrid.fields.Length);
            selectedField = currentGrid.fields.GetValue(selectedIndex) as GridField;
            Vector3 temppos = selectedField.transform.position;
            temppos.y += 2.0f;
            GameObject currentBullet = Instantiate(bulletType, temppos, Quaternion.identity);
            //cooldown = 120;
            //attackDuration--;
            yield return new WaitForSeconds(3.0f);
            Destroy(currentBullet);
        }
        //startPlayerTurn();
    }
}

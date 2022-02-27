using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int damage;
    //private int baseDamage = 2;
    // Start is called before the first frame update
    void Start()
    {
        damage = Random.Range(4, 8);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 0.0f)
        {
            Vector3 fall = transform.position;
            fall.y -= 0.05f;
            transform.position = fall;
        }
     }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            PlayerManager playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
            playerManager.takeDamage(damage);
        }
    }
}

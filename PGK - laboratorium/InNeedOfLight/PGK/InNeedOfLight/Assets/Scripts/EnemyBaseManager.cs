using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseManager : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    float spawnMinRadius = 3.0f;
    [SerializeField]
    float spawnMaxRadius = 6.0f;

    [SerializeField]
    public int maxEnemySpawned = 5;
    [SerializeField]
    public float spawnCooldown = 3.0f; //in sec
    float spawnCooldownLeft = 0.0f; //in sec

    List<GameObject> spawnedEnemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if (enemyPrefab == null)
        {
            throw new System.Exception("enemyPrefab object is null!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnedEnemies.Count < maxEnemySpawned)
        {
            spawnCooldownLeft += Time.deltaTime;
            if (spawnCooldownLeft >= spawnCooldown)
            {
                spawnCooldownLeft = 0.0f;

                float xDiff = Random.Range(spawnMinRadius, spawnMaxRadius);
                if (Random.Range(0.0f, 1.0f) < 0.5)
                {
                    xDiff *= -1;
                }

                float yDiff = Random.Range(spawnMinRadius, spawnMaxRadius);
                if (Random.Range(0.0f, 1.0f) < 0.5)
                {
                    yDiff *= -1;
                }

                var enemyPos = transform.position + new Vector3(xDiff, yDiff, 0.0f);
                var newlySpawned = Instantiate<GameObject>(enemyPrefab, enemyPos, Quaternion.identity);

                EnemyController enemyController = newlySpawned.GetComponent<EnemyController>();
                if (enemyController != null)
                {
                    enemyController.SetMotherBase(gameObject);
                    spawnedEnemies.Add(newlySpawned);
                }
                else
                {
                    Destroy(newlySpawned);
                }
            }
        }
        else
        {
            spawnedEnemies.RemoveAll(s => s == null);
        }
    }
}

using UnityEngine;

public class EnemyController : MonoBehaviour
{
    CharacterCore character = new CharacterCore();

    GameObject player;
    GameObject motherBase;

    [SerializeField]
    float distanceToChasePlayer = 5.0f;

    [SerializeField]
    GameObject oilPrefab;

    void Start()
    {
        player = GameObject.Find("Player");
        if (player == null)
        {
            throw new System.Exception("Player object is null!");
        }
    }

    private void Update()
    {
        if (character.IsDead())
        {
            int drops = Random.Range(0, 4);

            for (int i = 0; i < drops; ++i)
            {
                Vector3 posDiff = Random.insideUnitCircle;
                var pos = transform.position + posDiff;
                Instantiate(oilPrefab, pos, Quaternion.identity);
            }
            
            Destroy(gameObject);
        }

    }

    void FixedUpdate()
    {
        var currentPos = this.transform.position;
        var playerPos = player.transform.position;
        Vector3 basePos = new Vector3();

        if (motherBase != null)
        {
            basePos = motherBase.transform.position;
        }

        if (Vector3.Distance(currentPos, playerPos) <= distanceToChasePlayer)
        {
            character.MoveDirection = playerPos - currentPos;
            character.Speed = character.maxWalkingSpeed * 0.9f;

            transform.position = currentPos + character.MoveDirection * character.Speed * Time.deltaTime;
        }
        else if (motherBase != null && Vector3.Distance(currentPos, basePos) > 5.0f)
        {
            character.MoveDirection = basePos - currentPos;
            character.Speed = character.maxWalkingSpeed * 0.4f;

            transform.position = currentPos + character.MoveDirection * character.Speed * Time.deltaTime;
        }
        else
        {
            character.Speed = 0.0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Weapon"))
        {
            character.Health -= 40;

            var currentPos = this.transform.position;
            var playerPos = player.transform.position;

            var direction = (playerPos - currentPos).normalized;

            transform.position = currentPos - direction * 1f;
        }
    }

    public void SetMotherBase(GameObject motherBase)
    {
        this.motherBase = motherBase;
    }
}

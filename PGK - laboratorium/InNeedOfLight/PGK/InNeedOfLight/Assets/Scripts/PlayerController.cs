using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public CharacterCore character = new CharacterCore();

    public Camera playerCamera;
    Vector3 cameraDistance = new Vector3(0.0f, 0.0f, -10.0f);

    [SerializeField]
    GameObject weapon;

    [SerializeField]
    float attackCooldown = 0.5f; //in sec
    [SerializeField]
    float attackCooldownLeft = 0.0f;

    [SerializeField]
    TMPro.TMP_Text health;
    [SerializeField]
    TMPro.TMP_Text hunger;

    float hungerlossSpeed = 0.1f; //per sec
    public float currentHunger = 100.0f;

    float getAttackColldown = 0.1f;
    float getAttackColldownLeft = 0f;

    List<GameObject> interavtiveObjects = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        checkUserInput();

        interavtiveObjects.RemoveAll(s => s == null);

        if (getAttackColldownLeft > 0.0f)
        {
            getAttackColldownLeft -= Time.deltaTime;
        }

        updateHunger();
        updateHealth();
    }

    private void FixedUpdate()
    {
        this.transform.position = this.transform.position + character.MoveDirection * character.Speed * Time.deltaTime;
        playerCamera.transform.position = this.transform.position + cameraDistance;
    }

    void updateHunger()
    {
        currentHunger -= hungerlossSpeed * Time.deltaTime;

        hunger.text = ((int)currentHunger).ToString();
    }

    void updateHealth()
    {
        if (currentHunger >= 75)
        {
            character.Health += 0.5f * Time.deltaTime;
        }
        else if (currentHunger >= 50)
        {
            character.Health += 0.3f * Time.deltaTime;
        }

        health.text = ((int)character.Health).ToString();
    }

    void checkUserInput()
    {
        checkMovement();
        checkAttack();
        checkInteraction();
    }

    void checkMovement()
    {
        Vector3 newDirection = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            newDirection.y = 1.0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            newDirection.y = -1.0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            newDirection.x = -1.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            newDirection.x = 1.0f;
        }

        if (newDirection.x == 0.0f && newDirection.y == 0.0f)
        {
            character.Speed = 0.0f;
        }
        else
        {
            character.Speed = character.maxWalkingSpeed;
        }

        character.MoveDirection = newDirection;

    }

    void checkAttack()
    {
        if (attackCooldownLeft > 0.0f)
        {
            attackCooldownLeft -= Time.deltaTime;

            if (attackCooldownLeft <= attackCooldown * 0.5f)
            {
                weapon.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                weapon.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            attackCooldownLeft = attackCooldown;
            weapon.SetActive(true);

            var mousePos = playerCamera.ScreenToWorldPoint(Input.mousePosition);
            var attackDir = (new Vector3(mousePos.x, mousePos.y) - transform.position).normalized;
            weapon.transform.position = transform.position + attackDir * 0.5f;

            float angle = AngleBetweenTwoPoints(transform.position, mousePos);

            Debug.Log("Kąt: " + angle.ToString());
            weapon.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 90));
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        Debug.Log("A (góra):" + a.ToString());
        Debug.Log("B (atak):" + b.ToString());

        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    void checkInteraction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (interavtiveObjects.Count > 0)
            {
                var interactive = interavtiveObjects[0].GetComponent<Interactive>();
                if (interactive != null)
                {
                    interactive.Interact();
                }

                if (interavtiveObjects.Count > 0)
                {
                    if (interavtiveObjects[0].GetComponent<Outline>() == null)
                    {
                        var outline = interavtiveObjects[0].AddComponent<Outline>();

                        outline.OutlineMode = Outline.Mode.OutlineAll;
                        outline.OutlineColor = Color.red;
                        outline.OutlineWidth = 3f;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Interactive"))
        {
            interavtiveObjects.Add(other.gameObject.transform.parent.gameObject);

            if (interavtiveObjects[0].GetComponent<Outline>() == null)
            {
                var outline = interavtiveObjects[0].AddComponent<Outline>();

                outline.OutlineMode = Outline.Mode.OutlineAll;
                outline.OutlineColor = Color.red;
                outline.OutlineWidth = 5f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Interactive"))
        {
            var gameObject = other.gameObject.transform.parent.gameObject;
            interavtiveObjects.Remove(gameObject);

            if (gameObject.GetComponent<Outline>() != null)
            {
                Destroy(gameObject.GetComponent<Outline>());
            }

            if (interavtiveObjects.Count > 0)
            {
                if (interavtiveObjects[0].GetComponent<Outline>() == null)
                {
                    var outline = interavtiveObjects[0].AddComponent<Outline>();

                    outline.OutlineMode = Outline.Mode.OutlineAll;
                    outline.OutlineColor = Color.red;
                    outline.OutlineWidth = 3f;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            if (getAttackColldownLeft <= 0.0f)
            {
                getAttackColldownLeft = getAttackColldown;

                character.Health -= 10;

                if (character.IsDead())
                {
                    Application.LoadLevel(Application.loadedLevel);
                }

                var currentPos = this.transform.position;
                var enemyPos = collision.gameObject.transform.position;

                var direction = (enemyPos - currentPos).normalized;

                transform.position = currentPos - direction * 0.4f;
            }
        }
    }
}

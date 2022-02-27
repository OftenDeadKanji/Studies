using UnityEngine;

public class LightSourceManager : MonoBehaviour, Interactive
{
    [SerializeField]
    float maxFuel = 10.0f;
    [SerializeField]
    public float fuelLeft = 10.0f;
    [SerializeField]
    public float fuelConsumptionSpeed = 0.016f; //per second

    [SerializeField]
    Light lightComponent;
    [SerializeField]
    GameObject barrier;

    [SerializeField]
    TextMesh fuelInfo;

    bool isOn = true;

    public void Interact()
    {
        var gameManagerObject = GameObject.Find("GameManager");
        if(gameManagerObject != null)
        {
            GameManager gameManager = gameManagerObject.GetComponent<GameManager>();
            if(gameManager != null)
            {
                if(gameManager.settlementOil >= 5)
                {
                    gameManager.settlementOil -= 5;

                    fuelLeft += 2;
                    if(fuelLeft > maxFuel)
                    {
                        fuelLeft = maxFuel;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFuel();
    }

    void UpdateFuel()
    {
        if (isOn)
        {
            fuelLeft -= Time.deltaTime * fuelConsumptionSpeed;

            if (fuelLeft <= 0)
            {
                fuelLeft = 0.0f;
                isOn = false;

                lightComponent.enabled = false;
                barrier.SetActive(false);
            }
        }
        else
        {
            if (fuelLeft > 0)
            {
                isOn = true;

                lightComponent.enabled = true;
                barrier.SetActive(true);
            }
        }

        fuelInfo.text = ((int)(fuelLeft / maxFuel * 100)).ToString() + '%';
    }
}
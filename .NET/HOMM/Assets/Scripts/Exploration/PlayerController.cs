using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    bool isThisMainPlayer = false;
    public bool IsThisMainPlayer
    {
        get { return isThisMainPlayer; }
    }

    [SerializeField]
    Faction playerFaction;

    [SerializeField]
    Player player;
    public Player Player
    {
        get { return player; }
    }

    int currentlyChosenHeroNumber = 0;
    public int CurrentlyChosenHeroNumber
    {
        get { return currentlyChosenHeroNumber; }
        set { currentlyChosenHeroNumber = value; }
    }

    HeroController currentlyChosenHero;
    public HeroController CurrentlyChosenHero
    {
        get { return currentlyChosenHero; }
    }

    private void Awake()
    {
        player.Faction = playerFaction;

        currentlyChosenHero = null;

        foreach(Transform t in transform)
        {
            if(t.gameObject.tag.Equals("Hero"))
            {
                t.gameObject.SetActive(true);

                var heroController = t.gameObject.GetComponent<HeroController>();
                if(heroController != null)
                {
                    player.Heroes.Add(heroController.Hero);
                    player.Heroes[player.Heroes.Count - 1].Parent = player;
                    heroController.Owner = this;
                }
                else
                {
                    throw new System.Exception("Hero doesn't contain heroController!");
                }
            }
        }

        ChooseNewHero(currentlyChosenHeroNumber);
        
    }

    public void ChooseNewHero(int number = -1)
    {
        if (number < 0)
        {
            number = currentlyChosenHeroNumber;
        }

        var current = player.Heroes[currentlyChosenHeroNumber];
        foreach (Transform t in transform)
        {
            if (t.gameObject.tag.Equals("Hero"))
            {
                var heroController = t.gameObject.GetComponent<HeroController>();
                if (heroController.Hero == current)
                {
                    currentlyChosenHero = heroController;
                }
            }
        }
    }

    public void Die()
    {
        var gameManager = GameObject.Find("GameManager");
        if(gameManager != null)
        {
            var manager = gameManager.GetComponent<GameManager>();
            if(manager != null)
            {
                manager.Players.Remove(gameObject);
            }
        }
        Destroy(gameObject);
    }
}

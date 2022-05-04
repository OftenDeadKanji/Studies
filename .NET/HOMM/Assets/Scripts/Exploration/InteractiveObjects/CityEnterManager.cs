using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityEnterManager : MonoBehaviour, IInteractive
{
	[SerializeField]
	CityManager cityManager;
	public CityManager CityManager
    {
		get { return cityManager; }
		set { cityManager = value; }
    }

	GameManager gameManager;
	GameObject interactArea;

	[SerializeField]
	Texture2D cursorTexture;


    public void Interact(HeroController whoInteracted)
    {
		if(cityManager.City.Owner == null)
        {
			cityManager.City.Owner = whoInteracted.Owner.Player;
			gameManager.EnterCity(cityManager.City, whoInteracted.Hero);
        }
		else if(cityManager.City.Owner == whoInteracted.Owner.Player)
        {
			gameManager.EnterCity(cityManager.City, whoInteracted.Hero);
		}
		else
        {
			if(cityManager.City.Inside.HasAnyUnits())
            {
				if(cityManager.City.HeroInside != null)
                {
					var heroes = GameObject.FindGameObjectsWithTag("Hero");

					foreach(var heroGameObject in heroes)
                    {
						if(heroGameObject.GetComponent<HeroController>().Hero == cityManager.City.HeroInside)
                        {
							HeroController defending = heroGameObject.GetComponent<HeroController>();

							for (int i = 0; i < 10; i++)
							{
								defending.Hero.UnitsGroup.UnitFormations[i] = cityManager.City.Inside.UnitFormations[i];
								cityManager.City.Inside.UnitFormations[i] = new UnitFormation(Unit.CreateUnitNone(), 0);
							}

							gameManager.StartFight(whoInteracted, defending, cityManager);

							return;
						}
                    }
                }
				else
                {
					GameObject emptyHero = new GameObject();
					var defending = emptyHero.AddComponent<HeroController>();
					defending.Predefined = Hero.PredefinedHero.Empty;
					defending.Hero = Hero.CreatePredefinedHero(Hero.PredefinedHero.Empty);

					for (int i = 0; i < 10; i++)
					{
						defending.Hero.UnitsGroup.UnitFormations[i] = cityManager.City.Inside.UnitFormations[i];
						cityManager.City.Inside.UnitFormations[i] = new UnitFormation(Unit.CreateUnitNone(), 0);
					}

					gameManager.StartFight(whoInteracted, defending, cityManager);

					return;
				}
            }
			else
            {
				cityManager.City.Owner = whoInteracted.Owner.Player;
				gameManager.EnterCity(cityManager.City, whoInteracted.Hero);

				return;
			}
        }
	}

    private void Awake()
	{
		var gameManagerObject = GameObject.Find("GameManager");
		if (gameManagerObject == null)
		{
			throw new Exception("Game manger game object not found!");
		}

		gameManager = gameManagerObject.GetComponent<GameManager>();
		if (gameManager == null)
		{
			throw new Exception("GameManger object not found!");
		}

		var interactAreaTransform = gameObject.transform.Find("InteractArea");
		if (interactAreaTransform != null)
		{
			interactArea = interactAreaTransform.gameObject;
		}
		else
		{
			throw new Exception("interactArea object not found!");
		}
	}

	private void OnMouseDown()
	{
		gameManager.SetMainPlayerDirection(interactArea.transform.position, interactArea);
	}

    private void OnMouseEnter()
    {
        if(cursorTexture != null)
        {
			Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        }
    }

    private void OnMouseExit()
    {
		if (cursorTexture != null)
		{
			Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		}
	}
}

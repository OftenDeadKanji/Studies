using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityManager : MonoBehaviour
{
	[SerializeField]
	Faction faction;

	[SerializeField]
	PlayerController owner = null;

	[SerializeField]
	City city;
	public City City
	{
		get { return city; }
		set { city = value; }
	}

	GameManager gameManager;

	[SerializeField]
	GameObject cityRespawnPoint;

	[SerializeField]
	Texture2D cursorTexture;

	[SerializeField]
	GameObject cityInfo;
	[SerializeField]
	GameObject cityInfoDoesntBelong;
	[SerializeField]
	GameObject cityInfoBelongs;
	[SerializeField]
	TextMesh cityInfoGoldPerTurn;

	public GameObject CityRespawnPoint
    {
		get { return cityRespawnPoint; }
    }

	private void Awake()
	{
		if (owner != null)
		{
			city.Owner = owner.Player;
		}

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

		cityInfo.transform.rotation = gameManager.MainCamera.transform.rotation;
	}

	private void OnMouseDown()
	{
		if (city.Owner == gameManager.MainPlayer.Player)
		{
			gameManager.EnterCity(city, null);
		}
	}

	private void OnMouseEnter()
	{
		if (cursorTexture != null)
		{
			Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
		}

		cityInfo.SetActive(true);
		if(city.Owner == gameManager.MainPlayer.Player)
        {
			cityInfoBelongs.SetActive(true);
			cityInfoGoldPerTurn.text = city.Buildings[0].BuildingLevel == CityBuilding.Level.Built ? city.Buildings[0].IncomePerDay.Gold.ToString() : city.Buildings[0].IncomePerDayUpgraded.Gold.ToString();
		}
		else
        {
			cityInfoDoesntBelong.SetActive(true);
        }
	}

	private void OnMouseExit()
	{
		if (cursorTexture != null)
		{
			Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		}
		
		cityInfo.SetActive(false);
		cityInfoBelongs.SetActive(false);
		cityInfoDoesntBelong.SetActive(false);
	}

    private void OnMouseOver()
    {
        //cityInfo.transform.position = gameManager.MainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}

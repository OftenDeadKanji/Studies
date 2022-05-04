using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBuildingManager : MonoBehaviour, IInteractive
{
    PlayerController owner;
    public PlayerController Owner
    {
        get { return owner; }
    }

    [SerializeField]
    Resources productionPerDay;

	GameManager gameManager;
    GameObject interactArea;
	
	[SerializeField]
	Texture2D cursorTexture;

	[SerializeField]
	GameObject buildingInfo;
	[SerializeField]
	GameObject buildingInfoDoesntBelong;
	[SerializeField]
	GameObject buildingInfoBelongs;
	[SerializeField]
	TextMesh buildingInfoResourcePerTurn;

	public void Interact(HeroController whoInteracted)
    {
        owner = whoInteracted.Owner;
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

		buildingInfo.transform.rotation = gameManager.MainCamera.transform.rotation;
	}

	private void OnMouseDown()
	{
		gameManager.SetMainPlayerDirection(interactArea.transform.position, interactArea);
	}

	public void NextDay()
    {
        if(owner != null)
        {
            owner.Player.Resources.AddResources(productionPerDay);
        }
    }

	private void OnMouseEnter()
	{
		if (cursorTexture != null)
		{
			Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
		}

		buildingInfo.SetActive(true);
		if (owner == gameManager.MainPlayer)
		{
			buildingInfoBelongs.SetActive(true);
			buildingInfoResourcePerTurn.text = productionPerDay.Gold > 0 ? productionPerDay.Gold.ToString() : productionPerDay.Wood > 0 ? productionPerDay.Wood.ToString() : productionPerDay.Stone.ToString();
		}
		else
		{
			buildingInfoDoesntBelong.SetActive(true);
		}
	}

	private void OnMouseExit()
	{
		if (cursorTexture != null)
		{
			Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		}

		buildingInfo.SetActive(false);
		buildingInfoBelongs.SetActive(false);
		buildingInfoDoesntBelong.SetActive(false);
	}
}

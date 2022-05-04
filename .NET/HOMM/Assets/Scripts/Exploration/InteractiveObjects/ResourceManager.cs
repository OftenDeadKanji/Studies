using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour, IInteractive
{
    [SerializeField]
    Resources.Type type;
    [SerializeField]
    int amount;

    GameManager gameManager;
    GameObject interactArea;

    public void Interact(HeroController whoInteracted)
    {
		Debug.Log("Resource interaction");
        whoInteracted.Owner.Player.Resources.AddResources(type, amount);
        Destroy(gameObject);
    }

	[SerializeField]
	Texture2D cursorTexture;

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

		var interactAreaTransform = transform.Find("InteractArea");
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
		if (cursorTexture != null)
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

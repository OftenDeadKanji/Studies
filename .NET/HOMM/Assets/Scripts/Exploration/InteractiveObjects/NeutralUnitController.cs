using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NeutralUnitController : MonoBehaviour, IInteractive
{
	GameManager gameManager;
	GameObject interactArea;

    public void Interact(HeroController whoInteracted)
    {
		//gameManager.StartFight(this);
		//Debug.Log("Neutral unit interaction!");
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
}

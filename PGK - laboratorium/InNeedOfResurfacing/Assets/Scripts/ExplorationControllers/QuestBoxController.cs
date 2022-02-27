using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestBoxController : MonoBehaviour
{
    public GameObject questUI;
    public Text textButton;
    private bool _menuState = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerManager playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        print(playerManager.defeated == null);
        if (playerManager.isQuestToKillEnemiesActive)
        {
            if (playerManager.defeated.Count >= 2)
            {
                textButton.text = "Quest done!";
            }
            else
            {
                textButton.text = String.Format("Progress {0}/2", arg0: playerManager.defeated.Count);
            }
        }

        _menuState = !_menuState;
        questUI.SetActive(_menuState);

    }

    void OnTriggerExit2D(Collider2D other)
    {
        _menuState = !_menuState;
        questUI.SetActive(_menuState);
    }
}

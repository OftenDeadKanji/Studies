using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //public List<BodyPart> bodyParts = new List<BodyPart>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restart()
    {
        PlayerManager playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        playerManager.encountered.Clear();
        playerManager.encounteredStr.Clear();
        playerManager.defeated.Clear();
        playerManager.pickableAlreadyPicked.Clear();
        playerManager.invincibleFlee = 0;
        playerManager.isQuestToKillEnemiesActive = false;
        playerManager.bodyParts.Clear();
        foreach (BodyPart bodyPart in playerManager.bodyPartsPrefabs)
            playerManager.bodyParts.Add(new BodyPart(bodyPart));
        playerManager.recover(666);

        playerManager.tempPos = Vector3.zero;

        CrossSceneInformation.currentLightSource = null;
        CrossSceneInformation.resourcesPicked = 0;
        CrossSceneInformation.suppliesPicked = 0;

        SceneManager.LoadScene(0);
    }
}

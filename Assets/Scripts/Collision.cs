using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    PlayerManager playerManager;
    Animator animator;
    BestScore bestscore;
    DisplayCanvas displayCanvas;


    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        animator = GetComponent<Animator>();
        bestscore = GetComponent<BestScore>();
        displayCanvas = GetComponent<DisplayCanvas>();
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Coins"))
        {
            Debug.Log("Coins collected");
            if (playerManager.powerUpCoinsActive)
                playerManager.coins = playerManager.coins + 3;
            else
                playerManager.coins += 1;
            PlayerManager.coinsTo += 1;
            PlayerManager.coinsTo2 += 1;
            PlayerManager.totalCoins += 1;
            col.gameObject.SetActive(false);
        }

        if ((col.gameObject.CompareTag("Obstacle") || col.gameObject.CompareTag("Obstacle2") ||
            col.gameObject.CompareTag("ObstacleBig") || col.gameObject.CompareTag("ObstacleBig2")) 
            && !playerManager.powerUpUnDeadActive)
        {
            bestscore.UpdateList();
            if (playerManager.distance >= 100)
                PlayerManager.mission1 = true;
            if (playerManager.distance >= 1000)
                PlayerManager.mission2 = true;
            if (playerManager.coins >= 100)
                PlayerManager.mission3 = true;
            if (playerManager.coins >= 500)
                PlayerManager.mission4 = true;
            if (PlayerManager.totalCoins >= 1000)
                PlayerManager.mission5 = true;
            if (Statistics.numberOfGames >= 10)
                PlayerManager.mission6 = true;
            Debug.Log("Collision with obstacle !");
            playerManager.playerAlive = false;
            Statistics.numberOfGames++;
            Statistics.update = true;
            animator.Play("Lose");
            StartCoroutine(WaitAfterDead());
        }
    }


    IEnumerator WaitAfterDead()
    {
        yield return new WaitForSeconds(6);
        displayCanvas.DeadInformation();
    }
}

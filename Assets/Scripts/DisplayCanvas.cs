using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class DisplayCanvas : MonoBehaviour
{
    public TextMeshProUGUI CanvasCoins;
    public TextMeshProUGUI CanvasDistance;
    public TextMeshProUGUI CanvasPowerUpCoins;
    public TextMeshProUGUI CanvasPowerUpDistance;
    public TextMeshProUGUI CanvasPowerUpUnDead;
    PlayerManager playerManager;
    Animator anim;

    // dead info
    static Image[] allImages;
    static TextMeshProUGUI[] allText;
    public TextMeshProUGUI CanvasCoinsDead;
    public TextMeshProUGUI CanvasDistanceDead;
    bool update = false;

    public TextMeshProUGUI CanvasUnlockLevel;

    public TextMeshProUGUI CanvasStart;

    MusicManager musicManager;


    bool level1 = false;
    bool level2 = false;
    bool level3 = false;
    bool level4 = false;
    bool level5 = false;
    bool level6 = false;
    bool level7 = false;
    bool level8 = false;
    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        musicManager = GetComponent<MusicManager>();
        anim = GetComponent<Animator>();

        allImages = FindObjectsOfType<Image>();
        allText = FindObjectsOfType<TextMeshProUGUI>();
        foreach (Image image in allImages)
        {
            if (image.CompareTag("InfoDead"))
            {
                image.enabled = false;
            }
        }

        foreach (TextMeshProUGUI text in allText)
        {
            if (text.CompareTag("InfoDead"))
            {
                text.enabled = false;
            }
        }

        UnlockLevelHide();
        StartGameInfo();
    }


    void Update()
    {
        DisplayInfo();
        DisplayUnlockLevel();

        if (!playerManager.playerAlive && !update)
        {
            PlayerManager.distanceTo = PlayerManager.distanceTo + playerManager.distance;
            update = true;
        }
    }

    IEnumerator DisplayUnlockLevelTime()
    {
        yield return new WaitForSeconds(3);
        UnlockLevelHide();
    }
    void DisplayUnlockLevel()
    {
        if (musicManager.level1 && !level1)
        {
          //  CanvasUnlockLevel.text = "Odblokowano level 1.";
         //   level1 = true;
           // unlockLevel.SetActive(true);
          //  StartCoroutine(DisplayUnlockLevelTime());
        }

        if (musicManager.level2 && !level2)
        {
            if (PlayerManager.language == "pl")
                CanvasUnlockLevel.text = "Odblokowano level 2.";
            else
                CanvasUnlockLevel.text = "Unlock level 2.";
            level2 = true;
            UnlockLevelShow();
            StartCoroutine(DisplayUnlockLevelTime());
        }

        if (musicManager.level3 && !level3)
        {
            if (PlayerManager.language == "pl")
                CanvasUnlockLevel.text = "Odblokowano level 3.";
            else
                CanvasUnlockLevel.text = "Unlock level 3.";
            level3 = true;
            UnlockLevelShow();
            StartCoroutine(DisplayUnlockLevelTime());
        }

        if (musicManager.level4 && !level4)
        {
            if (PlayerManager.language == "pl")
                CanvasUnlockLevel.text = "Odblokowano level 4.";
            else
                CanvasUnlockLevel.text = "Unlock level 4.";
            level4 = true;
            UnlockLevelShow();
            StartCoroutine(DisplayUnlockLevelTime());
        }

        if (musicManager.level5 && !level5)
        {
            if (PlayerManager.language == "pl")
                CanvasUnlockLevel.text = "Odblokowano level 5.";
            else
                CanvasUnlockLevel.text = "Unlock level 5.";
            level5 = true;
            UnlockLevelShow();
            StartCoroutine(DisplayUnlockLevelTime());
        }

        if (musicManager.level6 && !level6)
        {
            if (PlayerManager.language == "pl")
                CanvasUnlockLevel.text = "Odblokowano level 6.";
            else
                CanvasUnlockLevel.text = "Unlock level 6.";
            level6 = true;
            UnlockLevelShow();
            StartCoroutine(DisplayUnlockLevelTime());
        }

        if (musicManager.level7 && !level7)
        {
            if (PlayerManager.language == "pl")
                CanvasUnlockLevel.text = "Odblokowano level 7.";
            else
                CanvasUnlockLevel.text = "Unlock level 7.";
            level7 = true;
            UnlockLevelShow();
            StartCoroutine(DisplayUnlockLevelTime());
        }

        if (musicManager.level8 && !level8)
        {
            if (PlayerManager.language == "pl")
                CanvasUnlockLevel.text = "Odblokowano level 8.";
            else
                CanvasUnlockLevel.text = "Unlock level 8.";
            level8 = true;
            UnlockLevelShow();
            StartCoroutine(DisplayUnlockLevelTime());
        }
    }

    void DisplayInfo()
    {
        if (PlayerManager.language == "pl")
            CanvasCoins.text = "Monety: " + playerManager.coins;
        else
            CanvasCoins.text = "Coins: " + playerManager.coins;
        if (playerManager.playerAlive)
        {
            if (playerManager.powerUpDistanceActive)
                playerManager.distance += playerManager.movementSpeed * 0.015f;
            else
                playerManager.distance += playerManager.movementSpeed * 0.003f;
            int score = (int)playerManager.distance;
            if (PlayerManager.language == "pl")
                CanvasDistance.text = "Dystans: " + score;
            else
                CanvasDistance.text = "Distance: " + score;
        }

        if (playerManager.powerUpCoinsActive)
            if (PlayerManager.language == "pl")
                CanvasPowerUpCoins.text = "Power Up Monety : " + PlayerManager.powerUpCoins + "\n" + "Pozostaly czas: " + (int)playerManager.timePowerUpCoins ;
            else
                CanvasPowerUpCoins.text = "Power Up Coins : " + PlayerManager.powerUpCoins + "\n" + "Remaining time: " + (int)playerManager.timePowerUpCoins;
        else
            if (PlayerManager.language == "pl")
                CanvasPowerUpCoins.text = "Power Up Monety : " + PlayerManager.powerUpCoins;
            else
                CanvasPowerUpCoins.text = "Power Up Coins : " + PlayerManager.powerUpCoins;

        if (playerManager.powerUpDistanceActive)
            if (PlayerManager.language == "pl")
                CanvasPowerUpDistance.text = "Power Up Dystans : " + PlayerManager.powerUpDistance + "\n" + "Pozostaly czas: " + (int)playerManager.timePowerUpDistance;
            else
                CanvasPowerUpDistance.text = "Power Up Distance : " + PlayerManager.powerUpDistance + "\n" + "Remaining time: " + (int)playerManager.timePowerUpDistance;
        else
            if (PlayerManager.language == "pl")
                CanvasPowerUpDistance.text = "Power Up Dystans : " + PlayerManager.powerUpDistance;
            else
                CanvasPowerUpDistance.text = "Power Up Distance : " + PlayerManager.powerUpDistance;

        if (playerManager.powerUpUnDeadActive)
            if (PlayerManager.language == "pl")
                CanvasPowerUpUnDead.text = "Power Up Zycie : " + PlayerManager.powerUpUnDead + "\n" + "Pozostaly czas: " + (int)playerManager.timePowerUpUnDead;
            else
                CanvasPowerUpUnDead.text = "Power Up Un-Dead : " + PlayerManager.powerUpUnDead + "\n" + "Remaining time: " + (int)playerManager.timePowerUpUnDead;
        else
            if (PlayerManager.language == "pl")
                CanvasPowerUpUnDead.text = "Power Up Zycie : " + PlayerManager.powerUpUnDead;
            else
                CanvasPowerUpUnDead.text = "Power Up Un-Dead : " + PlayerManager.powerUpUnDead;
    }

    IEnumerator DisplayStartGameInfo()
    {
        yield return new WaitForSeconds(1);
        CanvasStart.text = "3";
        yield return new WaitForSeconds(1);
        CanvasStart.text = "2";
        yield return new WaitForSeconds(1);
        CanvasStart.text = "1";
        yield return new WaitForSeconds(1);
        CanvasStart.text = "Start !";
        yield return new WaitForSeconds(0.6f);
        CanvasStart.gameObject.SetActive(false);

        playerManager.start = true;
    }

    void StartGameInfo()
    {
        StartCoroutine(DisplayStartGameInfo());
    }

    void UnlockLevelHide()
    {
        foreach (Image image in allImages)
        {
            if (image.CompareTag("UnlockLevel"))
            {
                image.enabled = false;
            }
        }

        foreach (TextMeshProUGUI text in allText)
        {
            if (text.CompareTag("UnlockLevel"))
            {
                text.enabled = false;
            }
        }
    }

    void UnlockLevelShow()
    {
        foreach (Image image in allImages)
        {
            if (image.CompareTag("UnlockLevel"))
            {
                image.enabled = true;
            }
        }

        foreach (TextMeshProUGUI text in allText)
        {
            if (text.CompareTag("UnlockLevel"))
            {
                text.enabled = true;
            }
        }
    }

    public void DeadInformation()
    {
        foreach (Image image in allImages)
        {
            if (image.CompareTag("InfoDead"))
            {
                image.enabled = true;
            }
        }

        foreach (TextMeshProUGUI text in allText)
        {
            if (text.CompareTag("InfoDead"))
            {
                text.enabled = true;
            }
        }

        foreach (Image image in allImages)
        {
            if (image.CompareTag("HideInfoDead"))
            {
                image.enabled = false;
            }
        }

        foreach (TextMeshProUGUI text in allText)
        {
            if (text.CompareTag("HideInfoDead"))
            {
                text.enabled = false;
            }
        }

        if (PlayerManager.language == "pl")
        {
            CanvasCoinsDead.text = "Monety : " + playerManager.coins;
            CanvasDistanceDead.text = "Dystans : " + (int)playerManager.distance;
        }
        else
        {
            CanvasCoinsDead.text = "Coins : " + playerManager.coins;
            CanvasDistanceDead.text = "Distance : " + (int)playerManager.distance;
        }


    }
}

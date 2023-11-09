using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

[System.Serializable]
public class PlayerData
{
    public int coins;
    public int[] bestScores;

    // begin statistics
    public int averageDistance;
    public int numberOfGames;
    public int averageCoins;
    public int bestCountMoney;
    public int totalCoins;
    public int averageTime;
    public int totalTime;
    public int averageObstacle;
    public int totalObstacle;
    // end statistics

    // begin powerup
    public int powerUpCoins;
    public int powerUpDistance;
    public int powerUpUnDead;
    // end powerup

    // begin mission
    public bool mission1;
    public bool mission2;
    public bool mission3;
    public bool mission4;
    public bool mission5;
    public bool mission6;
    // end mission

    public string lastReward;

    public string language;

}
public class SaveAndLoadJson : MonoBehaviour
{
    public PlayerData playerData;
    PlayerManager playerManager;

    public TextMeshProUGUI readInfo;
    TextMeshProUGUI[] allTexts;
    Image[] allImages;
    void Start()
    {
        allTexts = FindObjectsOfType<TextMeshProUGUI>();
        allImages = FindObjectsOfType<Image>();

        foreach (Image image in allImages)
        {
            if (image.CompareTag("Read"))
            {
                image.enabled = false;
            }
        }

        foreach (TextMeshProUGUI text in allTexts)
        {
            if (text.CompareTag("Read"))
            {
                text.enabled = false;
            }
        }

        playerManager = GetComponent<PlayerManager>();
    }

    public void Save()
    {
        Statistics.Statistic();

        playerData.coins = PlayerManager.totalCoins;
        playerData.bestScores = BestScore.bestScores.ToArray();

        playerData.averageDistance = Statistics.averageDistance;
        playerData.numberOfGames = Statistics.numberOfGames;
        playerData.averageCoins = Statistics.averageCoins;
        playerData.bestCountMoney = Statistics.bestCountMoney;
        playerData.totalCoins = Statistics.totalCoins;
        playerData.averageTime = Statistics.averageTime;
        playerData.totalTime = Statistics.totalTime;
        playerData.averageObstacle = Statistics.averageObstacle;
        playerData.totalObstacle = Statistics.totalObstacle;

        playerData.powerUpCoins = PlayerManager.powerUpCoins;
        playerData.powerUpDistance = PlayerManager.powerUpDistance;
        playerData.powerUpUnDead = PlayerManager.powerUpUnDead;
        playerData.mission1 = PlayerManager.mission1;
        playerData.mission2 = PlayerManager.mission2;
        playerData.mission3 = PlayerManager.mission3;
        playerData.mission4 = PlayerManager.mission4;
        playerData.mission5 = PlayerManager.mission5;
        playerData.mission6 = PlayerManager.mission6;

        playerData.lastReward = Convert.ToString(PlayerManager.lastReward);

        playerData.language = PlayerManager.language;

        string json = JsonUtility.ToJson(playerData);
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string path = Path.Combine(desktopPath, "saveData.json");
        File.WriteAllText(path, json);
        Debug.Log("Zapisano do pliku");
        Application.Quit();
    }

    public void Load()
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string path = Path.Combine(desktopPath, "saveData.json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            playerData = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("Pomyœlnie wczytano.");
        }
        else
        {
            playerData.coins = 0;
            playerData.bestScores = new int[10];

            playerData.averageDistance = 0;
            playerData.numberOfGames = 0;
            playerData.averageCoins = 0;
            playerData.bestCountMoney = 0;
            playerData.totalCoins = 0;
            playerData.averageTime = 0;
            playerData.totalTime = 0;
            playerData.averageObstacle = 0;
            playerData.totalObstacle = 0;

            playerData.powerUpCoins = 0;
            playerData.powerUpDistance = 0;
            playerData.powerUpUnDead = 0;

            playerData.mission1 = false;
            playerData.mission2 = false;
            playerData.mission3 = false;
            playerData.mission4 = false;
            playerData.mission5 = false;
            playerData.mission6 = false;
            playerData.lastReward = Convert.ToString(DateTime.MinValue);
            playerData.language = "pl";
            Debug.Log("Brak pliku, utworzono zmienne.");
        }

        PlayerManager.totalCoins = playerData.coins;
        BestScore.bestScores = new List<int>(playerData.bestScores);

        Statistics.averageDistance = playerData.averageDistance;
        Statistics.numberOfGames = playerData.numberOfGames;
        Statistics.averageCoins = playerData.averageCoins;
        Statistics.bestCountMoney = playerData.bestCountMoney;
        Statistics.totalCoins = playerData.totalCoins;
        Statistics.averageTime = playerData.averageTime;
        Statistics.totalTime = playerData.totalTime;
        Statistics.averageObstacle = playerData.averageObstacle;
        Statistics.totalObstacle = playerData.totalObstacle;

        PlayerManager.powerUpCoins = playerData.powerUpCoins;
        PlayerManager.powerUpDistance = playerData.powerUpDistance;
        PlayerManager.powerUpUnDead = playerData.powerUpUnDead;

        PlayerManager.mission1 = playerData.mission1;
        PlayerManager.mission2 = playerData.mission2;
        PlayerManager.mission3 = playerData.mission3;
        PlayerManager.mission4 = playerData.mission4;
        PlayerManager.mission5 = playerData.mission5;
        PlayerManager.mission6 = playerData.mission6;
        PlayerManager.lastReward = Convert.ToDateTime(playerData.lastReward);
        PlayerManager.language = playerData.language;

        ConfirmRead();
    }

    public void ConfirmRead()
    {
        foreach (Image image in allImages)
        {
            if (image.CompareTag("Read"))
            {
                image.enabled = false;
            }
        }

        foreach (TextMeshProUGUI text in allTexts)
        {
            if (text.CompareTag("Read"))
            {
                text.enabled = false;
            }
        }
    }
}

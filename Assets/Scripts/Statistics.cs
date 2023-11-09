using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{
    public TextMeshProUGUI statistic1;
    public TextMeshProUGUI statistic2;
    public TextMeshProUGUI statistic3;
    public TextMeshProUGUI statistic4;
    public TextMeshProUGUI statistic5;
    public TextMeshProUGUI statistic6;
    public TextMeshProUGUI statistic7;
    public TextMeshProUGUI statistic8;
    public TextMeshProUGUI statistic9;

    public static int averageDistance = 0;
    public static int numberOfGames = 0;
    public static int averageCoins = 0;
    public static int bestCountMoney = 0;
    public static int totalCoins = 0;
    public static int averageTime = 0;
    public static int totalTime = 0;
    public static int averageObstacle = 0;
    public static int totalObstacle = 0;

    public static bool update = false;
    Image[] allImages;
    TextMeshProUGUI[] allTexts;
    void Start()
    {
        allImages = FindObjectsOfType<Image>();
        allTexts = FindObjectsOfType<TextMeshProUGUI>();
        foreach (Image image in allImages)
        {
            if (image.CompareTag("NextButton"))
            {
                image.enabled = false;
            }
        }

        foreach (TextMeshProUGUI text in allTexts)
        {
            if (text.CompareTag("NextButton"))
            {
                text.enabled = false;
            }
        }
        NumberOneStatistics();
    }

    public static void Statistic()
    {
        if (update)
        {
            averageDistance = (averageDistance * (numberOfGames - 1) + (int)PlayerManager.distanceTo) / numberOfGames;
            PlayerManager.distanceTo = 0;
            averageCoins = (averageCoins * (numberOfGames - 1) + PlayerManager.coinsTo) / numberOfGames;
            totalCoins = PlayerManager.coinsTo2;
            int copyBestCountMoney;
            copyBestCountMoney = PlayerManager.coinsTo;
            if (copyBestCountMoney > bestCountMoney)
                bestCountMoney = copyBestCountMoney;
            PlayerManager.coinsTo = 0;
            averageTime = (averageTime * (numberOfGames - 1) + PlayerManager.timeTo) / numberOfGames;
            totalTime = totalTime + PlayerManager.timeTo;
            PlayerManager.timeTo = 0;
            averageObstacle = (averageObstacle * (numberOfGames - 1) + PlayerManager.obstacleTo) / numberOfGames;
            totalObstacle = totalObstacle + PlayerManager.obstacleTo;
            PlayerManager.obstacleTo = 0;
            update = false;
        }
    }

    public void NumberTwoStatistics()
    {
        foreach (Image image in allImages)
        {
            if (image.CompareTag("PreviousButton"))
            {
                image.enabled = false; 
            }
        }

        foreach (TextMeshProUGUI text in allTexts)
        {
            if (text.CompareTag("PreviousButton"))
            {
                text.enabled = false;
            }
        }

        foreach (Image image in allImages)
        {
            if (image.CompareTag("NextButton"))
            {
                image.enabled = true;
            }
        }

        foreach (TextMeshProUGUI text in allTexts)
        {
            if (text.CompareTag("NextButton"))
            {
                text.enabled = true;
            }
        }

        if (PlayerManager.language == "pl")
        {
            statistic6.text = "Srednia ilosc minietych przeszkod na runde: " + averageObstacle;
            statistic7.text = "Wszystkie miniete przeszkody: " + totalObstacle;
            statistic8.text = "Sredni czas grania rundy: " + averageTime + " sekund";
            statistic9.text = "Laczny czas przegrany w grze: " + totalTime + " sekund";
        }
        else
        {
            statistic6.text = "Average number of obstacles passed per round: " + averageObstacle;
            statistic7.text = "All obstacles passed: " + totalObstacle;
            statistic8.text = "Average playing time of a round: " + averageTime + " seconds";
            statistic9.text = "Total time lost in the game: " + totalTime + " seconds";
        }
    }

    public void NumberOneStatistics()
    {
        Statistic();

        foreach (Image image in allImages)
        {
            if (image.CompareTag("NextButton"))
            {
                image.enabled = false;
            }
        }

        foreach (TextMeshProUGUI text in allTexts)
        {
            if (text.CompareTag("NextButton"))
            {
                text.enabled = false;
            }
        }

        foreach (Image image in allImages)
        {
            if (image.CompareTag("PreviousButton"))
            {
                image.enabled = true;
            }
        }

        foreach (TextMeshProUGUI text in allTexts)
        {
            if (text.CompareTag("PreviousButton"))
            {
                text.enabled = true;
            }
        }

        if (PlayerManager.language == "pl")
        {
            statistic1.text = "Sredni przebyty dystans podczas rundy: " + averageDistance;
            statistic2.text = "Ilosc rozegranych rund: " + numberOfGames;
            statistic3.text = "Srednia ilosc zebranych monet na runde: " + averageCoins;
            statistic4.text = "Najwieksza ilosc zebranych monet: " + bestCountMoney;
            statistic5.text = "Calkowita liczba zebranych monet: " + totalCoins;
        }
        else
        {
            statistic1.text = "Average distance traveled during the round: " + averageDistance;
            statistic2.text = "Number of rounds played: " + numberOfGames;
            statistic3.text = "Average amount of coins collected per round: " + averageCoins;
            statistic4.text = "The highest amount of coins collected: " + bestCountMoney;
            statistic5.text = "Total number of coins collected: " + totalCoins;
        }
    }
}

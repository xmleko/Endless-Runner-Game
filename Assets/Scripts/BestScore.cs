using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BestScore : MonoBehaviour
{
    PlayerManager playerManager;
    public static List<int> bestScores = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    int newScore;
    public TextMeshProUGUI bestScore1;
    public TextMeshProUGUI bestScore2;
    public TextMeshProUGUI bestScore3;
    public TextMeshProUGUI bestScore4;
    public TextMeshProUGUI bestScore5;
    public TextMeshProUGUI bestScore6;
    public TextMeshProUGUI bestScore7;
    public TextMeshProUGUI bestScore8;
    public TextMeshProUGUI bestScore9;
    public TextMeshProUGUI bestScore10;


    int activeSceneIndex;

    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (activeSceneIndex == 2) 
            DisplayList();
    }

    public void UpdateList()
    {

        newScore = (int)playerManager.distance;

        if (newScore > bestScores[9])
        {
            bestScores.Add(newScore);
            bestScores.Reverse();
            SortList(bestScores);
            if (bestScores.Count >= 10)
                bestScores.RemoveAt(10);
        }
    }

    // b¹belkowe sortowanie
    public void SortList(List<int> list)
    {
        int n = list.Count;
        bool swapped;

        do
        {
            swapped = false;

            for (int i = 1; i < n; i++)
            {
                if (list[i - 1] < list[i])
                {
                    int temp = list[i - 1];
                    list[i - 1] = list[i];
                    list[i] = temp;

                    swapped = true;
                }
            }

            n--;
        }
        while (swapped);
    }


    public void DisplayList()
    {
        if (PlayerManager.language == "pl")
        {
            bestScore1.text = "Dystans: " + bestScores[0];
            bestScore2.text = "Dystans: " + bestScores[1];
            bestScore3.text = "Dystans: " + bestScores[2];
            bestScore4.text = "Dystans: " + bestScores[3];
            bestScore5.text = "Dystans: " + bestScores[4];
            bestScore6.text = "Dystans: " + bestScores[5];
            bestScore7.text = "Dystans: " + bestScores[6];
            bestScore8.text = "Dystans: " + bestScores[7];
            bestScore9.text = "Dystans: " + bestScores[8];
            bestScore10.text = "Dystans: " + bestScores[9];
        }
        else
        {
            bestScore1.text = "Distance: " + bestScores[0];
            bestScore2.text = "Distance: " + bestScores[1];
            bestScore3.text = "Distance: " + bestScores[2];
            bestScore4.text = "Distance: " + bestScores[3];
            bestScore5.text = "Distance: " + bestScores[4];
            bestScore6.text = "Distance: " + bestScores[5];
            bestScore7.text = "Distance: " + bestScores[6];
            bestScore8.text = "Distance: " + bestScores[7];
            bestScore9.text = "Distance: " + bestScores[8];
            bestScore10.text = "Distance: " + bestScores[9];
        }
    }
}

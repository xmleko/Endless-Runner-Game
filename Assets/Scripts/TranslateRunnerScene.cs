using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TranslateRunnerScene : MonoBehaviour
{
    public TextMeshProUGUI score;
    void Start()
    {
        Translate();
    }


    void Update()
    {

    }

    void Translate()
    {
        if (PlayerManager.language == "pl")
        {
            score.text = "                   Wynik : ";
        }
        else
        {
            score.text = "                   Score : ";
        }
    }
}

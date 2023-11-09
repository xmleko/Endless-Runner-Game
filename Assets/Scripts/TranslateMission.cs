using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TranslateMission : MonoBehaviour
{
    public TextMeshProUGUI back;

    public TextMeshProUGUI zad1;
    public TextMeshProUGUI zad2;
    public TextMeshProUGUI zad3;
    public TextMeshProUGUI zad4;
    public TextMeshProUGUI zad5;
    public TextMeshProUGUI zad6;

    public TextMeshProUGUI desc1;
    public TextMeshProUGUI desc2;
    public TextMeshProUGUI desc3;
    public TextMeshProUGUI desc4;
    public TextMeshProUGUI desc5;
    public TextMeshProUGUI desc6;


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
            back.text = "Wstecz";
            zad1.text = "Zadanie 1";
            zad2.text = "Zadanie 2";
            zad3.text = "Zadanie 3";
            zad4.text = "Zadanie 4";
            zad5.text = "Zadanie 5";
            zad6.text = "Zadanie 6";
            desc1.text = "Przebiegnij dystans o dlugosci 100";
            desc2.text = "Przebiegnij dystans o dlugosci 1000";
            desc3.text = "Zbierz w jednej rundzie 100 monet";
            desc4.text = "Zbierz w jednej rundzie 500 monet";
            desc5.text = "Zbierz lacznie 1000 monet";
            desc6.text = "Zagraj lacznie 10 gier";
        }
        else
        {
            back.text = "Back";
            zad1.text = "Task 1";
            zad2.text = "Task 2";
            zad3.text = "Task 3";
            zad4.text = "Task 4";
            zad5.text = "Task 5";
            zad6.text = "Task 6";
            desc1.text = "Run a distance of 100 meters";
            desc2.text = "Run a distance of 1000 meters";
            desc3.text = "Collect 100 coins in one round";
            desc4.text = "Collect 500 coins in one round";
            desc5.text = "Collect a total of 1000 coins";
            desc6.text = "Play a total of 10 games";
        }
    }
}

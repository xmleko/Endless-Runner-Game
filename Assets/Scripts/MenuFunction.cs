using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {

    }



    public void LoadSceneMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadScenePlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadSceneBestScore()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadSceneStatistic()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadSceneShop()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadSceneMission()
    {
        SceneManager.LoadScene(5);
    }
}

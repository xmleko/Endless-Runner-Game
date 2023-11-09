using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] music;

    [HideInInspector]
    public AudioSource audioSource;

    PlayerManager playerManager;

    public float timerDuration = 0;
    bool dead = false;

    public bool level1 = false;
    public bool level2 = false;
    public bool level3 = false;
    public bool level4 = false;
    public bool level5 = false;
    public bool level6 = false;
    public bool level7 = false;
    public bool level8 = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        playerManager = GetComponent<PlayerManager>();
    }

    void Update()
    {
        if (!CheckMusicDead() && !dead && playerManager.start)
            PlayMusicRun();
    }

    public void PlayMusicRun()
    {
        timerDuration += Time.deltaTime;
        if (timerDuration > 0 && !level1)
        {
            audioSource.clip = music[0];
            audioSource.loop = true;
            level1 = true;
            playerManager.movementSpeed = 10;
            Debug.Log("Unlock level 0");
            audioSource.Play();
        }
        else if (timerDuration > 20 && !level2)
        {
            audioSource.clip = music[1];
            audioSource.loop = true;
            level2 = true;
            playerManager.movementSpeed = 15;
            Debug.Log("Unlock level 1");
            audioSource.Play();
        }
        else if (timerDuration > 40 && !level3)
        {
            audioSource.clip = music[2];
            audioSource.loop = true;
            level3 = true;
            playerManager.movementSpeed = 20;
            Debug.Log("Unlock level 2");
            audioSource.Play();
        }
        else if (timerDuration > 60 && !level3)
        {
            audioSource.clip = music[3];
            audioSource.loop = true;
            level4 = true;
            playerManager.movementSpeed = 25;
            Debug.Log("Unlock level 3");
            audioSource.Play();
        }
        else if (timerDuration > 80 && !level4)
        {
            audioSource.clip = music[4];
            audioSource.loop = true;
            level4 = true;
            playerManager.movementSpeed = 30;
            Debug.Log("Unlock level 4");
            audioSource.Play();
        }
        else if (timerDuration > 100 && !level5)
        {
            audioSource.clip = music[5];
            audioSource.loop = true;
            level5 = true;
            playerManager.movementSpeed = 35;
            Debug.Log("Unlock level 5");
            audioSource.Play();
        }
        else if (timerDuration > 120 && !level6)
        {
            audioSource.clip = music[6];
            audioSource.loop = true;
            level6 = true;
            playerManager.movementSpeed = 40;
            Debug.Log("Unlock level 6");
            audioSource.Play();
        }
        else if (timerDuration > 140 && !level7)
        {
            audioSource.clip = music[7];
            audioSource.loop = true;
            level7 = true;
            playerManager.movementSpeed = 45;
            Debug.Log("Unlock level 7");
            audioSource.Play();
        }
        else if (timerDuration > 160 && !level8)
        {
            audioSource.clip = music[8];
            audioSource.loop = true;
            level8 = true;
            playerManager.movementSpeed = 50;
            Debug.Log("Unlock level 8");
            audioSource.Play();
        }
    }

    bool CheckMusicDead()
    {
        if (!playerManager.playerAlive && !dead)
        {
            audioSource.Stop();
            PlayMusicDead();
            return true;
        }
        return false;
    }

    void PlayMusicDead()
    {
        PlayerManager.timeTo = (int)timerDuration;
        audioSource.loop = false;
        audioSource.clip = music[2];
        audioSource.Play();
        Debug.Log("Play Music Dead");
        dead = true;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int movementSpeed;
    public float jumpPower;
    public int coins = 0;
    public float distance = 1;
    public static int totalCoins = 0;
    public bool playerAlive = true;
    public bool start = false;



    // power up begin
    [NonSerialized]
    public static int powerUpCoins = 5;
    public bool powerUpCoinsActive = false;
    public float timePowerUpCoins = 5f;

    [NonSerialized]
    public static int powerUpDistance = 5;
    public bool powerUpDistanceActive = false;
    public float timePowerUpDistance = 5f;

    [NonSerialized]
    public static int powerUpUnDead = 5;
    public bool powerUpUnDeadActive = false;
    public float timePowerUpUnDead = 5f;
    // power up end


    //statistics begin
    public static float distanceTo = 0;
    public static int coinsTo = 0;
    public static int coinsTo2 = 0;
    public static int timeTo = 0;
    public static int obstacleTo = 0;
    //statistics end

    //mission begin
    public static bool mission1 = false;
    public static bool mission2 = false;
    public static bool mission3 = false;
    public static bool mission4 = false;
    public static bool mission5 = false;
    public static bool mission6 = false;
    // mission end

    // reward time
    public static DateTime lastReward = DateTime.MinValue;

    public static string language = "pl";

    MusicManager musicManager;
    void Start()
    {
        musicManager = GetComponent<MusicManager>();
    }
    void Update()
    {

    }
}

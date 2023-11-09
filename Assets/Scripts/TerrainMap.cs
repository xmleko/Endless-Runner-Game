using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class TerrainMap : MonoBehaviour
{
    private GameObject player;
    public GameObject[] indexTerrain;
    private GameObject terrain;
    private GameObject terrainTwo;
    private GameObject terrainThree;
    private GameObject coins;
    private GameObject obstacle;
    private GameObject obstacleTwo;
    private GameObject obstacleBig;
    private GameObject obstacleBigTwo;
    private List<GameObject> ListTerrain = new List<GameObject>();
    private HashSet<GameObject> ListCoins = new HashSet<GameObject>();
    private HashSet<GameObject> ListObstacle = new HashSet<GameObject>();

    GameObject obj1;
    GameObject obj2;
    GameObject obj3;
    GameObject obj4;
    GameObject obj5;
    GameObject obj6;
    GameObject obj7;
    GameObject obj8;
    GameObject obj9;
    GameObject obj10; 
    private float positionZ = 36f;

    void Start()
    {
        terrain = GameObject.FindGameObjectWithTag("Ground");
        terrainTwo = GameObject.FindGameObjectWithTag("Ground2");
        terrainThree = GameObject.FindGameObjectWithTag("Ground3");
        obstacle = GameObject.FindGameObjectWithTag("Obstacle");
        obstacleTwo = GameObject.FindGameObjectWithTag("Obstacle2");
        obstacleBig = GameObject.FindGameObjectWithTag("ObstacleBig");
        obstacleBigTwo = GameObject.FindGameObjectWithTag("ObstacleBig2");
        coins = GameObject.FindGameObjectWithTag("Coins");
        player = GameObject.FindGameObjectWithTag("Player");

        for (int i = 0; i < 20; i++)
        {
            GameObject ter = Instantiate(terrain);
            ter.SetActive(false);
            ListTerrain.Add(ter);
        }

        for (int i = 0; i < 20; i++)
        {
            GameObject ter = Instantiate(terrainTwo);
            ter.SetActive(false);
            ListTerrain.Add(ter);
        }

        for (int i = 0; i < 20; i++)
        {
            GameObject ter = Instantiate(terrainThree);
            ter.SetActive(false);
            ListTerrain.Add(ter);
        }

        for (int i = 0; i < 15; i++)
        {
            GameObject obj = Instantiate(obstacle);
            obj.SetActive(false);
            ListObstacle.Add(obj);
        }

        for (int i = 0; i < 15; i++)
        {
            GameObject obj = Instantiate(obstacleTwo);
            obj.SetActive(false);
            ListObstacle.Add(obj);
        }

        for (int i = 0; i < 15; i++)
        {
            GameObject obj = Instantiate(obstacleBig);
            obj.SetActive(false);
            ListObstacle.Add(obj);
        }

        for (int i = 0; i < 15; i++)
        {
            GameObject obj = Instantiate(obstacleBigTwo);
            obj.SetActive(false);
            ListObstacle.Add(obj);
        }

        for (int i = 0; i < 100; i++)
        {
            GameObject coin = Instantiate(coins);
            coin.SetActive(false);
            ListCoins.Add(coin);
        }

        for (int i = 0; i < 10; i++)
        {
            SpawnTerrain();
            Debug.Log("XDDDD");
        }
    }

    void Update()
    {
        if (player.transform.position.z > positionZ - 7 * 36f)
        {
            SpawnTerrain();
            SetActiveTerrain();
            SetActiveObstacle();
            // if (Time.frameCount % 10 == 0) // reduce the frequency of calling DestroyCoins()
            SetActiveCoins();
        }
    }

    /////////////////////////////////////////////////////////////// BEGIN TERRAIN /////////////////////////////////////////////////////////////////////////////////////////
    int RandIndexTerrain(int random)
    {
        random = Random.Range(0, 3);
        return random;
    }

    void SpawnTerrain()
    {
        SpawnCoins();
        SpawnObstacle();
        GameObject obj;
        int number = RandIndexTerrain(0);
        if (number == 0)
            obj = FreeTerrain();
        else if (number == 1)
            obj = FreeTerrainTwo();
        else
            obj = FreeTerrainThree();
        obj.transform.position = new Vector3(0, 0, positionZ);
        positionZ += 36f;
    }

    GameObject FreeTerrain()
    {
        foreach (GameObject terrain in ListTerrain)
        {
            if (!terrain.activeSelf)
            {
                if (terrain.tag == ("Ground"))
                {
                    terrain.SetActive(true);
                    return terrain;
                }
            }
        }
        return null;
    }

    GameObject FreeTerrainTwo()
    {
        foreach (GameObject terrain in ListTerrain)
        {
            if (!terrain.activeSelf)
            {
                if (terrain.tag == ("Ground2"))
                {
                    terrain.SetActive(true);
                    return terrain;
                }
            }
        }
        return null;
    }

    GameObject FreeTerrainThree()
    {
        foreach (GameObject terrain in ListTerrain)
        {
            if (!terrain.activeSelf)
            {
                if (terrain.tag == ("Ground3"))
                {
                    terrain.SetActive(true);
                    return terrain;
                }
            }
        }
        return null;
    }

    void SetActiveTerrain()
    {
        // fix ToList
        foreach (GameObject terrain in ListTerrain.ToList())
        {
            if (terrain == null)
                Debug.Log("Detected null terrain");
            else
            {
                if (terrain.transform.position.z + 50 < player.transform.position.z)
                {
                    terrain.SetActive(false);
                }
            }
        }
    }

    /////////////////////////////////////////////////////////////// END TERRAIN /////////////////////////////////////////////////////////////////////////////////////////

    /////////////////////////////////////////////////////////////// BEGIN OBSTACLE //////////////////////////////////////////////////////////////////////////////////////

    enum obstaclePosition
    {
        obstacleMid = 0,
        obstacleRight = 1,
        obstacleLeft = 2,
        obstacleTwoMid = 3,
        obstacleTwoRight = 4,
        obstacleTwoLeft = 5,
        obstacleRand = 6,
        obstacleRand2 = 7,
        obstacleRand3 = 8,
        obstacleBigMid = 9,
        obstacleBigRight = 10,
        obstacleBigLeft = 11,
        obstacleBigTwoMid = 12,
        obstacleBigTwoRight = 13,
        obstacleBigTwoLeft = 14

    }
    int RandObstacle(int random) // obstacle 
    {
        random = Random.Range(0, 15);
        return random;
    }

    int RandObstacleTwo(int random) // obstacle
    {
        random = Random.Range(0, 4);
        return random;
    }

    int RandObstacleThree(int random) // pos
    {
        random = Random.Range(0, 3);
        return random;
    }

    void SpawnObstacle()
    {
        GameObject obj1 = null;
        int rand_pos = RandObstacle(0);
        int randObstacle;
        int randPosition;
        int copy;

        if (rand_pos == (int)obstaclePosition.obstacleMid)
        {
            obj1 = FreeObstacle();
            obj1.transform.position = new Vector3(0, 0, positionZ + 13);
        }
        else if (rand_pos == (int)obstaclePosition.obstacleRight)
        {
            obj1 = FreeObstacle();
            obj1.transform.position = new Vector3(7, 0, positionZ + 13);
        }
        else if (rand_pos == (int)obstaclePosition.obstacleLeft)
        {
            obj1 = FreeObstacle();
            obj1.transform.position = new Vector3(-7, 0, positionZ + 13);
        }
        if (rand_pos == (int)obstaclePosition.obstacleTwoMid)
        {
            obj1 = FreeObstacleTwo();
            obj1.transform.position = new Vector3(0, 0, positionZ + 13);
        }
        else if (rand_pos == (int)obstaclePosition.obstacleTwoRight)
        {
            obj1 = FreeObstacleTwo();
            obj1.transform.position = new Vector3(7, 0, positionZ + 13);
        }
        else if (rand_pos == (int)obstaclePosition.obstacleTwoLeft)
        {
            obj1 = FreeObstacleTwo();
            obj1.transform.position = new Vector3(-7, 0, positionZ + 13);
        }
        if (rand_pos == (int)obstaclePosition.obstacleBigMid)
        {
            obj1 = FreeObstacleBig();
            obj1.transform.position = new Vector3(0, 0, positionZ + 13);
        }
        else if (rand_pos == (int)obstaclePosition.obstacleBigRight)
        {
            obj1 = FreeObstacleBig();
            obj1.transform.position = new Vector3(7, 0, positionZ + 13);
        }
        else if (rand_pos == (int)obstaclePosition.obstacleBigLeft)
        {
            obj1 = FreeObstacleBig();
            obj1.transform.position = new Vector3(-7, 0, positionZ + 13);
        }
        if (rand_pos == (int)obstaclePosition.obstacleBigTwoMid)
        {
            obj1 = FreeObstacleBigTwo();
            obj1.transform.position = new Vector3(0, 0, positionZ + 13);
        }
        else if (rand_pos == (int)obstaclePosition.obstacleBigTwoRight)
        {
            obj1 = FreeObstacleBigTwo();
            obj1.transform.position = new Vector3(7, 0, positionZ + 13);
        }
        else if (rand_pos == (int)obstaclePosition.obstacleBigTwoLeft)
        {
            obj1 = FreeObstacleBigTwo();
            obj1.transform.position = new Vector3(-7, 0, positionZ + 13);
        }

        ListObstacle.Add(obj1);

        if (rand_pos == (int)obstaclePosition.obstacleRand || rand_pos == (int)obstaclePosition.obstacleRand2 || rand_pos == (int)obstaclePosition.obstacleRand3)
        {
            randObstacle = RandObstacleTwo(0);
            if (randObstacle == 0)
                obj1 = FreeObstacle();
            else if (randObstacle == 1)
                obj1 = FreeObstacleTwo();
            else if (randObstacle == 2)
                obj1 = FreeObstacleBig();
            else if (randObstacle == 3)
                obj1 = FreeObstacleBigTwo();


            randPosition = RandObstacleThree(0);
            if (randPosition == 0)
                obj1.transform.position = new Vector3(0, 0, positionZ + 13);
            else if (randPosition == 1)
                obj1.transform.position = new Vector3(7, 0, positionZ + 13);
            else
                obj1.transform.position = new Vector3(-7, 0, positionZ + 13);

            copy = randPosition;

            randObstacle = RandObstacleTwo(0);
            if (randObstacle == 0)
                obj1 = FreeObstacle();
            else if (randObstacle == 1)
                obj1 = FreeObstacleTwo();
            else if (randObstacle == 2)
                obj1 = FreeObstacleBig();
            else if (randObstacle == 3)
                obj1 = FreeObstacleBigTwo();

            randPosition = RandObstacleThree(0);
            if (copy == randPosition)
            {
                while (randPosition != copy)
                {
                    randPosition = RandObstacleThree(0);
                }
            }
            if (randPosition == 0)
                obj1.transform.position = new Vector3(0, 0, positionZ + 13);
            else if (randPosition == 1)
                obj1.transform.position = new Vector3(7, 0, positionZ + 13);
            else
                obj1.transform.position = new Vector3(-7, 0, positionZ + 13);
        }
    }

    GameObject FreeObstacle()
    {
        foreach (GameObject obstacle in ListObstacle)
        {
            if (!obstacle.activeSelf)
            {
                if (obstacle.tag == ("Obstacle"))
                {
                    obstacle.SetActive(true);
                    return obstacle;
                }
            }
        }
        return null;
    }

    GameObject FreeObstacleTwo()
    {
        foreach (GameObject obstacle in ListObstacle)
        {
            if (!obstacle.activeSelf)
            {
                if (obstacle.tag == ("Obstacle2"))
                {
                    obstacle.SetActive(true);
                    return obstacle;
                }
            }
        }
        return null;
    }

    GameObject FreeObstacleBig()
    {
        foreach (GameObject obstacle in ListObstacle)
        {
            if (!obstacle.activeSelf)
            {
                if (obstacle.tag == ("ObstacleBig"))
                {
                    obstacle.SetActive(true);
                    return obstacle;
                }
            }
        }
        return null;
    }

    GameObject FreeObstacleBigTwo()
    {
        foreach (GameObject obstacle in ListObstacle)
        {
            if (!obstacle.activeSelf)
            {
                if (obstacle.tag == ("ObstacleBig2"))
                {
                    obstacle.SetActive(true);
                    return obstacle;
                }
            }
        }
        return null;
    }
    void SetActiveObstacle()
    {
        // fix ToList
        foreach (GameObject obstacle in ListObstacle.ToList())
        {
            if (obstacle == null)
                Debug.Log("Detected null obstacle");
            else
            {
                if (obstacle.transform.position.z + 50 < player.transform.position.z)
                {
                    obstacle.SetActive(false);
                }
            }
        }
    }




    /////////////////////////////////////////////////////////////// END OBSTACLE /////////////////////////////////////////////////////////////////////////////////////////


    /////////////////////////////////////////////////////////////// BEGIN COINS /////////////////////////////////////////////////////////////////////////////////////////
    enum coinsPosition
    {
        CoinsMid = 0,
        CoinsRight = 1,
        CoinsLeft = 2,
        CoinsMidRight = 3,
        CoinsMidLeft = 4,
        CoinsLeftRight = 5,
        CoinsNone1 = 6,
    }
    int RandCoins(int random)
    {
        random = Random.Range(0, 7);
        return random;
    }

    void SpawnCoins()
    {
        int rand_pos = RandCoins(0);

        obj1 = FreeCoin();
        obj2 = FreeCoin();
        obj3 = FreeCoin();
        obj4 = FreeCoin();
        obj5 = FreeCoin();

        // fix int enum 
        if (rand_pos == (int)coinsPosition.CoinsMid || rand_pos == (int)coinsPosition.CoinsRight || rand_pos == (int)coinsPosition.CoinsLeft)
        {
            if (rand_pos == 0)
            {
                obj1.transform.position = new Vector3(0, 1, positionZ - 6);
                obj2.transform.position = new Vector3(0, 1, positionZ - 4);
                obj3.transform.position = new Vector3(0, 1, positionZ - 2);
                obj4.transform.position = new Vector3(0, 1, positionZ);
                obj5.transform.position = new Vector3(0, 1, positionZ + 2);
            }
            else if (rand_pos == 1)
            {
                obj1.transform.position = new Vector3(7, 1, positionZ - 6);
                obj2.transform.position = new Vector3(7, 1, positionZ - 4);
                obj3.transform.position = new Vector3(7, 1, positionZ - 2);
                obj4.transform.position = new Vector3(7, 1, positionZ);
                obj5.transform.position = new Vector3(7, 1, positionZ + 2);
            }
            else
            {
                obj1.transform.position = new Vector3(-7, 1, positionZ - 6);
                obj2.transform.position = new Vector3(-7, 1, positionZ - 4);
                obj3.transform.position = new Vector3(-7, 1, positionZ - 2);
                obj4.transform.position = new Vector3(-7, 1, positionZ);
                obj5.transform.position = new Vector3(-7, 1, positionZ + 2);
            }
        }
        else if (rand_pos == (int)coinsPosition.CoinsMidRight || rand_pos == (int)coinsPosition.CoinsMidLeft || rand_pos == (int)coinsPosition.CoinsLeftRight)
        {
            obj6 = FreeCoin();
            obj7 = FreeCoin();
            obj8 = FreeCoin();
            obj9 = FreeCoin();
            obj10 = FreeCoin();
            if (rand_pos == 3)
            {
                obj1.transform.position = new Vector3(0, 1, positionZ - 6);
                obj2.transform.position = new Vector3(0, 1, positionZ - 4);
                obj3.transform.position = new Vector3(0, 1, positionZ - 2);
                obj4.transform.position = new Vector3(0, 1, positionZ);
                obj5.transform.position = new Vector3(0, 1, positionZ + 2);
                obj6.transform.position = new Vector3(7, 1, positionZ - 6);
                obj7.transform.position = new Vector3(7, 1, positionZ - 4);
                obj8.transform.position = new Vector3(7, 1, positionZ - 2);
                obj9.transform.position = new Vector3(7, 1, positionZ);
                obj10.transform.position = new Vector3(7, 1, positionZ + 2);
            }
            else if (rand_pos == 4)
            {
                obj1.transform.position = new Vector3(0, 1, positionZ - 6);
                obj2.transform.position = new Vector3(0, 1, positionZ - 4);
                obj3.transform.position = new Vector3(0, 1, positionZ - 2);
                obj4.transform.position = new Vector3(0, 1, positionZ);
                obj5.transform.position = new Vector3(0, 1, positionZ + 2);
                obj6.transform.position = new Vector3(-7, 1, positionZ - 6);
                obj7.transform.position = new Vector3(-7, 1, positionZ - 4);
                obj8.transform.position = new Vector3(-7, 1, positionZ - 2);
                obj9.transform.position = new Vector3(-7, 1, positionZ);
                obj10.transform.position = new Vector3(-7, 1, positionZ + 2);
            }
            else
            {
                obj1.transform.position = new Vector3(-7, 1, positionZ - 6);
                obj2.transform.position = new Vector3(-7, 1, positionZ - 4);
                obj3.transform.position = new Vector3(-7, 1, positionZ - 2);
                obj4.transform.position = new Vector3(-7, 1, positionZ);
                obj5.transform.position = new Vector3(-7, 1, positionZ + 2);
                obj6.transform.position = new Vector3(7, 1, positionZ - 6);
                obj7.transform.position = new Vector3(7, 1, positionZ - 4);
                obj8.transform.position = new Vector3(7, 1, positionZ - 2);
                obj9.transform.position = new Vector3(7, 1, positionZ);
                obj10.transform.position = new Vector3(7, 1, positionZ + 2);
            }
        }
        else
        {
            // CoinsNone1 
            // nothing
        }
    }
    GameObject FreeCoin()
    {

        foreach (GameObject coin in ListCoins)
        {
            if (!coin.activeSelf)
            {
                coin.SetActive(true);
                return coin;
            }
        }
        return null;
    }
    void SetActiveCoins()
    {

        // fix ToList
        foreach (GameObject coin in ListCoins.ToList())
        {
            if (coin == null)
                Debug.Log("Detected null coin");
            else
            {
                if (coin.transform.position.z + 50 < player.transform.position.z)
                {
                    coin.SetActive(false);
                }
            }
        }
    }

    /////////////////////////////////////////////////////////////// END COINS /////////////////////////////////////////////////////////////////////////////////////////
}





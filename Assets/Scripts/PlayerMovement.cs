using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using System;
using UnityEngine.EventSystems;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    PlayerManager playerManager;
    Animator animator;
    CharacterController con;
    private int positionPlayerCurrent = 1;
    private Vector3 moveDirection;
    private float airResistance;


    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        animator = GetComponent<Animator>();
        con = GetComponent<CharacterController>();
        
    }

    void Update()
    {
        if (playerManager.playerAlive == true)
        {
            MoveForward();
            MoveRightAndLeft();
            Roll();
            Jump();
            ApplyAirResistance();
            PowersUp();
        }
    }

    enum posPlayer
    {
        Left = 0,
        Mid = 1,
        Right = 2
    }


    void MoveForward()
    {
        moveDirection.z = playerManager.movementSpeed;
        con.Move(moveDirection * Time.deltaTime);
    }
    
    void MoveRightAndLeft()
    {

        Vector3 newPos = transform.position.z * transform.forward + transform.position.y * transform.up;


        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Left Strafe") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Roll") && Input.GetKeyDown(KeyCode.D) && isGround())
        {
            positionPlayerCurrent++;
            if (positionPlayerCurrent == (int)posPlayer.Right + 1)
                positionPlayerCurrent = (int)posPlayer.Right;
            else
                animator.Play("Right Strafe");
        }


        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Right Strafe") && !animator.GetCurrentAnimatorStateInfo(0).IsName("Roll") && Input.GetKeyDown(KeyCode.A) && isGround())
        {
            positionPlayerCurrent--;
            if (positionPlayerCurrent == (int)posPlayer.Left - 1)
                positionPlayerCurrent = (int)posPlayer.Left;
            else
                animator.Play("Left Strafe");
        }


        if (positionPlayerCurrent == (int)posPlayer.Left)
        {
            newPos += Vector3.left * 7;
        }
        else if (positionPlayerCurrent == (int)posPlayer.Right)
        {
            newPos += Vector3.right * 7;
        }

        transform.position = Vector3.Lerp(transform.position, newPos, 5 * Time.fixedDeltaTime); 
    }

    void Roll()
    {
        Vector3 newCenter = con.center;

        if (Input.GetKeyDown(KeyCode.S) && isGround())
        {
            animator.Play("Roll"); 
            newCenter.y = 0.5f; 
            con.center = newCenter;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Roll") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            newCenter.y = 1f;
            con.center = newCenter;
        }
            
    }

    void Jump()
    {
        if (isGround())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = playerManager.jumpPower;
                con.radius = 0.7f;
                con.height = 0.7f;
                animator.SetFloat("Jump", 0.6f);
                animator.Play("Jump");
            }
        }
        else
        {

            if (playerManager.movementSpeed == 10)
            {
                moveDirection.y -= 20 * Time.deltaTime;
                playerManager.jumpPower = 10;
                airResistance = 1f;
            }

            if (playerManager.movementSpeed == 15)
            {
                moveDirection.y -= 20 * Time.deltaTime;
                playerManager.jumpPower = 10;
                airResistance = 10f;
            }

            if (playerManager.movementSpeed == 20)
            {
                moveDirection.y -= 20 * Time.deltaTime;
                playerManager.jumpPower = 10;
                airResistance = 20f;
            }

            if (playerManager.movementSpeed == 25)
            {
                moveDirection.y -= 20 * Time.deltaTime;
                playerManager.jumpPower = 10;
                airResistance = 27f;
            }

            if (playerManager.movementSpeed == 30)
            {
                moveDirection.y -= 20 * Time.deltaTime;
                playerManager.jumpPower = 10;
                airResistance = 35f;
            }

            if (playerManager.movementSpeed == 35)
            {
                moveDirection.y -= 20 * Time.deltaTime;
                playerManager.jumpPower = 10;
                airResistance = 42f;
            }

            if (playerManager.movementSpeed == 40)
            {
                moveDirection.y -= 20 * Time.deltaTime;
                playerManager.jumpPower = 10;
                airResistance = 50f;
            }

            if (playerManager.movementSpeed == 45)
            {
                moveDirection.y -= 20 * Time.deltaTime;
                playerManager.jumpPower = 10;
                airResistance = 63f;
            }

            if (playerManager.movementSpeed == 50)
            {
                moveDirection.y -= 20 * Time.deltaTime;
                playerManager.jumpPower = 10;
                airResistance = 75f;
            }

            if (transform.position.y <= 0.05)
            {
                // stop on the floor
                moveDirection.y = 0f;
                transform.position = new Vector3(transform.position.x, (float)0.05, transform.position.z);
                con.height = 1.2f;
                con.radius = 1.2f;
            }
        }
    }

    void ApplyAirResistance()
    {
        if (!isGround())
        {
            Vector3 resistanceForce = -moveDirection.normalized * airResistance;
            moveDirection += resistanceForce * Time.deltaTime;
        }
    }


    bool isGround()
    {
        float positionPlayerY = 0.05f;
        if (con.transform.position.y == positionPlayerY)
        {
            Debug.Log("Player is ground");
            return true;
        }
        return false;
    }

    void PowersUp()
    {
        if (Input.GetKeyDown(KeyCode.P) && PlayerManager.powerUpCoins > 0 && !playerManager.powerUpCoinsActive)
        {
            PlayerManager.powerUpCoins--;
            playerManager.powerUpCoinsActive = true;
        }

        if (playerManager.powerUpCoinsActive)
        {
            RefreshTimePowersUpCoins();
        }

        if (Input.GetKeyDown(KeyCode.O) && PlayerManager.powerUpDistance > 0 && !playerManager.powerUpDistanceActive)
        {
            PlayerManager.powerUpDistance--;
            playerManager.powerUpDistanceActive = true;
        }

        if (playerManager.powerUpDistanceActive)
        {
            RefreshTimePowersUpDistance();
        }

        if (Input.GetKeyDown(KeyCode.I) && PlayerManager.powerUpUnDead > 0 && !playerManager.powerUpUnDeadActive)
        {
            PlayerManager.powerUpUnDead--;
            playerManager.powerUpUnDeadActive = true;
        }

        if (playerManager.powerUpUnDeadActive)
        {
            RefreshTimePowersUpUnDead();
        }
    }

    void RefreshTimePowersUpCoins()
    {
        playerManager.timePowerUpCoins -= Time.deltaTime; 

        if (playerManager.timePowerUpCoins <= 0f)
        {
            playerManager.timePowerUpCoins = 5f;
            playerManager.powerUpCoinsActive = false;
            Debug.Log("Power-up coins zakoñczony.");
        }
    }

    void RefreshTimePowersUpDistance()
    {
        playerManager.timePowerUpDistance -= Time.deltaTime;

        if (playerManager.timePowerUpDistance <= 0f)
        {
            playerManager.timePowerUpDistance = 5f;
            playerManager.powerUpDistanceActive = false;
            Debug.Log("Power-up distance zakoñczony.");
        }
    }

    void RefreshTimePowersUpUnDead()
    {
        playerManager.timePowerUpUnDead -= Time.deltaTime;

        if (playerManager.timePowerUpUnDead <= 0f)
        {
            playerManager.timePowerUpUnDead = 5f;
            playerManager.powerUpUnDeadActive = false;
            Debug.Log("Power-up un'dead zakoñczony.");
        }
    }

}





// poruszanie sie postaci
// kamera
// generowanie terenu
// grafiki 
// usuwanie terenu + nieskonczone generowanie
// coinsy
// przeszkody
// animacje
// kolizje
// rol w dol
// jump 
// muzyka 
// main menu
// json 
// bestscore
// statistics
// movement
// powery
// shop
// frontend ogolnie
// rotate coins
// generowanie terenu 2
// frontend end - ostatnie okna
// osiagniecia
// gui ostatnie okna + dzienne nagrody 
// language 
// start 





// teren moze?
// muzyke dodac last

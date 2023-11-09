using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    CharacterController con;
    private Vector3 moveDirection;


    void Start()
    {
        con = GetComponent<CharacterController>();
    }

    void Update()
    {
        MoveTrain();
    }

    void MoveTrain()
    {
        moveDirection.z = -30;
        con.Move(moveDirection * Time.deltaTime);
    }
}

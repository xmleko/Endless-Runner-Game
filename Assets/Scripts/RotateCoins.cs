using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoins : MonoBehaviour
{
    public float rotateSpeed = 100.0f; 

    void Start()
    {
        
    }

    private void OnEnable()
    {
        transform.rotation = Quaternion.Euler(0, -90, 90);
    }

    void Update()
    {
        transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
    }
}

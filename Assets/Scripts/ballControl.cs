using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class ballControl : MonoBehaviour
{
    [SerializeField] private float ballSpeed = 0f;
    Rigidbody ballRb;


    private void Start()
    {
        ballRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        ballMovement();
    }



    void ballMovement()
    {
        float xValue = Input.GetAxis("Horizontal");
        float zValue = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(xValue, 0, zValue);


        if (movement.magnitude > 0)
        {
            ballRb.AddForce(movement * ballSpeed, ForceMode.Force);
        }
        else
        {
            ballRb.velocity = Vector3.zero;
        }

    }
}

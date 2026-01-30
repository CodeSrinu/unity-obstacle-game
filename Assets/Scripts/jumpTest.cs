using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpTest : MonoBehaviour
{
    [SerializeField] float jumpForce = 0f;

    Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //transform.Translate(0, jumpForce, 0);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        }

    
}


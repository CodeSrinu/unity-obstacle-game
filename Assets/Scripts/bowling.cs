using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowling : MonoBehaviour
{
    [SerializeField] private float speed = 0f;
    Rigidbody rb;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
    }



    private void FixedUpdate()
    {
        Push();
    }

    void Push()
    {
        //if (!isBowled)
        //{
            float zValue = Input.GetAxis("Vertical");

            Vector3 movDir = (Vector3.forward * zValue).normalized;

            rb.AddForce(movDir * speed, ForceMode.Force);
        //    isBowled=true;
        //}

    }
}

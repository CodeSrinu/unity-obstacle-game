using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl_BG : MonoBehaviour
{
    [SerializeField] private float moveForce = 0f;
    [SerializeField] private float jumpForce = 0f;
    [SerializeField] private float rotateForce = 0f;
    bool isOnGround = true;


    Rigidbody rb;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip jumpSound;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        if (isOnGround)
        {
            move();
        }
    }

    private void Update()
    {
        jump();
        rotate();
    }



    void move()
    {
        float moveForwardInp = Input.GetAxis("Vertical");
        float moveHorizInp = Input.GetAxis("Horizontal");

        Vector3 movDir = (transform.forward * moveForwardInp + transform.right * moveHorizInp).normalized;


        if (movDir.magnitude > 0)
        {
            //rb.AddForce(movDir * moveForce, ForceMode.Force);
            rb.velocity = movDir * moveForce;
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);

        }


    }


    void rotate()
    {
        float rotateInp = Input.GetAxis("Mouse X");
        float rotateYInp = Input.GetAxis("Mouse Y");
        transform.Rotate(rotateInp * Vector3.up, rotateForce);

    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            audioSource.PlayOneShot(jumpSound, 15f);
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }


    }
}

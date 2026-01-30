using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControlOld : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 0f;
    Rigidbody playerRb;
    [SerializeField] private float jumpForce = 5f;
    bool isOnGround = false;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movePlayer();
        
    }
    private void Update()
    {
        jump();
    }

    void movePlayer()
    {
        float xValue = Input.GetAxis("Horizontal");
        float zValue = Input.GetAxis("Vertical");

        Vector3 movDir = (transform.right * xValue + transform.forward * zValue).normalized;



        if (movDir.magnitude > 0f && isOnGround)
        {
            playerRb.AddForce(movDir * speed, ForceMode.Force);
        }
        else
        {
            playerRb.velocity = new Vector3(0, playerRb.velocity.y, 0);
        }  
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            //Debug.Log("Space Pressed");
            ////playerRb.velocity = new Vector3(playerRb.velocity.x, jumpForce, playerRb.velocity.z);
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isOnGround = true;
        }
    }

}

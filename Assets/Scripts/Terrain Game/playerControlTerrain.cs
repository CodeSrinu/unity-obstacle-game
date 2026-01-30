using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class playerControlTerrain : MonoBehaviour
{

    [SerializeField] private CharacterController playerCC;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] Transform groundCheckSpehre;
    float radius = 0.5f;
    [SerializeField] LayerMask groundLayerMask;


    Vector3 velocity;
    bool isOnGround = true;
    public float gravity = -20;

    private void Update()
    {
        isOnGround = Physics.CheckSphere(groundCheckSpehre.position, radius, groundLayerMask);
        Movement();
        addGravity();
        Jump();
    }

    void Movement()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime;


        Vector3 moveDir = (transform.right * xValue + transform.forward * zValue).normalized;

        if (isOnGround)
        {
            playerCC.Move(moveDir * moveSpeed);
        }
        else
        {
            playerCC.Move(moveDir * (moveSpeed * 0.2f));

        }

    }

    void addGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        playerCC.Move(velocity *  Time.deltaTime);

    }


    void Jump()
    {
        

        if(isOnGround)
        {
            velocity.y = Mathf.Sqrt(-2 * gravity * 3);
        }
    }
}

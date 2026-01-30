using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControlNew : MonoBehaviour
{
    [SerializeField] private float speed = 0f;
    [SerializeField] private CharacterController characterController;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip footStepsSound;
    [SerializeField] AudioClip slideSound;
    [SerializeField] private Animator humanAnimator;


    public float gravity = -9.81f;
    Vector3 velocity;
    public Transform groundCheck;
    float radius = 0.5f;
    [SerializeField] float jumpHeight = 5f;
    public LayerMask groundLayer;
    bool isOnGround;
    [SerializeField] float rotateForce = 5f;
    float stepTimer;
    [SerializeField] float footSoundVol = 10f;
    bool isSliding = false;
    [SerializeField] GameObject cameraObj;
    Vector3 camDefaultLocalPos;
    Vector3 camSlideLocalPos;
    public float camSlideSpeed = 5f;


    float time = 0f;
    public float slideSpeed = 5f;
    float speedParam = 0.0f;

    float charContHeight;
    Vector3 charContCenter;

    private void Start()
    {
        camDefaultLocalPos = cameraObj.transform.localPosition;
        camSlideLocalPos = new Vector3(camDefaultLocalPos.x, 0.5f, -1f);
        charContHeight = characterController.height;
        charContCenter = characterController.center;
    }







    private void Update()
    {
        Move();
        Jump();
        rotate();
        Slide();
        slideCamera();
    }



    void Move()
    {
        isOnGround = Physics.CheckSphere(groundCheck.position, radius, groundLayer);
        

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDir = (transform.right * horizontalInput + transform.forward * verticalInput).normalized;


        if(isOnGround)
        {
            //Old Logic

            //characterController.Move(moveDir * speed * Time.deltaTime);
            //bool isRunning = moveDir.magnitude > 0;
            //humanAnimator.SetBool("isRunning", isRunning);
            //humanAnimator.SetBool("isJumped", false);

            if (moveDir.magnitude > 0.1f)
            {
                speedParam = Mathf.MoveTowards(
                    speedParam,
                    3f,
                    Time.deltaTime * 1.5f);
            }
            else
            {
                speedParam = Mathf.MoveTowards(
                    speedParam,
                    0f,
                    Time.deltaTime * 2.5f);
            }

            characterController.Move(moveDir * speedParam * speed * Time.deltaTime);

            playFootStepSound(moveDir.magnitude);

        }
        else
        {
            
            characterController.Move(moveDir * speedParam * (speed * 0.5f) * Time.deltaTime);
            //humanAnimator.SetBool("isRunning", false);
        }

        humanAnimator.SetFloat("Speed", speedParam);


    }

    void Jump()
    {
        //if (isSliding)
        //    return;


        if (isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(jumpSound, 15f);
            velocity.y = Mathf.Sqrt(-2 * gravity * jumpHeight);
            humanAnimator.SetTrigger("isJumped");
        }
        


        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    void rotate()
    {
        float rotateInp = Input.GetAxis("Mouse X");
        //float rotateYInp = Input.GetAxis("Mouse Y");
        transform.Rotate(rotateInp * Vector3.up, rotateForce);

    }


    void playFootStepSound(float movement)
    {
        
        bool isPlayerMoving = movement > 0.1f;
        float stepDelay = 0.4f;

        if (isPlayerMoving)
        {
            stepTimer += Time.deltaTime;

            if(stepTimer > stepDelay)
            {
                audioSource.PlayOneShot(footStepsSound, footSoundVol);
                stepTimer = 0f;
            }

        }
        else
        {
            stepTimer = 0f;
        }
    }


    void Slide()
    {
        //velocity.y = -2f;
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isSliding && isOnGround)
        {
            isSliding = true;
            humanAnimator.SetTrigger("isSliding");
            audioSource.PlayOneShot(slideSound);
            
        }

        if (isSliding)
        {
            float slidingHeight = charContHeight * 0.7f;
            characterController.height = slidingHeight;
            characterController.center = new Vector3(charContCenter.x, charContCenter.y , charContCenter.z);
            
            
            if (time <= 1.2f)
            {
                time += Time.deltaTime;
                characterController.Move(transform.forward * slideSpeed * Time.deltaTime);
                

            }
            else
            {
                time = 0f;
                isSliding = false;
                
                characterController.height = charContHeight;
                characterController.center = charContCenter;
            }
        }

    }

    void slideCamera()
    {
        Vector3 targetPos = isSliding ? camSlideLocalPos : camDefaultLocalPos;

        cameraObj.transform.localPosition = Vector3.Lerp(cameraObj.transform.localPosition, targetPos, Time.deltaTime * camSlideSpeed);
    }

}

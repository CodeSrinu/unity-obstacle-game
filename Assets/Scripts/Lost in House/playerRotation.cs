using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class playerRotation : MonoBehaviour
{
    [SerializeField] private float mouseSenstivity = 30f;
    [SerializeField] private Transform player;
    float xAxisRotation = 0f;



    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }


    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSenstivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSenstivity;

        xAxisRotation -= mouseY;

        xAxisRotation = Mathf.Clamp(xAxisRotation, -70f, 70f);

        transform.localRotation =  Quaternion.Euler(xAxisRotation, 0, 0);


        player.Rotate(Vector3.up * mouseX *  Time.deltaTime);
    }

}

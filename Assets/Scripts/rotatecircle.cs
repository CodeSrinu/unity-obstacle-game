using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatecircle : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 1000f;
    void Update()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime,0,0);
    }
}

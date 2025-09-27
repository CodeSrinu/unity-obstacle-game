using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstacle : MonoBehaviour
{
    [SerializeField]private float yValue = 1000f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, yValue * Time.deltaTime, 0);
    }
}

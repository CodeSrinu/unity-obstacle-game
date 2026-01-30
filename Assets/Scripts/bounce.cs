using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class bounce : MonoBehaviour
{
     [SerializeField] private float bounceHeight = 0f;

    void Update()
    {
        transform.Translate(0f, bounceHeight * Time.deltaTime, 0f);
    }
}

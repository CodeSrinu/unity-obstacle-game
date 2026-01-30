using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigRamp : MonoBehaviour
{
    [SerializeField] private GameObject rampObj;



    private void OnTriggerEnter(Collider other)
    {
        if (rampObj.tag == "ramp1")
        {
            rampObj.transform.Rotate(0, 0, 25f);
        }
        else
        {
            rampObj.transform.Rotate(0, 0, -22.4f);

        }
    }
}

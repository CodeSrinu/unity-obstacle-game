using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class openDoor : MonoBehaviour
{
    private float doorHingeBoudary = -47;

    [SerializeField] private TextMeshProUGUI scoreTxt;


    private void Update()
    {

        if (scoreTxt.GetParsedText() == "5")
        {
            doorOpen();
        }
    }


    void doorOpen()
    {

        if (transform.rotation.y * 100 > doorHingeBoudary)
        {
            transform.Rotate(Vector3.up, -1);
        }
    }


}

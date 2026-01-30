using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class timer : MonoBehaviour
{
    TextMeshProUGUI timerTxt;
    [SerializeField] collisionHandler collisionHandlerScript;
    private float time = 35f;
    int intTime = 0;
    bool isTimeUp = true;


    private void Start()
    {
        timerTxt = GetComponent<TextMeshProUGUI>();
    }


    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            intTime = (int)time;
            timerTxt.text = "00 : " + intTime ;
        }
        else
        {
            if(isTimeUp) collisionHandlerScript.bombBlast(null);
            isTimeUp = false;
        }
    }

}

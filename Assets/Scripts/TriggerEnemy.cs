using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemy : MonoBehaviour
{

    public Agent agent;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        { 
            agent.enemyTriggered = true;
        }
    }

}

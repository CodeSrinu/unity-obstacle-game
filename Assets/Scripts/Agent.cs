using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Agent : MonoBehaviour
{
    NavMeshAgent agent;
    public float patrolSpeed = 5f;
    public bool enemyTriggered = false;
    public Transform playerTransform;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!enemyTriggered)
        {
            Patrol();
        }
        else if (enemyTriggered)
        {
            agent.SetDestination(playerTransform.position);
        }
    }




    void Patrol()
    {
        if (transform.position.x <= 30)
        {
            patrolSpeed *= -1;
        }
        else if(transform.position.x >= 40)
        {
            patrolSpeed *= -1;
        }


        transform.Translate(patrolSpeed * Time.deltaTime, 0, 0);


    }

}

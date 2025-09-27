using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class changeColor : MonoBehaviour
{
    private MeshRenderer mr;

    private void Start()
    {
        
        mr = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            mr.material.color = Color.cyan; 
        }
    }
}

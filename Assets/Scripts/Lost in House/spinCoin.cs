using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spinCoin : MonoBehaviour
{
    [SerializeField] float spinSpeed = 20f;
    [SerializeField] float x = 0, y = 0, z = 1;

    private void Update()
    {
        spin();
    }

    void spin()
    {
        transform.Rotate(new Vector3(x, y, z) * spinSpeed * Time.deltaTime);
    }

   
 






}

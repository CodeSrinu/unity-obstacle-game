using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    [SerializeField] private Transform BulletSpawnPoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] AudioSource audioSource;
    [SerializeField] private AudioClip bulletClip;
    private GameObject clonedBullet;
    public float bulletSpeed = 10f;

    private void Start()
    {
        

    }



    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            fire();
        }
    }



    void fire()
    {
        //StartCoroutine(MuzzleFlashEffect());

        audioSource.PlayOneShot(bulletClip, 5f);

        clonedBullet = Instantiate(bullet, BulletSpawnPoint.position, BulletSpawnPoint.rotation);


        Rigidbody bulletRb;
        bulletRb = clonedBullet.gameObject.GetComponent<Rigidbody>();
        bulletRb.AddForce(Camera.main.transform.forward * bulletSpeed *  Time.deltaTime);
        Destroy(clonedBullet, 5f);
    }

    //IEnumerator MuzzleFlashEffect()
    //{
        
    //}


}

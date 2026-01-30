using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class collisionHandler : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip bombSound;
    [SerializeField] AudioClip doorOpenSound;
    [SerializeField] AudioClip coinSound;
    [SerializeField] AudioClip mageUpSound;
    [SerializeField] AudioClip levelCompleteSound;


    [SerializeField] MonoBehaviour playerControl;
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] TextMeshProUGUI finalScoreTxt;
    [SerializeField] uiManager uiManagerScript;
    [SerializeField] GameObject mageObj;

    private MeshRenderer mageMR;

    bool isDoorOpened = false;
    bool isMageTriggred = false;
    public int score = 0;

    private void Start()
    {
        audioSource = audioSource.gameObject.GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (isMageTriggred && mageObj.transform.position.y < -8.56f)
        {
            showMage();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        switch (other.gameObject.tag)
        {
            case "Starting Point":
                Debug.Log("task1 is triggered");
                uiManagerScript.displayTask(uiManagerScript.taskOneCard);
                break;
            case "Bomb":
                bombBlast(other.gameObject);
                break;
            case "Coin":
                coinCollected(other.gameObject);
                break;
            case "Diamond":
                diamondCollected(other.gameObject);
                break;
            case "Mage Trigger":
                if(!isMageTriggred)
                {
                    audioSource.PlayOneShot(doorOpenSound, 30f);  
                }
                isMageTriggred = true;
                uiManagerScript.displayTask(uiManagerScript.taskTwoCard);
                break;
            case "Finish":
                goToNextScene();
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Starting Point":
                uiManagerScript.closeTask(uiManagerScript.taskOneCard);
                break;
            case "Mage Trigger":
                uiManagerScript.closeTask(uiManagerScript.taskTwoCard);
                break;
        }

    }


    //private void OnCollisionEnter(Collision collision)
    //{
    //    switch (collision.gameObject.tag)
    //    {
    //        case "Mage":
    //            mageCollide();
    //            break;
    //        default: break;
    //    }
    //}

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.gameObject.tag)
        {
            case "Mage":
                mageCollide(hit.gameObject);
                break;
            default: break;
        }
    }


    void doorOpen()
    {
        if (!isDoorOpened)
        {
            audioSource.enabled = true;
            audioSource.PlayOneShot(doorOpenSound, 30f);
            isDoorOpened = true;
        }
    }


    public void bombBlast(GameObject bombObj)
    {
        audioSource.enabled = true;
        audioSource.PlayOneShot(bombSound, 4f);
        playerControl.enabled = false;

        Destroy(bombObj);

        uiManagerScript.gameOverCard.SetActive(true);


        Invoke("reloadScene", 2.5f);
    }

    void mageCollide(GameObject mageWall)
    {
        mageMR = mageWall.GetComponent<MeshRenderer>();

        audioSource.enabled = true;
        audioSource.PlayOneShot(bombSound, 4f);
        playerControl.enabled = false;
        
        mageMR.material.color = Color.red;

        uiManagerScript.gameOverCard.SetActive(true);

        Invoke("reloadScene", 2.5f);
    }



    void coinCollected(GameObject coinObj)
    {
        score++;
        scoreTxt.text = score.ToString();
        audioSource.enabled = true;
        audioSource.PlayOneShot(coinSound);
        Destroy(coinObj);

        if (score == 5)
        {
            doorOpen();
        }
    }

    void diamondCollected(GameObject diamondObj)
    {
        score += 5;
        scoreTxt.text = score.ToString();
        finalScoreTxt.text = score.ToString();
        audioSource.enabled = true;
        audioSource.PlayOneShot(levelCompleteSound);
        Destroy(diamondObj);
        uiManagerScript.levelCompletedCard.SetActive(true);
        Invoke("goToNextScene", 5f);


    }


    void showMage()
    {
        Debug.Log("Mage is triggered");
        mageObj.transform.Translate(0, 1f * Time.deltaTime, 0);
    }




    void reloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void goToNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        SceneManager.LoadScene(nextSceneIndex);
    }
}

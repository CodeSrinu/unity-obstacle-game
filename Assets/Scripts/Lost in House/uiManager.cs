
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class uiManager : MonoBehaviour
{
    [SerializeField] private Button settingsBtn;
    [SerializeField] private GameObject SettingsMenuCard;
    [SerializeField] public GameObject gameOverCard;
    [SerializeField] public GameObject levelCompletedCard;
    [SerializeField] public GameObject taskOneCard;
    [SerializeField] public GameObject taskTwoCard;

    [SerializeField] MonoBehaviour playerConScript;

    [SerializeField] private Button resumeBtn;
    [SerializeField] private Button exitBtn;
    [SerializeField] private Button skipLevelBtn;

    private void Start()
    {
        settingsBtn.onClick.AddListener(openSettings);
        SettingsMenuCard.SetActive(false);
        gameOverCard.SetActive(false);
        levelCompletedCard.SetActive(false);
        taskOneCard.SetActive(false);
        taskTwoCard.SetActive(false);

        resumeBtn.onClick.AddListener(resumeGame);
        exitBtn.onClick.AddListener(exitGame);
        skipLevelBtn.onClick.AddListener(skipToNxtLevel);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            openSettings();
        }
    }



    void openSettings()
    {
        Debug.Log("Settings clicked");
        SettingsMenuCard.SetActive(true);
        playerConScript.enabled = false;
        taskOneCard.SetActive(false);
        taskTwoCard.SetActive(false);

    }

    public void displayTask(GameObject task)
    {
        task.SetActive(true);
    }

    public void closeTask(GameObject task)
    {
        task.SetActive(false);
    }

    public void showGameOver()
    {
        Debug.Log("Game Over");
        gameOverCard.SetActive(true);
    }

    public void showLevelCompleted()
    {
        levelCompletedCard.SetActive(true);
    }





    void resumeGame()
    {
        SettingsMenuCard.SetActive(false);
        playerConScript.enabled = true;

    }


    void exitGame()
    {
        SceneManager.LoadScene(0);
    }

    void skipToNxtLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}

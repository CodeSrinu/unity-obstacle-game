using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    [SerializeField] private Button playBtn;
    [SerializeField] private Button quitBtn;


    private void Start()
    {
        playBtn.onClick.AddListener(startGame);
        quitBtn.onClick.AddListener(quitGame);
    }

    void startGame()
    {
        SceneManager.LoadScene(1);
    }

    void quitGame()
    {
        Debug.Log("Game Closed");
        Application.Quit();
        
    }
}

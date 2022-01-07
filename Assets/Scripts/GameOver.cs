using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] InputManager inputManager;
    public GameObject gameOverMenu;

    void Update() {
        //change to if playerLost
            //playerLost being a boolean
        if (Input.GetKeyDown(KeyCode.Escape)) {
            GameOverActivate();
        }
    }

    public void GameOverActivate()
    {
        inputManager.DisableControls();
        gameOverMenu.SetActive(true);
    }

    public void playAgain() 
    { 
        SceneManager.LoadScene("Main", LoadSceneMode.Single); 
    }

    public void menu() 
    { 
        SceneManager.LoadScene("Menu", LoadSceneMode.Single); 
    }
}

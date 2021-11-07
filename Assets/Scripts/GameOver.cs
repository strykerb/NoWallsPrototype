using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject gameOverMenu;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
            gameOverMenu.SetActive(!gameOverMenu.activeSelf);
        }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //add an actual case rather than just "G"
        if (Input.GetKey(KeyCode.G)) {
            endGame();
        }
    }

    public void endGame() {
        //indicate to the player that they have lost
        //pop up a small menu like the one from the main menu with a play again button & a return to menu button
    }

    //onClick for play again button
    private void resetGame() { SceneManager.LoadScene("Main", LoadSceneMode.Single); }

    //onClick for return to menu button
    private void returnToMenu() { SceneManager.LoadScene("Menu", LoadSceneMode.Single); }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayOrMenu : MonoBehaviour
{
    public void playAgain() { SceneManager.LoadScene("Main", LoadSceneMode.Single); }

    public void menu() { SceneManager.LoadScene("Menu", LoadSceneMode.Single); }
}

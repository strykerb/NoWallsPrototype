using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public void changeScene() {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void quit() {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{


    public void LoadMainMenu() {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadGame() {
        SceneManager.LoadScene("Game");
    }

    public void LoadGameOverMenu() {
        SceneManager.LoadScene("Game Over Menu");
    }

    public void QuitGame() {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

}

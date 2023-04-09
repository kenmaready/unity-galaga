using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private float sceneLoadDelay = K.GamePlay.SceneLoadDelay;

    public void LoadMainMenu() {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadGame() {
        SceneManager.LoadScene("Game");
    }

    public void LoadGameOverMenu() {
        StartCoroutine(WaitAndLoad("Game Over Menu", sceneLoadDelay));
    }

    public void QuitGame() {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

}

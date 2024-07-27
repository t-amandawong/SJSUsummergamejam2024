using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject pauseMenuUI;  // Reference to the pause menu UI
    private bool isPaused = false;  // Flag to check if the game is paused

    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
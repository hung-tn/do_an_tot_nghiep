using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameObject pauseGame;
    public void Pause()
    {
        pauseGame.SetActive(true);
        Time.timeScale = 0;
    }
    public void Restart()
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1;
        FindObjectOfType<GameSession>().Resetgame();
        FindObjectOfType<ScenePersist>().ResetScenePersist();
    }
    public void Home()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
    public void Resume()
    {
        pauseGame.SetActive(false);
        Time.timeScale = 1;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    public float delay = 0f;

    public void OnPlayerDeath()
    {
        Invoke("Gameover", delay);
    }
    public void Gameover()
    {
        Time.timeScale = 0;
        gameOver.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1;
        FindObjectOfType<GameSession>().Resetgame();
        FindObjectOfType<ScenePersist>().ResetScenePersist();
    }
    public void Exit()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
}

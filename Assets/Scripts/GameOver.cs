using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOver;

    public void Gameover()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
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

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameSession : MonoBehaviour
{
    [SerializeField] int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    public float Health = 100;
    public float currentHealth;
    [SerializeField] float maxHealth = 100;
    [SerializeField] TMP_Text healthBarText;
    [SerializeField] Slider healthBarSlider;
    private bool isInvincible = false;
    private float timeSinceHit = 0;
    private float timeinvincibaleTime = 1.0f;
    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1 )
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        scoreText.text = score.ToString();
        currentHealth = maxHealth;
        healthBarSlider.maxValue = maxHealth;
        healthBarSlider.value = currentHealth;
        healthBarText.text = "HP " + Health + " / " + maxHealth;
    }
    private float CalculatesSlider(int currentHealth, int maxHealth)
    {
        return currentHealth / maxHealth;
    }
    private void Update()
    {
        if (isInvincible)
        {
            timeSinceHit += Time.deltaTime;
            if (timeSinceHit > timeinvincibaleTime) 
            {
                isInvincible = false;
                timeSinceHit = 0;
            }
        }
    }
    public void ProcessPlayerDeath()
    {
        if (Health > 0 && !isInvincible)
        {
            TakeLife();
        }
        else if (Health <= 0)
        {
            ResetGameSession();
        }
    }
    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }
     void TakeLife()
    {
        Health -= 10;
        currentHealth -= 10;
        if (currentHealth < 0) currentHealth = 0;
        isInvincible = true;
        timeSinceHit = 0;
        healthBarText.text = "HP " + Health + " / " + maxHealth;;
        healthBarSlider.value = currentHealth;
    }

    public void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene("Level 1");
        Destroy(gameObject);
    }
    public void Resetgame()
    {
        Health = 100;
        timeSinceHit = 0;
        isInvincible = false;
        score = 0;
        SceneManager.LoadScene("Level 1");
        Destroy(gameObject);
    }

}

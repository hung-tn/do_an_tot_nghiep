using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameSession : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public float Health = 100;
    public float Mana = 100;
    public float currentHealth;
    public float currentMana;
    private float manaCost = 10;
    private float maxHealth = 100;
    private float maxMana = 100;
    public TMP_Text healthBarText;
    public Slider healthBarSlider;
    public TMP_Text manaBarText;
    public Slider manaBarSlider;
    public bool isInvincible = false;
    private float timeSinceHit = 0;
    private float timeinvincibaleTime = 1.0f;
    public EnemyStats enemyStats;
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
        currentMana = maxMana;
        healthBarSlider.maxValue = maxHealth;
        manaBarSlider.maxValue = maxMana;
        healthBarSlider.value = currentHealth;
        manaBarSlider.value = currentMana;
        healthBarText.text = "HP " + Health + " / " + maxHealth;
        manaBarText.text = "MP " + Mana + " / " + maxMana;
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
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            Destroy(gameObject);
        }
    }
    public void ProcessPlayerDeath()
    {
        if (Health > 0 && !isInvincible)
        {
            TakeLife();
        }
        //else if (Health <= 0)
        //{
        //    ResetGameSession();
        //}
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

    public void ConsumeMana()
    {
        currentMana -= manaCost;
        manaBarText.text = "MP " + currentMana + " / " + maxMana;
        manaBarSlider.value = currentMana;
    }

    public bool CantShoot()
    {
        return currentMana >= manaCost;
    }
}

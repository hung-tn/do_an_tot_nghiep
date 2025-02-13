using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameSession : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    //public float Health = 100;
    //public float Mana = 100;
    public float currentHealth;
    public float currentMana;
    private float manaCost = 10;
    public float maxHealth = 100;
    public float maxMana = 100;
    public TMP_Text healthBarText;
    public Slider healthBarSlider;
    public TMP_Text manaBarText;
    public Slider manaBarSlider;
    public bool isInvincible = false;
    private float timeSinceHit = 0;
    private float timeinvincibaleTime = 1.0f;
    public EnemyStats enemyStats;
    public int hpItem = 0;
    public int mpItem = 0;
    public TMP_Text hpText;
    public TMP_Text mpText;
    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
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
        healthBarText.text = "HP " + currentHealth + " / " + maxHealth;
        manaBarText.text = "MP " + currentMana + " / " + maxMana;
        hpText.text = "HP: " + hpItem;
        mpText.text = "MP: " + mpItem;
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
        if (currentHealth > 0 && !isInvincible)
        {
            TakeLife();
        }
    }
    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    public void AddItemHp()
    {
        hpItem++;
        hpText.text = "HP: " + hpItem;
    }

    public void AddItemMp()
    {
        mpItem++;
        mpText.text = "MP: " + mpItem;
    }
    void TakeLife()
    {
        currentHealth -= 10;
        if (currentHealth < 0) currentHealth = 0;
        isInvincible = true;
        timeSinceHit = 0;
        healthBarText.text = "HP " + currentHealth + " / " + maxHealth;
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
        currentHealth = 100;
        timeSinceHit = 0;
        isInvincible = false;
        score = 0;
        SceneManager.LoadScene("Level 1");
        Destroy(gameObject);
    }

    public void ConsumeMana()
    {
        currentMana -= manaCost;
        currentMana -= manaCost;
        manaBarText.text = "MP " + currentMana + " / " + maxMana;
        manaBarSlider.value = currentMana;
    }

    public bool CantShoot()
    {
        return currentMana >= manaCost;
    }

}

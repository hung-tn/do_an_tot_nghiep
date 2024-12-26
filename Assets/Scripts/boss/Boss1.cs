using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public int maxHealth = 100;  
    private int currentHealth;
    Rigidbody2D myRigidbody;
    public GameObject exit;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    
    public void TakeDamage()
    {
        if (currentHealth < 0)
            currentHealth = 0;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arrow"))
        {
            currentHealth -= 20;
            TakeDamage();
        }
    }

    void Die()
    {
        exit.SetActive(true);
        Destroy(gameObject);  
    }
}


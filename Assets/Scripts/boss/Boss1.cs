using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public int maxHealth = 100;
    public Bullet1 bullet;
    public bullet0 bullet0;
    private float currentHealth;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        bullet = other.GetComponent<Bullet1>();
        bullet0 = other.GetComponent<bullet0>();
        if (other.CompareTag("Arrow0"))
        {
            currentHealth -= bullet0.bulletDame;
            TakeDamage();
        }

        if (other.CompareTag("Arrow"))
        {
            currentHealth -= bullet.bulletDame;
            TakeDamage();
        }
    }

    void Die()
    {
        exit.SetActive(true);
        Destroy(gameObject);  
    }
}


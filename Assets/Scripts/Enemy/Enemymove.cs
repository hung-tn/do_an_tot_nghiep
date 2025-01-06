using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymove : MonoBehaviour
{
    public EnemyStats enemyStats;
    public Bullet1 bullet;
    public bullet0 bullet0;
    Rigidbody2D myRigidbody;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float distance = 5f;
    private Vector3 startPos;
    private bool movingRight = true;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    private void Update()
    {
        float leftBound = startPos.x - distance;
        float rightBound = startPos.x + distance;
        if (movingRight)
        {
            transform.Translate(Vector2.right*speed*Time.deltaTime);
            if (transform.position.x >= rightBound)
            {
                movingRight = false;
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector2.left*speed*Time.deltaTime);
            if (transform.position.x <= leftBound)
            {
                movingRight = true;
                Flip();
            }
        }
    }

    void Flip()
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        bullet = other.GetComponent<Bullet1>();
        bullet0 = other.GetComponent<bullet0>();
        if (other.tag == "Arrow0")
        {
            if (enemyStats.maxHealth > 0)
            {
                enemyStats.maxHealth -= bullet0.bulletDame;
            }
            if (enemyStats.maxHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

        if (other.tag == "Arrow")
        {
            if (enemyStats.maxHealth > 0)
            {
                enemyStats.maxHealth -= bullet.bulletDame;
            }
            if (enemyStats.maxHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

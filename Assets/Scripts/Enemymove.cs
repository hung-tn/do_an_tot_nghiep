using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymove : MonoBehaviour
{
    public EnemyStats enemyStats;
    public Bullet bullet;
    Rigidbody2D myRigidbody;
    private float moveSpeed = 1.0f;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        myRigidbody.velocity = new Vector2(moveSpeed, 0f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        bullet = other.GetComponent<Bullet>();
        if (other.tag == "Bullets")
        {
            if (enemyStats.maxHealth > 0)
            {
                enemyStats.maxHealth -= bullet.bulletDame;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            moveSpeed = -moveSpeed;
            FlipEnemyFacing();
        }
    }
    void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(-Mathf.Sign(myRigidbody.velocity.x), 1f);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymove : MonoBehaviour
{
    public EnemyStats enemyStats;
    public Bullet1 bullet;
    Rigidbody2D myRigidbody;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        bullet = other.GetComponent<Bullet1>();
        if (other.tag == "Arrow")
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
    }
   

}

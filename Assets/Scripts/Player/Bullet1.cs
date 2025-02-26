using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    [SerializeField] float bulletSpeed = 15f;
    public float bulletDame = 50;
    PlayerMove player;
    GameSession gameSessions;
    float xSpeed;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMove>();
        gameSessions = FindObjectOfType<GameSession>();
        if (gameSessions.CantShoot())
        {
            xSpeed = player.transform.localScale.x * bulletSpeed;
            Invoke("Fire", 0.2f);
            gameSessions.ConsumeMana();
        } 
        else
        {
            Destroy(gameObject);
        }
    }
    void Fire()
    {
        myRigidbody.linearVelocity = new Vector2(xSpeed, 0f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }
    }
    
}

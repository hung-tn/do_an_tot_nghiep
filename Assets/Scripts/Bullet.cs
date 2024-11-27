using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    [SerializeField] float bulletSpeed = 15f;
    public float bulletDame = 20;
    PlayerMove player;
    GameSession gameSessions;
    float xSpeed;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMove>();
        gameSessions = FindObjectOfType<GameSession>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
        if (gameSessions.CantShoot())
        {
            gameSessions.ConsumeMana();
        } 
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        myRigidbody.velocity = new Vector2(xSpeed, 0f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}

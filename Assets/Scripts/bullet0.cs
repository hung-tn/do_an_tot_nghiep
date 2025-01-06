using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bullet0 : MonoBehaviour
{

    Rigidbody2D myRigidbody;
    [SerializeField] float bulletSpeed = 15f;
    public float bulletDame = 20;
    PlayerMove player;
    float xSpeed;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMove>();
            xSpeed = player.transform.localScale.x * bulletSpeed;
            Invoke("Fire", 0.2f);
    }
    void Fire()
    {
        myRigidbody.velocity = new Vector2(xSpeed, 0f);
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

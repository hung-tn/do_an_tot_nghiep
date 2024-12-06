using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;  
    public float damage = 20f; 
    private Rigidbody2D rb;
    private Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Tính toán hướng của đạn
        direction = (PlayerMove.instance.transform.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }

        if (other.tag == "Wall")      
        {
            Destroy(gameObject);
        }
    }
}

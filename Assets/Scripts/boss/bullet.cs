using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;  
    public float damage = 20f;
    private Vector2 moveDirection;
    private float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 direction;

    void Start()
    {
        moveSpeed = 5f;
    }

    private void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }

        if (other.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }

}

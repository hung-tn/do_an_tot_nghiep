using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject bulletPrefab;    // Prefab của đạn mà boss sẽ bắn
    public Transform firePoint;        // Vị trí bắn của boss
    public float fireRate = 2f;        // Tốc độ bắn, thời gian giữa mỗi lần bắn
    private float nextFireTime = 0f;   // Thời gian bắn tiếp theo
    public Transform player;           // Vị trí người chơi
    private bool playerInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        // Lấy vị trí của người chơi nếu cần thiết
        player = FindObjectOfType<PlayerMove>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        if (playerInRange && Time.time >= nextFireTime) 
        {
            Attack();   // Gọi hàm tấn công
        }
    }

    void Attack()
    {
        // Cập nhật thời gian tiếp theo khi bắn
        nextFireTime = Time.time + 1f / fireRate;

        // Tạo đạn
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Gọi animation bắn của boss (nếu có)
        // Animator.SetTrigger("Attack");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInRange= false;
        }
    }
}

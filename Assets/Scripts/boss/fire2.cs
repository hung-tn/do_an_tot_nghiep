using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire2 : MonoBehaviour
{
    private float angle = 0f;
    private Vector2 bulletMoveDirection;
    [SerializeField] private float fireRate = 0.2f;
    [SerializeField] private float numBullets = 2;
    void Start()
    {
        InvokeRepeating("Fire", 1f, fireRate);
    }

    private void Fire()
    {
        for (int i = 1; i <= numBullets; i++)
        {
            float angleStep = 360f / numBullets;
            float bulDirX = transform.position.x + Mathf.Sin(((angle + angleStep * i) * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos(((angle + angleStep * i) * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = test.bulletPoolInstanse.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
        }

        angle += 10f;
        if (angle >= 360f)
        {
            angle = 0f;
        }
    }
}

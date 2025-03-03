using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire1 : MonoBehaviour
{
    [SerializeField]
    private int bulletSAmount = 10;
    [SerializeField]
    private float startAngle = 90f, endAngle = 270f;
    [SerializeField]
    private float fireRate = 2f;

    private Vector2 bulletMoveDirection;

    private void Start()
    {
        InvokeRepeating("Fire", 1f, fireRate);
    }
    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletSAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletSAmount + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = test.bulletPoolInstanse.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
            angle += angleStep;
        }
    }
}

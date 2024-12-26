using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public static test bulletPoolInstanse;

    [SerializeField] private GameObject pooledBullet;
    private bool notEnoughBulletasInPool = true;

    private List<GameObject> bullets;

    private void Awake()
    {
        bulletPoolInstanse = this;
    }
    void Start()
    {
        bullets = new List<GameObject>();
    }

    public GameObject GetBullet()
    {
        if (bullets.Count > 0)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }
        if (notEnoughBulletasInPool)
        {
            GameObject bul = Instantiate(pooledBullet);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }
        return null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }

        if (collision.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }

}

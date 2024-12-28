using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupMp : MonoBehaviour
{
    bool wasCollected = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            FindObjectOfType<GameSession>().AddItemMp();
            gameObject.SetActive(false);
        }
    }
}

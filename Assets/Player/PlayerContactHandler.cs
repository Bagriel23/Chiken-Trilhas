using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerContactHandler : MonoBehaviour
{
    public Image itemImage;

    bool canWin = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player collided with enemy");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Debug.Log("Player has collected an item");
            Destroy(collision.gameObject);
            itemImage.color = Color.white;
            canWin = true;
        }

        if (collision.gameObject.CompareTag("FinalPoint"))
        {
            if (canWin)
            {
                Debug.Log("Player has reached the final point");
            }
            else
            {
                Debug.Log("Player has not collected all items");
            }
        }

    }

}

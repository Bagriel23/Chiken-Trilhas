using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerContactHandler : MonoBehaviour
{
    [SerializeField] private string nextLevel;
    [SerializeField] private string gameOverScene;

    public Image itemImage;

    bool canWin = false;

    public PlayerAudioController audioContrtoller;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(gameOverScene);
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

            audioContrtoller.PlayGetItem();
        }

        if (collision.gameObject.CompareTag("FinalPoint"))
        {
            if (canWin)
            {
                SceneManager.LoadScene(nextLevel);
            }
            else
            {
                Debug.Log("Player has not collected all items");
            }
        }

    }

}

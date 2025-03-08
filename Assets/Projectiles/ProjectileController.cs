using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Projectile collided with enemy");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        
            FindFirstObjectByType<SFXController>().PlayEnemyDeath();
        }
    }
}
    

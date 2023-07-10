using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShotCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ManagerCollision(collision);
    }


    private void ManagerCollision(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            Instantiate(Resources.Load("Effects/RedLaserImpactExplosionAnimation") as GameObject, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Door"))
        {
            Destroy(this.gameObject);
        }
    }
}

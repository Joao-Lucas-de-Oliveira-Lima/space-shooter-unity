using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBulletCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ManagerCollision(collision);
    }

    private void ManagerCollision(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(Resources.Load("Effects/CannonBulletImpactExplosionAnimation") as GameObject, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Door"))
        {
            Destroy(this.gameObject);
        }
    }
}

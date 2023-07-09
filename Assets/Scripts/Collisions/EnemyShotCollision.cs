using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ManagerCollision(collision);
    }
    

    private void ManagerCollision(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            Instantiate(Resources.Load("Effects/SingleBulletImpactExplosionAnimation") as GameObject, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }else if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Door"))
        {
            Destroy(this.gameObject);
        }
    }

}

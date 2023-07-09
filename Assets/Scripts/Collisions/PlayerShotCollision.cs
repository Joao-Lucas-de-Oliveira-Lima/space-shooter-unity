using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ManagerCollision(collision);
    }


    private void ManagerCollision(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            Instantiate(Resources.Load("Effects/RedLaserImpactExplosionAnimation") as GameObject, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Door"))
        {
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBulletCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ManagerCollision(collision);
    }
    

    private void ManagerCollision(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(Resources.Load("Effects/SingleBulletImpactExplosionAnimation") as GameObject, this.transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<PlayerStateController>().takeDamage(this.GetComponent<WeaponDamageController>().playerDamage);
            Destroy(this.gameObject);
        }else if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Door"))
        {
            Destroy(this.gameObject);
        }
    }

}

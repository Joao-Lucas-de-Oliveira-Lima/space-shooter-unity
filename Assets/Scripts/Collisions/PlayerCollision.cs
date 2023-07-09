using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ManagerCollision(collision);
    }
    private void ManagerCollision(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {

            //this.GetComponent<Rigidbody2D>().isKinematic = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("EnemyBullet"))
        //{
            this.GetComponent<Rigidbody2D>().isKinematic = false;
        //}
    }
}

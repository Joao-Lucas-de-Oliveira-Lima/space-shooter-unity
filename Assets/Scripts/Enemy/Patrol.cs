using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed = 5f; // Velocidade de movimento da nave

    private Rigidbody2D rb;
    private bool isMovingRight = true;
    private bool isMovingDown = false;

    public float life = 20f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isMovingRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }

        // Verifica a colisão com a parede
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);
        if (hit.collider != null)
        {
            // Se houver uma parede abaixo, inverte a direção vertical
            if (!isMovingDown)
            {
                isMovingDown = true;
                transform.position += new Vector3(0f, -1f, 0f);
            }
            else
            {
                isMovingDown = false;
                transform.position += new Vector3(0f, 1f, 0f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica a colisão com a parede lateral
        if (collision.gameObject.CompareTag("Wall"))
        {
            isMovingRight = !isMovingRight;
        }
    }

private void OnTriggerEnter2D(Collider2D collision)
    {
        ManagerCollision(collision);
    }


    private void ManagerCollision(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            this.life -= 1;
            if (life == 0)
            {
                Instantiate(Resources.Load("Effects/ExplosionAnimation") as GameObject, this.transform.position, Quaternion.identity);
                AudioController.PlaySound("Explosion");
                int currentRoom = GameObject.FindGameObjectWithTag("CurrentRoom").GetComponent<CurrentRoomScript>().currentRoom;
                if (currentRoom == 1)
                {
                    GameObject.FindGameObjectWithTag("FirstRoom").GetComponent<RoomController>().EnemyDefeated();
                }
                else if (currentRoom == 2)
                {
                    GameObject.FindGameObjectWithTag("SecondRoom").GetComponent<RoomController>().EnemyDefeated();
                }
                else if (currentRoom == 3)
                {
                    GameObject.FindGameObjectWithTag("ThirdRoom").GetComponent<RoomController>().EnemyDefeated();
                }
                else if (currentRoom == 4)
                {
                    GameObject.FindGameObjectWithTag("FourthRoom").GetComponent<RoomController>().EnemyDefeated();
                }
                else if (currentRoom == 5)
                {
                    GameObject.FindGameObjectWithTag("FifthRoom").GetComponent<RoomController>().EnemyDefeated();
                }
                Destroy(this.gameObject);
            }
        }

    }
}

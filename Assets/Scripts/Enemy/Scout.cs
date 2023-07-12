using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scout : MonoBehaviour
{
    public float velocidade;
    public float tempoImunidade;
    private Vector3 direcao;
    private bool mudarDirecao;
    private Vector3 novaDirecao;
    private bool emImunidade;
    private Rigidbody2D rb;


    //Enemy life
    public float life = 6f;


    void Start()
    {
        direcao = Vector3.right; // Inicia movendo para a direita
        mudarDirecao = false;
        emImunidade = false;
        GerarNovaDirecao();

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (mudarDirecao)
        {
            // Muda a direção para a nova direção aleatória
            direcao = novaDirecao;
            mudarDirecao = false;

            // Gera uma nova direção aleatória após um intervalo de tempo
            Invoke("GerarNovaDirecao", Random.Range(1f, 3f));
        }

        if (!emImunidade)
        {
            // Calcula a velocidade desejada com base na velocidade e direção
            Vector2 velocidadeDesejada = direcao * velocidade;

            // Define a velocidade do Rigidbody2D
            rb.velocity = velocidadeDesejada;
        }
    }

    public void MudarDirecao()
    {
        if (!emImunidade)
        {
            // Muda a direção para o sentido oposto
            direcao *= -1;
            mudarDirecao = true;

            // Ativa o tempo de imunidade a colisões
            emImunidade = true;
            Invoke("DesativarImunidade", tempoImunidade);
        }
    }

    private void GerarNovaDirecao()
    {
        // Gera uma nova direção aleatória
        float direcaoX = Random.Range(-1f, 1f);
        float direcaoY = Random.Range(-1f, 1f);
        novaDirecao = new Vector3(direcaoX, direcaoY, 0f).normalized;
        mudarDirecao = true;
    }

    private void DesativarImunidade()
    {
        emImunidade = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        MudarDirecao();
        if (collision.gameObject.CompareTag("Player"))
        {
            this.life = 0;

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
        else if (collision.gameObject.CompareTag("RocketExplosion"))
        {
            Debug.Log("Explosão");
            this.life -= 40;
            if (life <= 0)
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
                //collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                Destroy(this.gameObject);
            }

        }

    }



}
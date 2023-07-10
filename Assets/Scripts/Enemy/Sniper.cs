using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour, Enemy
{
    public IWeapon primaryWeapon;

    public string playerTag = "Player";
    public float velocidade = 3f;
    public Transform player;
    private Vector2 direcao;
    private GameObject jogador;
    private Transform playerTransform;
    public float minDistance = 10f;


    public float nextFire = 0.0f;
    public float fireRate = 1f;


    public float raioDeAlcance = 10f;
    public float anguloMaximo;


    //Enemy life
    public float life = 36;


    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        jogador = GameObject.FindGameObjectWithTag(playerTag);

        //OBSERVA��O: eu n�o sei pq, mas o c�digo para olhar para a dire��o do jogador s� funcinou depois q eu fiz uma segunda vari�vel
        //para achar a tag player (declarando private GameObject l� em cima).
        //Eu tentei fazer tudo uma coisa s�, mas apenas a parte da persegui��o funcionava, a de olhar para o player, n�o.
        //Essa pare de olhar para o player eu peguei do c�digo que j� tinha feito no canh�o que sempre fica olhando para o player
        //ent�o assim: o gameobject player (em ingles) que est� dentro do start() � para a persegui��o. E o gameobject jogador (em portugu�s)
        //� para que a nave sempre olhe para o jogador. N�o entendi pq n�o deu certo fazer com um �nico GameObject.
        //Talvez o c�digo pudesse ser mais consiso, mas de qualquer forma, do jeito que est�, est� funcionando!

        if (player != null)
        {
            playerTransform = player.transform;
        }

        this.primaryWeapon = gameObject.AddComponent<SniperBullet>();
    }

    void Update()
    {
        if (playerTransform != null)
        {
            float distance = Vector2.Distance(this.transform.position, playerTransform.position);
            if (distance > minDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, velocidade * Time.deltaTime);
            }
        }
        if (jogador != null)
        {
            direcao = jogador.transform.position - transform.position;
            transform.up = direcao.normalized;
        }

        //Shooting
        if (Time.time > nextFire && VerifyDistance() && VerifyAttackRadius())
        {
            nextFire = Time.time + fireRate;
            primaryWeapon.Shoot();
        }
    }

    public bool VerifyDistance()
    {
        float distancia = Vector3.Distance(transform.position, jogador.transform.position);
        if (distancia <= raioDeAlcance)
            return true;
        else
            return false;
    }

    public bool VerifyAttackRadius()
    {
        Vector3 direcaoJogador = jogador.transform.position - transform.position;
        float angulo = Vector3.Angle(transform.up, direcaoJogador);
        if (angulo > anguloMaximo)
            return true;
        else
            return false;

    }


    //Colis�es
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ManagerCollision(collision);
    }


    private void ManagerCollision(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Aqui");
            Instantiate(Resources.Load("Effects/ExplosionAnimation") as GameObject, this.transform.position, Quaternion.identity);
            AudioController.PlaySound("Explosion");
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            this.life -= 1;
            if (life == 0)
            {
                Instantiate(Resources.Load("Effects/ExplosionAnimation") as GameObject, this.transform.position, Quaternion.identity);
                AudioController.PlaySound("Explosion");
                Destroy(this.gameObject);
            }
        }
    }
}

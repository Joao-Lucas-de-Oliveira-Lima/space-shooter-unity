using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perseguidor : MonoBehaviour, Enemy

{
    public IWeapon primaryWeapon;

    public string playerTag = "Player";
    public float velocidade = 3f;
    public Transform player;
    private Vector2 direcao;
    private GameObject jogador;
    private Transform playerTransform;
    public float minDistance = 2f;


    public float nextFire = 0.0f;
    public float fireRate = 0.4f;


    public float raioDeAlcance = 5f;
    public float anguloMaximo;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        jogador = GameObject.FindGameObjectWithTag(playerTag);

        //OBSERVAÇÃO: eu não sei pq, mas o código para olhar para a direção do jogador só funcinou depois q eu fiz uma segunda variável
        //para achar a tag player (declarando private GameObject lá em cima).
        //Eu tentei fazer tudo uma coisa só, mas apenas a parte da perseguição funcionava, a de olhar para o player, não.
        //Essa pare de olhar para o player eu peguei do código que já tinha feito no canhão que sempre fica olhando para o player
        //então assim: o gameobject player (em ingles) que está dentro do start() é para a perseguição. E o gameobject jogador (em português)
        //é para que a nave sempre olhe para o jogador. Não entendi pq não deu certo fazer com um único GameObject.
        //Talvez o código pudesse ser mais consiso, mas de qualquer forma, do jeito que está, está funcionando!

        if (player != null)
        {
            playerTransform = player.transform;            
        }

        this.primaryWeapon = gameObject.AddComponent<BalaSimples_1>();
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
}

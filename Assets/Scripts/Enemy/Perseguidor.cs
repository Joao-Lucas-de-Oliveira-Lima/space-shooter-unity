using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perseguidor : NoForceCollision, Enemy
{
    public string playerTag = "Player";
    public float velocidade = 3f;
    public Transform player;
    private Vector2 direcao;
    private GameObject jogador;
    private Transform playerTransform;

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
    }

    private void Update()
    {
        if (playerTransform != null)
        {            
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, velocidade * Time.deltaTime);            
        }

        if (jogador != null)
        {
            direcao = jogador.transform.position - transform.position;
            transform.up = direcao.normalized;
        }

    }

    
}

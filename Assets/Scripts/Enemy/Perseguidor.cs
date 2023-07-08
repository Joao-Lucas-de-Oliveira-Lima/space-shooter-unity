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

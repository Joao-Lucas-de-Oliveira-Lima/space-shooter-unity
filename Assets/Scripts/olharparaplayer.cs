using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class olharparaplayer : MonoBehaviour
{
    public string playerTag = "Player";

    private GameObject jogador;
    private Vector2 direcao;

    private void Start()
    {
        jogador = GameObject.FindGameObjectWithTag(playerTag);
    }

    private void Update()
    {
        if (jogador != null)
        {
            direcao = jogador.transform.position - transform.position;
            transform.up = direcao.normalized;
        }
    }
}

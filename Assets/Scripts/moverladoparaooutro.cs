using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverLadoParaoOutro : MonoBehaviour
{
    public float velocidade = 5f;
    public float intervaloMudancaDirecao = 2f;

    private float direcao = 1f;
    private float timer;

    private void Start()
    {
        timer = intervaloMudancaDirecao;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            direcao *= -1f; // Inverte a direção
            timer = intervaloMudancaDirecao;
        }

        float moveAmount = velocidade * direcao * Time.deltaTime;
        transform.Translate(Vector2.right * moveAmount);
    }
}

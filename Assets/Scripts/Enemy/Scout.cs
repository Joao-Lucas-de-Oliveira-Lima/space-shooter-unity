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
    }
}
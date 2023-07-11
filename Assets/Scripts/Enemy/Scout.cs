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
            // Muda a dire��o para a nova dire��o aleat�ria
            direcao = novaDirecao;
            mudarDirecao = false;

            // Gera uma nova dire��o aleat�ria ap�s um intervalo de tempo
            Invoke("GerarNovaDirecao", Random.Range(1f, 3f));
        }

        if (!emImunidade)
        {
            // Calcula a velocidade desejada com base na velocidade e dire��o
            Vector2 velocidadeDesejada = direcao * velocidade;

            // Define a velocidade do Rigidbody2D
            rb.velocity = velocidadeDesejada;
        }
    }

    public void MudarDirecao()
    {
        if (!emImunidade)
        {
            // Muda a dire��o para o sentido oposto
            direcao *= -1;
            mudarDirecao = true;

            // Ativa o tempo de imunidade a colis�es
            emImunidade = true;
            Invoke("DesativarImunidade", tempoImunidade);
        }
    }

    private void GerarNovaDirecao()
    {
        // Gera uma nova dire��o aleat�ria
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
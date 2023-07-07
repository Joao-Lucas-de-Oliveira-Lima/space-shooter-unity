using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispararBalaSimaples : MonoBehaviour
{
    public GameObject prefab;
    public GameObject naveJogador;
    public float intervaloDisparo = 0.5f; // Intervalo de tempo entre os disparos
    public float intensidade = 10f; // Intensidade do disparo
    public AudioSource somDisparo;
    private bool detectado = false;

    private float tempoDecorrido = 0f; // Tempo decorrido desde o último disparo

    private void Update()
    {
        // tempoDecorrido += Time.deltaTime; // Atualiza o tempo decorrido a cada quadro

        //if (tempoDecorrido >= intervaloDisparo)
        //{
        //    Atirar();
        //    tempoDecorrido = 0f; // Reinicia o tempo decorrido
        //}

        //pelo código acima também dá pra fazer disparar em um intervalo fixo de tempo, só que não consegui fazer funcionar pelo
        //trigger do collider. Acho que é pq ele precisa estar no Update(), por conta da contagem de tempo (eu acho).
    }

    private void Atirar()
    {
        GameObject go = Instantiate(prefab, transform.position, transform.rotation);       
        somDisparo.Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.gameObject == naveJogador)
        {
            detectado = true;
            Debug.Log("detectado");
            InvokeRepeating(nameof(Atirar), 0f, intervaloDisparo);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == naveJogador)
        {
            detectado = false; //quando o jogador sai da área do trigger (é um collider 2D), aí o detectado fica falso
            Debug.Log("fugiu!");
            CancelInvoke(nameof(Atirar));
        }
    }
}

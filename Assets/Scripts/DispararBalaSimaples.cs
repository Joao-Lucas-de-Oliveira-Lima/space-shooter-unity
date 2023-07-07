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

    private float tempoDecorrido = 0f; // Tempo decorrido desde o �ltimo disparo

    private void Update()
    {
        // tempoDecorrido += Time.deltaTime; // Atualiza o tempo decorrido a cada quadro

        //if (tempoDecorrido >= intervaloDisparo)
        //{
        //    Atirar();
        //    tempoDecorrido = 0f; // Reinicia o tempo decorrido
        //}

        //pelo c�digo acima tamb�m d� pra fazer disparar em um intervalo fixo de tempo, s� que n�o consegui fazer funcionar pelo
        //trigger do collider. Acho que � pq ele precisa estar no Update(), por conta da contagem de tempo (eu acho).
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
            detectado = false; //quando o jogador sai da �rea do trigger (� um collider 2D), a� o detectado fica falso
            Debug.Log("fugiu!");
            CancelInvoke(nameof(Atirar));
        }
    }
}

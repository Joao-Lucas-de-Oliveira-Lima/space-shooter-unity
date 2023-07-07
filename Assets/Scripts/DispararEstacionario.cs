using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar_ESTACIONARIO : MonoBehaviour
{

    public float velocidade = 5f;
    public GameObject prefab;
    public GameObject naveJogador;
    public float tempoDisparo = 1f;
    private bool detectado = false;
    public AudioSource somDisparo;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("DispararBala", 3f);  //ERA APENAS UM TESTE

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void disparo()
    {       
        GameObject bala = Instantiate(prefab, transform.position, transform.rotation);
        Rigidbody2D rbBala = bala.GetComponent<Rigidbody2D>();
        rbBala.velocity = transform.up * velocidade;
        somDisparo.Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == naveJogador)
        {
            detectado = true;
            //disparo();            
            InvokeRepeating(nameof(disparo), 0f, tempoDisparo); //fica repetindo o disparo (que é uma função) dentro de um intervalo de tempo
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == naveJogador)
        {
            detectado = false; //quando o jogador sai da área do trigger (é um collider 2D), aí o detectado fica falso
            CancelInvoke(nameof(disparo)); //cancela a função disparo, que volta a executar apenas quando o detectador for true
        }
    }
}

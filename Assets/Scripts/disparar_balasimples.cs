using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar_balasimples : MonoBehaviour
{
    public GameObject prefab;
    public float intervaloDisparo = 0.5f; // Intervalo de tempo entre os disparos
    public float intensidade = 10f; // Intensidade do disparo

    private float tempoDecorrido = 0f; // Tempo decorrido desde o último disparo

    private void Update()
    {
        tempoDecorrido += Time.deltaTime; // Atualiza o tempo decorrido a cada quadro

        if (tempoDecorrido >= intervaloDisparo)
        {
            Atirar();
            tempoDecorrido = 0f; // Reinicia o tempo decorrido
        }
    }

    private void Atirar()
    {
        GameObject go = Instantiate(prefab, transform.position, transform.rotation);
        //go.transform.position = transform.position;
        //go.GetComponent<Rigidbody>().AddForce(transform.forward * intensidade);
    }
}

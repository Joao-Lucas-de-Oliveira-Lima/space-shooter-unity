using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoMoverAleatorio : MonoBehaviour
{
    public float velocidade = 3f;
    public float limiteMovimento = 1f;

    private Vector2 direcao;

    private void Start()
    {
        GerarNovaDirecao();
    }

    private void Update()
    {
        transform.Translate(direcao * velocidade * Time.deltaTime);

        if (transform.position.magnitude >= limiteMovimento)
        {
            GerarNovaDirecao();
        }
    }

    private void GerarNovaDirecao()
    {
        direcao = Random.insideUnitCircle.normalized;
    }
}

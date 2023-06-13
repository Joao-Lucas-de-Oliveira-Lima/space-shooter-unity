using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveralvo : MonoBehaviour
{
    public float velocidade = 5f;

    private void Update()
    {
        // Movimento para a esquerda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * velocidade * Time.deltaTime);
        }

        // Movimento para a direita
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        }

        // Movimento para cima
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * velocidade * Time.deltaTime);
        }

        // Movimento para baixo
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * velocidade * Time.deltaTime);
        }
    }
}


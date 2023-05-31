using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class encontrarjogador : MonoBehaviour
{
    public string playerTag = "Player";
    public float velocidadePerseguicao = 3f;

    private Transform playerTransform;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, velocidadePerseguicao * Time.deltaTime);
        }
    }
}

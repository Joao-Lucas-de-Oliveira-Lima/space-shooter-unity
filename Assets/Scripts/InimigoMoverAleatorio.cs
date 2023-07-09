using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f; // Velocidade do inimigo
    public float directionChangeInterval = 2f; // Intervalo de tempo entre mudan�as de dire��o
    public float avoidCollisionDistance = 3f; // Dist�ncia para evitar colis�es
    private float timer; // Temporizador para controlar as mudan�as de dire��o
    private Vector3 currentDirection; // Dire��o atual do movimento

    private void Start()
    {
        currentDirection = GetRandomDirection(); // Define uma dire��o inicial aleat�ria
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= directionChangeInterval)
        {
            currentDirection = GetRandomDirection(); // Define uma nova dire��o aleat�ria
            timer = 0f;
        }

        // Verifica se h� obst�culos � frente
        if (CheckForObstacles())
        {
            currentDirection = GetAvoidanceDirection(); // Define uma dire��o para evitar obst�culos
        }

        // Suaviza a transi��o entre a dire��o atual e a nova dire��o desejada
        Vector3 newDirection = Vector3.Lerp(transform.up, currentDirection, Time.deltaTime);
        transform.up = newDirection;

        // Atualiza a posi��o do inimigo
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private Vector3 GetRandomDirection()
    {
        float angle = Random.Range(0f, 360f); // �ngulo aleat�rio
        Vector3 direction = Quaternion.Euler(0f, 0f, angle) * Vector3.up; // Converte o �ngulo em um vetor de dire��o
        return direction.normalized;
    }

    private bool CheckForObstacles()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, avoidCollisionDistance);
        if (hit.collider != null && hit.collider.CompareTag("Wall"))
        {
            return true; // Obst�culo encontrado
        }
        return false; // Sem obst�culo
    }

    private Vector3 GetAvoidanceDirection()
    {
        // Gera uma dire��o aleat�ria sem obst�culos
        Vector3 avoidanceDirection = GetRandomDirection();

        // Verifica aleatoriamente diferentes dire��es para evitar colis�es
        for (int i = 0; i < 10; i++)
        {
            Vector3 randomDirection = GetRandomDirection();
            RaycastHit2D hit = Physics2D.Raycast(transform.position, randomDirection, avoidCollisionDistance);
            if (hit.collider == null || !hit.collider.CompareTag("Wall"))
            {
                avoidanceDirection = randomDirection;
                break;
            }
        }

        return avoidanceDirection.normalized;
    }
}
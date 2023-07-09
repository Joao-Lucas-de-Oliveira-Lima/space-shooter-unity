using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f; // Velocidade do inimigo
    public float directionChangeInterval = 2f; // Intervalo de tempo entre mudanças de direção
    public float avoidCollisionDistance = 3f; // Distância para evitar colisões
    private float timer; // Temporizador para controlar as mudanças de direção
    private Vector3 currentDirection; // Direção atual do movimento

    private void Start()
    {
        currentDirection = GetRandomDirection(); // Define uma direção inicial aleatória
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= directionChangeInterval)
        {
            currentDirection = GetRandomDirection(); // Define uma nova direção aleatória
            timer = 0f;
        }

        // Verifica se há obstáculos à frente
        if (CheckForObstacles())
        {
            currentDirection = GetAvoidanceDirection(); // Define uma direção para evitar obstáculos
        }

        // Suaviza a transição entre a direção atual e a nova direção desejada
        Vector3 newDirection = Vector3.Lerp(transform.up, currentDirection, Time.deltaTime);
        transform.up = newDirection;

        // Atualiza a posição do inimigo
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private Vector3 GetRandomDirection()
    {
        float angle = Random.Range(0f, 360f); // Ângulo aleatório
        Vector3 direction = Quaternion.Euler(0f, 0f, angle) * Vector3.up; // Converte o ângulo em um vetor de direção
        return direction.normalized;
    }

    private bool CheckForObstacles()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, avoidCollisionDistance);
        if (hit.collider != null && hit.collider.CompareTag("Wall"))
        {
            return true; // Obstáculo encontrado
        }
        return false; // Sem obstáculo
    }

    private Vector3 GetAvoidanceDirection()
    {
        // Gera uma direção aleatória sem obstáculos
        Vector3 avoidanceDirection = GetRandomDirection();

        // Verifica aleatoriamente diferentes direções para evitar colisões
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
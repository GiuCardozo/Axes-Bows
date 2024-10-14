using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float moveSpeed = 3f;         // Velocidad de movimiento del enemigo
    public float detectionRadius = 15f;  // Radio de detecci�n para encontrar al jugador m�s cercano

    private Transform targetPlayer;      // Jugador objetivo
    private Animator SlimeAnimator;


    void Start()
    {
        SlimeAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        // Buscar al jugador m�s cercano
        FindClosestPlayer();

        // Si hay un jugador cercano, perseguirlo
        if (targetPlayer != null)
        {
            MoveTowardsPlayer();
        }
    }

    // Encuentra al jugador m�s cercano dentro del radio de detecci�n
    void FindClosestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player"); // Suponiendo que los jugadores tienen la etiqueta "Player"
        float shortestDistance = detectionRadius; // Limita la b�squeda al radio de detecci�n
        targetPlayer = null;  // Inicializamos como null

        foreach (GameObject player in players)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            // Si la distancia con el jugador actual es menor que la m�s corta registrada, este jugador es el nuevo objetivo
            if (distanceToPlayer < shortestDistance)
            {
                shortestDistance = distanceToPlayer;
                targetPlayer = player.transform;
            }
        }
    }

    // Moverse hacia el jugador en 8 direcciones
    void MoveTowardsPlayer()
    {
        // Direcci�n hacia el jugador
        Vector2 direction = (targetPlayer.position - transform.position).normalized;

        // Mover al enemigo en la direcci�n hacia el jugador
        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);

        SlimeAnimator.SetBool("Moving", true);
        SlimeAnimator.SetFloat("Horizontal", (targetPlayer.position.x - direction.x)); //Brindar al animator las coordenadas horizontales
        SlimeAnimator.SetFloat("Vertical", (targetPlayer.position.y - direction.y)); //Brindar al animator las coordenadas verticales
    }

    // Dibujar el radio de detecci�n en la vista de escena (opcional)
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}

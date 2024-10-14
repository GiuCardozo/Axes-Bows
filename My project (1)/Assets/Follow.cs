using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float moveSpeed = 3f;         // Velocidad de movimiento del enemigo
    public float detectionRadius = 15f;  // Radio de detección para encontrar al jugador más cercano

    private Transform targetPlayer;      // Jugador objetivo
    private Animator SlimeAnimator;


    void Start()
    {
        SlimeAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        // Buscar al jugador más cercano
        FindClosestPlayer();

        // Si hay un jugador cercano, perseguirlo
        if (targetPlayer != null)
        {
            MoveTowardsPlayer();
        }
    }

    // Encuentra al jugador más cercano dentro del radio de detección
    void FindClosestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player"); // Suponiendo que los jugadores tienen la etiqueta "Player"
        float shortestDistance = detectionRadius; // Limita la búsqueda al radio de detección
        targetPlayer = null;  // Inicializamos como null

        foreach (GameObject player in players)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            // Si la distancia con el jugador actual es menor que la más corta registrada, este jugador es el nuevo objetivo
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
        // Dirección hacia el jugador
        Vector2 direction = (targetPlayer.position - transform.position).normalized;

        // Mover al enemigo en la dirección hacia el jugador
        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);

        SlimeAnimator.SetBool("Moving", true);
        SlimeAnimator.SetFloat("Horizontal", (targetPlayer.position.x - direction.x)); //Brindar al animator las coordenadas horizontales
        SlimeAnimator.SetFloat("Vertical", (targetPlayer.position.y - direction.y)); //Brindar al animator las coordenadas verticales
    }

    // Dibujar el radio de detección en la vista de escena (opcional)
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}

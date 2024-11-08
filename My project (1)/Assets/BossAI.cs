using System.Collections;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform firePoint; // Punto desde donde se disparan los proyectiles
    public float projectileSpeed = 10f; // Velocidad del proyectil
    public float fireRate = 2f; // Frecuencia de disparo en segundos
    public float detectionRadius = 15f; // Radio de detección del jugador
    public Animator animator; // Referencia al Animator

    private Transform targetPlayer; // Jugador objetivo

    void Start()
    {
        StartCoroutine(ShootAtPlayer());
        StartCoroutine(PlayAnimationRoutine()); // Iniciar la coroutine para la animación
    }

    void Update()
    {
        FindClosestPlayer(); // Encontrar al jugador más cercano
    }

    // Encuentra el jugador más cercano dentro del radio de detección
    void FindClosestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player"); // Suponiendo que los jugadores tienen la etiqueta "Player"
        float shortestDistance = detectionRadius;
        targetPlayer = null;

        foreach (GameObject player in players)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            if (distanceToPlayer < shortestDistance)
            {
                shortestDistance = distanceToPlayer;
                targetPlayer = player.transform;
            }
        }
    }

    // Corrutina que dispara cada 2 segundos
    IEnumerator ShootAtPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);

            if (targetPlayer != null)
            {
                ShootProjectile();
            }
        }
    }

    // Corrutina para reproducir y detener la animación
    IEnumerator PlayAnimationRoutine()
    {
        // Espera 10 segundos antes de la primera activación
        yield return new WaitForSeconds(10f);

        while (true)
        {
            // Activar la animación usando un Trigger en el Animator
            animator.Play("Attack");

            // Espera 5 segundos para desactivar la animación
            yield return new WaitForSeconds(5f);

            // Desactiva la animación reiniciando el Trigger
            animator.Play("EndAttack");

            yield return new WaitForSeconds(1f);

            animator.Play("Idle");

            // Espera 20 segundos hasta la próxima activación
            yield return new WaitForSeconds(20f);
        }
    }

    // Disparar un proyectil hacia la dirección del jugador
    void ShootProjectile()
    {
        Vector2 direction = (targetPlayer.position - firePoint.position).normalized;
        Vector2 roundedDirection = RoundTo8Directions(direction);

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = roundedDirection * projectileSpeed;

        float angle = Mathf.Atan2(roundedDirection.y, roundedDirection.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    Vector2 RoundTo8Directions(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float roundedAngle = Mathf.Round(angle / 45f) * 45f;
        return new Vector2(Mathf.Cos(roundedAngle * Mathf.Deg2Rad), Mathf.Sin(roundedAngle * Mathf.Deg2Rad)).normalized;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}

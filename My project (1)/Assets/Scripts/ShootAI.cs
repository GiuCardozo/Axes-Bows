using System.Collections;
using UnityEngine;

public class ShootAI : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform firePoint; // Punto desde donde se disparan los proyectiles
    public float projectileSpeed = 10f; // Velocidad del proyectil
    public float fireRate = 2f; // Frecuencia de disparo en segundos
    public float detectionRadius = 15f; // Radio de detecci�n del jugador

    private Transform targetPlayer; // Jugador objetivo
    //private float timeSinceLastShot = 0f;

    void Start()
    {
        StartCoroutine(ShootAtPlayer());
    }

    void Update()
    {
        FindClosestPlayer(); // Encontrar al jugador m�s cercano
    }

    // Encuentra el jugador m�s cercano dentro del radio de detecci�n
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

    // Disparar un proyectil hacia la direcci�n del jugador
    void ShootProjectile()
    {
        // Calcular la direcci�n hacia el jugador
        Vector2 direction = (targetPlayer.position - firePoint.position).normalized;

        // Redondear la direcci�n a las 8 direcciones cardinales
        Vector2 roundedDirection = RoundTo8Directions(direction);

        // Instanciar el proyectil
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        // A�adir velocidad al proyectil
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = roundedDirection * projectileSpeed;

        // Rotar el proyectil para que apunte en la direcci�n correcta
        float angle = Mathf.Atan2(roundedDirection.y, roundedDirection.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    // Redondear una direcci�n a las 8 direcciones cardinales (0�, 45�, 90�, etc.)
    Vector2 RoundTo8Directions(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Redondear el �ngulo a los 45 grados m�s cercanos
        float roundedAngle = Mathf.Round(angle / 45f) * 45f;

        // Convertir el �ngulo redondeado de nuevo a una direcci�n
        return new Vector2(Mathf.Cos(roundedAngle * Mathf.Deg2Rad), Mathf.Sin(roundedAngle * Mathf.Deg2Rad)).normalized;
    }

    // Dibujar el radio de detecci�n en la vista de escena (opcional)
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}


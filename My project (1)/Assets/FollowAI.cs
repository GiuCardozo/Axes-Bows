using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAI : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float minDistance;
    [SerializeField] private Transform player; // El objetivo inicial
    [SerializeField] private List<Transform> possibleTargets; // Lista de otros posibles objetivos
    [SerializeField] private float timeBetweenAttack;
    [SerializeField] private float timeNextAttack;
    private Animator EnemyAnimator;

    void Start()
    {
        EnemyAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player != null) // Solo sigue y ataca si hay un objetivo
        {
            Animations();
            Follow();
        }

        if (timeNextAttack > 0)
        {
            timeNextAttack -= Time.deltaTime;
        }
    }

    private void Animations()
    {
        EnemyAnimator.SetBool("Moving", true);
        EnemyAnimator.SetFloat("Horizontal", (player.position.x - transform.position.x));
        EnemyAnimator.SetFloat("Vertical", (player.position.y - transform.position.y));
    }

    private void Follow()
    {
        if (Vector2.Distance(transform.position, player.position) > minDistance)
        {
            // Moverse hacia el jugador u objetivo actual
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            if (timeNextAttack <= 0)
            {
                Attack();
            }
        }
    }

    private void Attack()
    {
        EnemyAnimator.Play("Attack");
        timeNextAttack = timeBetweenAttack;
    }

    private void AttackComplete()
    {
        EnemyAnimator.Play("Walk");
    }

    // Este método se debe llamar desde el script del jugador cuando el jugador muera
    public void OnTargetDeath()
    {
        // Si hay otros posibles objetivos en la lista, cambiamos al siguiente
        if (possibleTargets.Count > 0)
        {
            player = possibleTargets[0]; // Cambiamos el objetivo al primer objeto en la lista
            possibleTargets.RemoveAt(0); // Eliminamos el objetivo de la lista para no repetir
        }
        else
        {
            player = null; // No hay más objetivos, enemigo se queda sin objetivo
        }
    }
}

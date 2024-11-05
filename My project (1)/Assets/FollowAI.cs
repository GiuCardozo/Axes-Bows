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
        else
        {
            // Cambiar a animación "Idle" si no hay objetivos
            EnemyAnimator.SetBool("Moving", false);
        }

        if (timeNextAttack > 0)
        {
            timeNextAttack -= Time.deltaTime;
        }
    }

    private void Animations()
    {
        if (player == null) return; // Evita errores si el objetivo es nulo

        EnemyAnimator.SetBool("Moving", true);
        EnemyAnimator.SetFloat("Horizontal", (player.position.x - transform.position.x));
        EnemyAnimator.SetFloat("Vertical", (player.position.y - transform.position.y));
    }

    private void Follow()
    {
        if (player == null) return; // Evita errores si el objetivo es nulo

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
        if (possibleTargets.Count > 0)
        {
            player = possibleTargets[0];
            possibleTargets.RemoveAt(0);
            Debug.Log("Objetivo cambiado al siguiente jugador.");
        }
        else
        {
            player = null; // No hay más objetivos
            Debug.Log("Sin objetivos restantes.");
        }
    }
}

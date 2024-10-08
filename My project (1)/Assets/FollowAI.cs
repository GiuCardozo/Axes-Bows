using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAI : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float minDistance;
    [SerializeField] private Transform player;
    [SerializeField] private float timeBetweenAttack; //Tiempo entre ataques
    [SerializeField] private float timeNextAttack; //tiempo para el siguiente ataque
    private Animator EnemyAnimator;

    void Start()
    {
        EnemyAnimator = GetComponent<Animator>();
        
    }

    
    void Update()
    {
        Animations();
        Follow();

        if(timeNextAttack > 0)
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
        if (Vector2.Distance(transform.position, player.position) > minDistance) //Si la posicion del enemigo es mayor a la distancia minima, el enemigo se mueve.
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime); //moverse hacia el jugador
        }
        else
        {
            if (timeNextAttack <= 0) //Si el tiempo para el siguiente ataque es menor o igual a cero, ejecutar
            {
                Attack();
            }
        }
    }

    private void Attack()
    {
        EnemyAnimator.Play("Attack");
        timeNextAttack = timeBetweenAttack; //Reiniciar el contador del tiempo para siguiente ataque
    }

    private void AttackComplete()
    {
        EnemyAnimator.Play("Walk");
    }
}

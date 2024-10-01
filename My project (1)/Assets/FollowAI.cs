using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAI : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float minDistance;
    [SerializeField] private Transform player;
    private Animator EnemyAnimator;

    void Start()
    {
        EnemyAnimator = GetComponent<Animator>();
        
    }

    
    void Update()
    {
        Animations();
        Follow();
        
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
            Attack();
        }
    }

    private void Attack()
    {
        Debug.Log("Atacando");
    }
}

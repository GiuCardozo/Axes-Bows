using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAI : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform player;
    private Animator EnemyAnimator;

    void Start()
    {
        EnemyAnimator = GetComponent<Animator>();
        
    }

    
    void Update()
    {
        EnemyAnimator.SetBool("Moving", true);
        EnemyAnimator.SetFloat("Horizontal", (player.position.x - transform.position.x));
        EnemyAnimator.SetFloat("Vertical", (player.position.y - transform.position.y));
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}

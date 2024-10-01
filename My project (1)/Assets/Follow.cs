using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform player;
    private Animator SlimeAnimator;

    void Start()
    {
        SlimeAnimator = GetComponent<Animator>();

    }


    void Update()
    {
        Animations();
        Following();

    }

    private void Animations()
    {
        SlimeAnimator.SetBool("Moving", true);
        SlimeAnimator.SetFloat("Horizontal", (player.position.x - transform.position.x));
        SlimeAnimator.SetFloat("Vertical", (player.position.y - transform.position.y));
    }

    private void Following()
    {
       transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime); //moverse hacia el jugador
     }
}

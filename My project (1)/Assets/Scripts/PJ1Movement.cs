using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTopDown : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Vector2 moveInput;
    private Rigidbody2D rb2D;
    private Animator player1Animator;
    [SerializeField] private string inputNameHorizontal;
    [SerializeField] private string inputNameVertical;
    private float inputHorizontal;
    private float inputVertical;
    bool isAttacking;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        player1Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Movement();
    }

    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + moveInput * Speed * Time.fixedDeltaTime);

    }

    private void Movement()
    {
        inputHorizontal = Input.GetAxisRaw(inputNameHorizontal);
        inputVertical = Input.GetAxisRaw(inputNameVertical);
        moveInput = new Vector2(inputHorizontal, inputVertical).normalized;
        player1Animator.SetFloat("Horizontal", inputHorizontal);
        player1Animator.SetFloat("Vertical", inputVertical);
        player1Animator.SetFloat("Speed", moveInput.magnitude);

        if (Input.GetKeyDown(KeyCode.K))
        {
            player1Animator.Play("Attack");
            isAttacking = true;
            Speed = 0;

        }

        if (isAttacking) return;
    }

    private void EndAttack()
    {
        isAttacking = false;
        player1Animator.Play("Walk");
        Speed = 6;
    }

}
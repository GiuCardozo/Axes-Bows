using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJ2 : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Vector2 moveInput;
    private Vector2 lastMoveDirection;
    private Rigidbody2D rb2D;
    private Animator player2Animator;
    [SerializeField] private string inputNameHorizontal;
    [SerializeField] private string inputNameVertical;
    private float inputHorizontal;
    private float inputVertical;
    public GameObject arrow;

    [SerializeField] private float fireCooldown = 1f; // Tiempo de espera entre disparos en segundos
    private float nextFireTime = 0f; // Tiempo en el que se permitirá el siguiente disparo

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        player2Animator = GetComponent<Animator>();
        lastMoveDirection = Vector2.down;
    }

    private void Update()
    {
        Movement();
        Inputs();
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

        if (moveInput != Vector2.zero)
        {
            lastMoveDirection = moveInput;
        }

        player2Animator.SetFloat("Horizontal", inputHorizontal);
        player2Animator.SetFloat("Vertical", inputVertical);
        player2Animator.SetFloat("Speed", moveInput.magnitude);
    }

    private void Inputs()
    {
        // Verifica si el cooldown ha terminado antes de permitir otro disparo
        if (Input.GetKeyDown(KeyCode.T) && Time.time >= nextFireTime)
        {
            Shoot();
            Speed = 0;

            // Establece el tiempo para el siguiente disparo
            nextFireTime = Time.time + fireCooldown;
        }
    }

    private void Shoot()
    {
        player2Animator.SetBool("isAttacking", true);
        AttackAnimDirection();
    }

    private void Shooting()
    {
        var obj = Instantiate(arrow);
        Vector2 direction = lastMoveDirection;

        obj.transform.eulerAngles = new Vector3(0, 0, Vector2.SignedAngle(new Vector2(direction.x, -direction.y), Vector2.right));
        obj.transform.position = transform.position + new Vector3(direction.x, 0, direction.y) * 0.2f;
        obj.GetComponent<Rigidbody2D>().velocity = direction * 10;
    }

    private void AttackAnimDirection()
    {
        moveInput.x = player2Animator.GetFloat("Horizontal");
        moveInput.y = player2Animator.GetFloat("Vertical");

        if (Mathf.Abs(moveInput.y) > Mathf.Abs(moveInput.x))
        {
            moveInput.x = 0;
        }
        else
        {
            moveInput.y = 0;
        }
        moveInput = moveInput.normalized;

        player2Animator.SetFloat("Horizontal", moveInput.x);
        player2Animator.SetFloat("Vertical", moveInput.y);

        moveInput = Vector2.zero;
    }

    private void EndAttack()
    {
        player2Animator.SetBool("isAttacking", false);
        Speed = 5;
    }
}


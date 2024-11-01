using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement2 : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb2D;

    [SerializeField] private KeyCode jumpKey; // Tecla para el salto
    [SerializeField] private KeyCode moveLeftKey; // Tecla para moverse a la izquierda
    [SerializeField] private KeyCode moveRightKey; // Tecla para moverse a la derecha

    private bool isGrounded;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckGround();
        Move();

        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            Jump();
        }
    }

    private void Move()
    {
        Vector2 moveInput = Vector2.zero;

        // Movimiento a la izquierda
        if (Input.GetKey(moveLeftKey))
        {
            moveInput = Vector2.left;
        }
        // Movimiento a la derecha
        else if (Input.GetKey(moveRightKey))
        {
            moveInput = Vector2.right;
        }

        rb2D.velocity = new Vector2(moveInput.x * Speed, rb2D.velocity.y);
    }

    private void Jump()
    {
        rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        // Verifica si el personaje está en el suelo usando una detección en círculo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}


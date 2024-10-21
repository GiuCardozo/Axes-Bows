using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Vector2 moveInput;
    private Vector2 lastMoveDirection; // Para almacenar la última dirección válida
    private Rigidbody2D rb2D;
    [SerializeField] private string inputNameHorizontal;
    [SerializeField] private string inputNameVertical;
    private float inputHorizontal;
    private float inputVertical;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        //lastMoveDirection = Vector2.down; // Dirección por defecto hacia abajo
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

        if (moveInput != Vector2.zero)
        {
            lastMoveDirection = moveInput; // Actualiza la última dirección válida solo si se está moviendo
        }

    }
}

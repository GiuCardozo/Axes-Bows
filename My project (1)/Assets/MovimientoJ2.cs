using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJ2 : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Vector2 moveInput;
    private Rigidbody2D rb2D;
    private Animator player2Animator;
    [SerializeField] private string inputNameHorizontal;
    [SerializeField] private string inputNameVertical;
    private float inputHorizontal;
    private float inputVertical;
    public GameObject arrow;
    //bool isAttacking;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        player2Animator = GetComponent<Animator>();
        // isAttacking = false;
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
        player2Animator.SetFloat("Horizontal", inputHorizontal);
        player2Animator.SetFloat("Vertical", inputVertical);
        player2Animator.SetFloat("Speed", moveInput.magnitude);

    }

    private void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Shoot();
            Speed = 0;
        }
    }

    private void Shoot()
    {
        //isAttacking = true;
        //player2Animator.Play("Attack");
        player2Animator.SetBool("isAttacking", true);
        AttackAnimDirection();
        
    }

    private void Shooting()
    {
        var obj = Instantiate(arrow);
        Vector2 direction = new Vector2(player2Animator.GetFloat("Horizontal"), player2Animator.GetFloat("Vertical"));
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
        } else
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
        Speed = 3;
        //isAttacking = false;
    }
}

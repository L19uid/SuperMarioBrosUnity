using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Utils")]
    private Rigidbody2D _rb;
    public GameObject pVisuals;

    [Header("Stats")]
    public float moveSpeed;
    private Vector2 moveInput;

    public float jumpForce;

    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize;
    public LayerMask mask;
    private bool isGrounded;

    [Header("Animator")]
    public Animator animator;

    [Header("Killer")]
    public LayerMask enemyMask;
    public Vector2 enemyCheckSize;

    public bool canMove = true;
    public bool canDie = false;


    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        animator = pVisuals.transform.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        Debug.Log(Time.timeScale);

        if (!canMove)
        {
            // Checks whether we are standing on a ground surface.
            isGrounded = Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, (int)mask);

            CheckGumba();

            // Gets input.
            moveInput.x = Input.GetAxisRaw("Horizontal");

            // Flips the visuals depending on the input.
            Flipper();

            // Jumping.
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump(jumpForce);
            }

            Animate();
        }
    }

    public void CheckGumba()
    {
        Collider2D hit = Physics2D.OverlapBox(groundCheckPos.position, enemyCheckSize, 0, (int)enemyMask);

        if (hit != null)
        {
            hit.transform.GetComponent<GumbaScript>().Die();
            Jump(300);
        }
    }

    public void Animate()
    {
        if (moveInput.x != 0)
            animator.SetBool("isMoving", false);
        else
            animator.SetBool("isMoving", true);
    }

    private void FixedUpdate()
    {
        // Moves the player.
        _rb.AddForce(moveInput * moveSpeed);
    }

    public void Jump(float force)
    {
        _rb.AddForce(new Vector2(0, force), ForceMode2D.Force);
    }

    public void Flipper()
    {
        // Flips the sprite depending on the input so the player is facing the way they walk.
        if (moveInput.x > 0) pVisuals.transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput.x < 0) pVisuals.transform.localScale = new Vector3(-1, 1, 1);
    }

    private void OnDrawGizmos()
    {
        // Draws an outline of our groundcheck.
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);

        // Draws an outline of cast to kill gumba.
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheckPos.position, enemyCheckSize);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Utils")]
    private Rigidbody2D _rb;
    public GameObject pVisuals;

    [Header("Health")]  
    public PlayerStatus pStatus = PlayerStatus.normal;
    public enum PlayerStatus { normal, big};
    [Header("Small mario")]  
    public Vector2 bigMarioSize;
    public Vector2 bigMarioOffset;
    public Sprite smallMarioSprite;
    [Header("Big mario")]
    public Vector2 smallMarioSize;
    public Vector2 smallMarioOffset;
    public Sprite bigMarioSprite;

    [Header("Stats")]
    public float moveSpeed;
    private Vector2 moveInput;

    public float jumpForce;

    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize;
    public Vector2 groundCheckSizeBig;
    public LayerMask mask;
    private bool isGrounded;

    [Header("GroundCheck")]
    public Animator animator;

    public bool canMove = true;


    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        animator = pVisuals.transform.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (!canMove)
        {
            // Checks whether we are standing on a ground surface.
            isGrounded = Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, (int)mask);

            // Gets input.
            moveInput.x = Input.GetAxisRaw("Horizontal");

            // Flips the visuals depending on the input.
            Flipper();

            // Jumping.
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Jump(jumpForce);
            }

            if(moveInput.x != 0)
                animator.SetBool("isMoving", false);
            else
                animator.SetBool("isMoving", true);
        }
    }

    public void EndGame()
    {

    }

    public void ChangeHealth(int i)
    {
        if (i < 0 && pStatus == PlayerStatus.normal) EndGame();

        if (i > 0)
        {
            pStatus = PlayerStatus.big;

            gameObject.GetComponent<BoxCollider2D>().size = bigMarioSize;
            gameObject.GetComponent<BoxCollider2D>().offset = bigMarioSize;
            animator.SetBool("isBig", true);
        }
        else 
        { 
            pStatus = PlayerStatus.normal;

            gameObject.GetComponent<BoxCollider2D>().size = smallMarioSize;
            gameObject.GetComponent<BoxCollider2D>().offset = smallMarioSize;
            animator.SetBool("isBig", false);
        }
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

        // Draws an outline of small collider.
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector2(gameObject.transform.position.x + smallMarioOffset.x, gameObject.transform.position.y + smallMarioOffset.y), smallMarioSize);

        // Draws an outline of big collider.
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(new Vector2(gameObject.transform.position.x + bigMarioOffset.x, gameObject.transform.position.y + bigMarioOffset.y), bigMarioSize);
    }
}

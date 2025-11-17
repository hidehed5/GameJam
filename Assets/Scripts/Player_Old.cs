using UnityEngine;

public class Player_Old : MonoBehaviour
{
    public int TimeCoins;
    public float moveSpped = 5f;
    public float jumpforce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundlayer;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2d;
    private bool isGrounded;
    private float moveInput;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocityX, jumpforce);
        }
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb2d.linearVelocity = new Vector2(moveInput * moveSpped, rb2d.linearVelocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundlayer);

        if (moveInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}   
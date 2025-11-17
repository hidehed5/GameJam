using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_New : MonoBehaviour
{
    public InputSystem_Actions actions;
    Rigidbody2D rb2d;
    public Transform groundCheckTransform;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    bool isGrounded;
    private SpriteRenderer spriteRenderer;

    float move;
    public float moveSpeed;
    public float jumpForce;
    public int TimeCoins;

    private void Awake()
    {
         actions = new InputSystem_Actions();
    }

    void OnEnable()
    {
        actions.Player.Enable();
        actions.Player.Move.performed += Movement;
        actions.Player.Jump.performed += Jumping;

        actions.Player.Move.canceled += Movement;
        actions.Player.Jump.canceled += Jumping;
    }

    void OnDisable()
    {
        actions.Player.Disable();
        actions.Player.Move.performed -= Movement;
        actions.Player.Jump.performed -= Jumping;
    }

    void Movement(InputAction.CallbackContext ctx)
    {
        move = ctx.ReadValue<Vector2>().x;
    }

    void Jumping(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (isGrounded)
            {
                rb2d.linearVelocityY = jumpForce;
            }
        }
    }

    private void Start()
    {
        rb2d  = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckTransform.position, groundCheckRadius, groundLayer);
        rb2d.linearVelocityX = move * moveSpeed;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckTransform.position, groundCheckRadius);
    }

    private void FixedUpdate()
    {
        if (move > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (move < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}

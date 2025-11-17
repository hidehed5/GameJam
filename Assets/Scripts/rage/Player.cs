using UnityEngine;

public class Player : MonoBehaviour
{
    public int TimeCoins;
    public float moveSpped = 5f;
    public float jumpforce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundlayer;

    private Rigidbody2D rb2d;
    private bool isGrounded;

    // 비누 관련
    private bool isOnSoap = false;
    private Vector2 soapDirection;
    public float soapForce = 20f;
    public float soapDuration = 0.3f;
    private float soapTimer = 0f;

    // 퍼즐 관련
    private Vector3 startPosition;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        startPosition = transform.position; // 시작 위치 저장
    }

    void Update()
    {
        // 땅 체크
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundlayer);

        if (isOnSoap)
        {
            soapTimer -= Time.deltaTime;
            rb2d.linearVelocity = new Vector2(soapDirection.x * soapForce, rb2d.linearVelocity.y);

            if (soapTimer <= 0)
                isOnSoap = false;

            return;
        }

        // 일반 이동
        float moveInput = Input.GetAxis("Horizontal");
        rb2d.linearVelocity = new Vector2(moveInput * moveSpped, rb2d.linearVelocity.y);

        // 점프
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpforce);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Soap"))
        {
            isOnSoap = true;
            soapDirection = (Random.value > 0.5f) ? Vector2.right : Vector2.left;
            soapTimer = soapDuration;
        }
    }

    // 플레이어 위치 초기화
    public void ResetPosition()
    {
        transform.position = startPosition;
        rb2d.linearVelocity = Vector2.zero;
    }
}

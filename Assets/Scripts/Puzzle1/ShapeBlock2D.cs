using UnityEngine;

public class ShapeBlock2D : MonoBehaviour
{
    public string shapeType;        // "Circle", "Triangle"
    public bool isPlaced = false;

    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void Push(Vector2 direction, float force)
    {
        if (!isPlaced)
            rb2d.linearVelocity = direction * force;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TargetSlot2D slot = collision.GetComponent<TargetSlot2D>();
        if (slot != null && slot.shapeType == shapeType)
        {
            // 정확히 맞는 위치로 스냅
            transform.position = slot.transform.position;
            rb2d.linearVelocity = Vector2.zero;
            isPlaced = true;
            slot.isOccupied = true;

            // 색상 변화
            spriteRenderer.color = Color.yellow;

            Debug.Log(shapeType + " placed!");
        }
    }
}

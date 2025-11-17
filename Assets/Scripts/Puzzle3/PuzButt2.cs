using UnityEngine;
using UnityEngine.Events;

public class PuzzleButtonBlock : MonoBehaviour
{
    public bool isPressed = false;
    private Color originalColor;
    private Vector3 originalPosition;
    public float pressDepth = 0.1f;
    public float pressSpeed = 5f;

    public UnityEvent OnButtonPressed;

    private Coroutine pressCoroutine;

    private void Start()
    {
        originalPosition = transform.position;
        originalColor = GetComponent<SpriteRenderer>().color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Player 체크 제거 → Player가 밟아도 버튼 활성화 안 됨
        if (collision.GetComponent<MovableBlock>())
        {
            isPressed = true;
            if (pressCoroutine != null) StopCoroutine(pressCoroutine);
            pressCoroutine = StartCoroutine(PressButtonDown());
            OnButtonPressed?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<MovableBlock>())
        {
            isPressed = false;
            if (pressCoroutine != null) StopCoroutine(pressCoroutine);
            pressCoroutine = StartCoroutine(ReleaseButton());
        }
    }

    private System.Collections.IEnumerator PressButtonDown()
    {
        Vector3 target = originalPosition - new Vector3(0, pressDepth, 0);
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        while (Vector3.Distance(transform.position, target) > 0.001f)
        {
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * pressSpeed);
            sr.color = Color.Lerp(sr.color, Color.green, Time.deltaTime * pressSpeed);
            yield return null;
        }
        transform.position = target;
        sr.color = Color.green;
    }

    private System.Collections.IEnumerator ReleaseButton()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        while (Vector3.Distance(transform.position, originalPosition) > 0.001f)
        {
            transform.position = Vector3.Lerp(transform.position, originalPosition, Time.deltaTime * pressSpeed);
            sr.color = Color.Lerp(sr.color, originalColor, Time.deltaTime * pressSpeed);
            yield return null;
        }
        transform.position = originalPosition;
        sr.color = originalColor;
    }
}

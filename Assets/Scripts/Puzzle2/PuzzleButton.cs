using UnityEngine;
using UnityEngine.Events;

public class PuzzleButton : MonoBehaviour
{
    public int buttonOrder;
    public UnityEvent onCorrectPress;
    public UnityEvent onWrongPress;

    private bool pressed = false;
    private Vector3 originalPosition;
    public float pressDepth = 0.2f;
    public float pressSpeed = 5f;

    private Color originalColor; // 버튼 원래 색 저장

    private void Start()
    {
        originalPosition = transform.position;
        originalColor = GetComponent<SpriteRenderer>().color; // Inspector 색 저장
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !pressed)
        {
            pressed = true;
            PuzzleManager.Instance.ButtonPressed(buttonOrder, this);
            StopAllCoroutines();
            StartCoroutine(PressButton());
        }
    }

    private System.Collections.IEnumerator PressButton()
    {
        Vector3 target = originalPosition - new Vector3(0, pressDepth, 0);

        // 눌림 애니메이션
        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * pressSpeed);
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);

        // 원위치로 복귀
        while (Vector3.Distance(transform.position, originalPosition) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, originalPosition, Time.deltaTime * pressSpeed);
            yield return null;
        }
    }

    // 버튼 시각적 눌림 처리
    public void SetPressedVisual()
    {
        GetComponent<SpriteRenderer>().color = Color.green; // 눌린 색
    }

    // 버튼 초기화 (순서 틀렸을 때)
    public void ResetButton()
    {
        pressed = false;
        transform.position = originalPosition;
        GetComponent<SpriteRenderer>().color = originalColor; // 원래 색으로 복귀
    }
}

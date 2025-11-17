using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isOpen = false;
    private SpriteRenderer sr;
    public Color openColor = Color.green; // 문이 열릴 때 바꿀 색

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
       
    }

    public void OpenDoor()
    {
        if (isOpen) return;
        isOpen = true;

        if (sr != null)
        {
            sr.color = openColor; // 문 색 변경
        }

        Debug.Log("문이 열렸습니다!");
        // gameObject.SetActive(false); // 사라지던 부분 제거
    }
}

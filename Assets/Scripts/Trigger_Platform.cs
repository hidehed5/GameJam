using UnityEngine;

public class Trigger_Platform : MonoBehaviour
{
    [SerializeField]
    private Moving_Platform targetPlatform;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (targetPlatform != null)
            {
                targetPlatform.trigger = true;

                Debug.Log("트리거 작동: Moving_Platform의 trigger 값이 True로 변경됨.");

                Destroy(gameObject);
            }
        }
    }
}

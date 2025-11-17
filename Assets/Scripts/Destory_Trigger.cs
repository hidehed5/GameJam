using Unity.Cinemachine;
using UnityEngine;

public class Destory_Trigger : MonoBehaviour
{
    //[SerializeField]
    //private Moving_Platform MP_Destroy;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Moving_Platform"))
        {
            Debug.Log("디스트로이 트리거 작동 됨");
            Destroy(other.gameObject);
        }
    }
}
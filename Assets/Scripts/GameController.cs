using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector2 StartPos;
    //SpriteRenderer spriteRenderer;
    Rigidbody2D rb2d;

    private void Awake()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    void Die ()
    {
        StartCoroutine(Respawn(0.5f));
    }
    IEnumerator Respawn(float duraction)
    {
        rb2d.simulated = false;
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duraction);
        transform.position = StartPos;
        transform.localScale = new Vector3(1, 1, 1);
        rb2d.simulated = true;
    }
}

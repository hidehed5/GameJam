using UnityEngine;

public class PuzzleGoalZone : MonoBehaviour
{
    public bool isBlockInside = false; // ← public으로 선언

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Block"))
        {
            isBlockInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Block"))
        {
            isBlockInside = false;
        }
    }
}

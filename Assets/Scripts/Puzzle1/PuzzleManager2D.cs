using UnityEngine;

public class PuzzleManager2D : MonoBehaviour
{
    public ShapeBlock2D[] blocks; // ShapeBlock1, ShapeBlock2 연결

    private bool isCleared = false;

    void Update()
    {
        if (isCleared) return;

        bool allPlaced = true;
        foreach (ShapeBlock2D block in blocks)
        {
            if (!block.isPlaced)
            {
                allPlaced = false;
                break;
            }
        }

        if (allPlaced)
        {
            isCleared = true;
            Debug.Log("🎉 Puzzle Completed! (블록 색상으로 표시)");
        }
    }
}

using UnityEngine;
using System.Collections.Generic;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    public List<PuzzleButton> buttonsInOrder;
    private int currentIndex = 0;

    private Player player;

    private void Awake()
    {
        Instance = this;
        player = Object.FindFirstObjectByType<Player>();
    }

    public void ButtonPressed(int order, PuzzleButton button)
    {
        if (order == currentIndex)
        {
            button.SetPressedVisual();
            currentIndex++;

            if (currentIndex >= buttonsInOrder.Count)
            {
                Debug.Log("퍼즐 클리어!");
            }
        }
        else
        {
            Debug.Log("순서 틀림! 초기화");
            ResetPuzzle();
        }
    }

    void ResetPuzzle()
    {
        currentIndex = 0;

        foreach (var btn in buttonsInOrder)
        {
            btn.ResetButton();
        }

        if (player != null)
            player.ResetPosition();
    }
}

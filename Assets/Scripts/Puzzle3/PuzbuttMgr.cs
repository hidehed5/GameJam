using UnityEngine;

public class PuzzleManagerBlock : MonoBehaviour
{
    public PuzzleButtonBlock puzzleButton;
    public PuzzleGoalZone goalZone;
    public Door door;
    private bool doorOpened = false;

    void Update()
    {
        if (!doorOpened && (puzzleButton.isPressed || goalZone.isBlockInside))
        {
            door.OpenDoor();
            doorOpened = true;
        }
    }
}

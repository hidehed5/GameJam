using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player_New player = collision.gameObject.GetComponent<Player_New>();
            player.TimeCoins += 1;
            Destroy(gameObject);
        } 
    }
}

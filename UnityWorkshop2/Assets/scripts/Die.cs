using UnityEngine;

public class Die : MonoBehaviour
{
    public PlayerMovement player;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = player.originalPosition;
        }
    }
}

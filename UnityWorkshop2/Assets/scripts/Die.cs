using UnityEngine;

public class Die : MonoBehaviour
{
    public PlayerMovement player;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //TODO: When player dies send back to originalPosition
            player.transform.position = Vector2.zero;
        }
    }
}

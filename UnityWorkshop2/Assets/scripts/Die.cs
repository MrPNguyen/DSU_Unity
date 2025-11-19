using UnityEngine;

public class Die : MonoBehaviour
{
    public PlayerManager player;
    public GameObject Text;
    public GameObject Buttons;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //TODO: When player dies send back to originalPosition
            player.transform.position = player.originalPosition;
            player.Hit();
            if (player.currentHealth <= 0)
            {
                Text.SetActive(true);
                Buttons.SetActive(true);
            }
        }
    }
}

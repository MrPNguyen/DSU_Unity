using Unity.VisualScripting;
using UnityEngine;

public class GreenKey : MonoBehaviour
{
    public PlayerManager playerManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            playerManager.KeyPickUp();
        }
    }
}

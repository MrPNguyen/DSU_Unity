using UnityEngine;

public class Win : MonoBehaviour
{ 
    public GameObject Text;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Text.SetActive(true);
        }
    }
}

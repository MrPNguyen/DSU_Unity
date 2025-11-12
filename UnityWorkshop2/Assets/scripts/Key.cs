using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject Door;
    public GameObject openDoor;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit");
            gameObject.SetActive(false);
            Door.SetActive(false);
            openDoor.SetActive(true);
        }
    }
}

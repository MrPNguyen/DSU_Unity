using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject Door;
    public GameObject openDoor;
    public AudioSource doorAudio;
    public AudioSource KeyAudio;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit");
            KeyAudio.Play();
            doorAudio.Play();
            gameObject.SetActive(false);
            Door.SetActive(false);
            openDoor.SetActive(true);
        }
    }
}

using UnityEngine;

public class Win : MonoBehaviour
{ 
    public GameObject Text;
    public GameObject Buttons;
    public AudioSource winSound;
    public AudioSource backgroundMusic;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            backgroundMusic.Stop();
            winSound.Play();
            Text.SetActive(true);
            Buttons.SetActive(true);
        }
    }
}

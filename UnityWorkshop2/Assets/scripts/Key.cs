using UnityEngine;

public class Key : MonoBehaviour
{
    public AudioSource doorAudio;
    public AudioSource KeyAudio;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit");
            KeyAudio.Play();
            doorAudio.Play();
            gameObject.SetActive(false);
            animator.SetBool("doorOpened", true);
        }
    }
}

using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
    public Animator animator;
    public GameObject key;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("blockHit", true);
            key.SetActive(true);
        }
    }
}

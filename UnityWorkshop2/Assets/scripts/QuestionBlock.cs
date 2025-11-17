using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("blockHit", true);
        }
    }
}

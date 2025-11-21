using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    private const float ScrollSpeed = 2f;

    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        bool isMoving = animator.GetBool("isMoving");
        if (isMoving)
        {
            transform.position += new Vector3(Time.deltaTime * ScrollSpeed, 0, 0);
        }
    }
}

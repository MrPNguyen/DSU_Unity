using UnityEngine;

public class TextFollow : MonoBehaviour
{
    public Transform target;  // Assign your character in Inspector
    public Vector3 offset;    // Adjust to position text above character

    void Update()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}

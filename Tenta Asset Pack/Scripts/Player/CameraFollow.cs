using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float CameraSpeed = 2f;

    public Transform target;
    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);

        if (newPos.x < -0.1f)
        {
            newPos.x = -0.1f;
        }
        transform.position = Vector3.Slerp(transform.position, newPos, CameraSpeed * CameraSpeed*Time.deltaTime);
    }
}

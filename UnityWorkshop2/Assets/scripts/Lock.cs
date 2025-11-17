using UnityEngine;
using UnityEngine.InputSystem;

public class Lock : MonoBehaviour
{
    public GameObject canvas;
    public PlayerManager playerManager;
    public GameObject barricade;
    private bool InRange;

    void Update()
    {
        if (InRange)
        {
            canvas.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InRange = true;
            if (Input.GetKeyDown(KeyCode.E) && playerManager.KeyCount != 0)
            {
                barricade.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        InRange = false;
    }
}

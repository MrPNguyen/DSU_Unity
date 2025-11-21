using UnityEngine;
using UnityEngine.Events;

public class InteractEvent : MonoBehaviour
{
    public GameObject interactText;
    public bool isInRange;
    public KeyCode interactkey;
    public UnityEvent interactAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactkey))
            {
                interactAction.Invoke();
            }
        }   
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            interactText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            interactText.SetActive(false);
        }
    }
}

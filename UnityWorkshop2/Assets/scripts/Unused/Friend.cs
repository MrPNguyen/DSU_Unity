using UnityEngine;

public class Friend : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;
    private bool InRange;
    public GameObject canvas;
    void Update()
    {
        if (InRange)
        {
            canvas.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Key pressed");
                canvas.SetActive(false);
                dialogueTrigger.TriggerDialogue();
            }
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
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        InRange = false;
    }
}

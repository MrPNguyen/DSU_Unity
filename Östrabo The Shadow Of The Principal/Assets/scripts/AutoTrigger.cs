using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTrigger : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;
    public float delayBeforeStart = 2f;

    // Start is called before the first frame update
    void Start()
    {
        if (dialogueTrigger != null) 
        {
            StartCoroutine(DelayedDialogue());
        }
        else
        {
            Debug.LogError("DialogueTrigger reference is not set in AutoTrigger,");
        }

        IEnumerator DelayedDialogue()
        {
            yield return new WaitForSeconds(delayBeforeStart);

            dialogueTrigger.TriggerDialogue();
        }
    }
}

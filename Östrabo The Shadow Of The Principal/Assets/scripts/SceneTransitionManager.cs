using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionManager : MonoBehaviour
{
    [SerializeField] Animator transition;

    public IEnumerator TransitionOut(Action onComplete)
    {
        transition.SetTrigger("end");
        yield return new WaitForSeconds(0.5f);
        onComplete();
    }

    public IEnumerator TransitionIn(Action onComplete)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        onComplete();
    
    }
}

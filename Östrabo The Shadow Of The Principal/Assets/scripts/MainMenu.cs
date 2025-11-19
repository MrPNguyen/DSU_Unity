using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transitionAnimator;
    public float transitionTime = 1f;
    SceneTransitionManager scenetransition;

    [Header("Sound")]
    [SerializeField] public AudioClip Buttonsound;
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = Buttonsound;
    }
    private void Awake()
    {
        scenetransition = FindObjectOfType<SceneTransitionManager>();
    }
    public void OnPlayButtonClicked()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        StartCoroutine(LoadGameWithTransition());
    }
    public void QuitGame()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        StartCoroutine(QuitGameWithTransition());
    }
    IEnumerator LoadGameWithTransition()
    {
        transitionAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("Prologue");
    }
    IEnumerator QuitGameWithTransition()
    {
        transitionAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        Application.Quit();
    }
}

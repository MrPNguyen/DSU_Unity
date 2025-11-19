using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class EscapeMenu : MonoBehaviour
{
    public Animator transitionAnimator;
    public float transitionTime = 1f;
    SceneTransitionManager scenetransition;

    [Header("Sound")]
    [SerializeField] public AudioClip Buttonsound;
    [SerializeField] private AudioSource audioSource;

    public GameObject pauseMenu;
    public GameObject optionsMenu;

    private bool isPaused = false;
    
    private void Start()
    {
        Debug.Log("Pause Menu initialized");
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = Buttonsound;
        pauseMenu.SetActive(false);
    }
    private void Update()
    {
        PostProcessVolume ppVolume = Camera.main.gameObject.GetComponent<PostProcessVolume>();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key detected");
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        var ppVolume = Camera.main.GetComponent<PostProcessVolume>();
        if (ppVolume != null) ppVolume.enabled = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        var ppVolume = Camera.main.GetComponent<PostProcessVolume>();
        if (ppVolume != null) ppVolume.enabled = false;
    }
    public void OptionsMenu()
    {
        optionsMenu.SetActive(true);
        isPaused = true;
    }
    public void GoBack()
    {
        optionsMenu.SetActive(false);
        isPaused = true;
    }
    private void Awake()
    {
        scenetransition = FindObjectOfType<SceneTransitionManager>();
    }
    public void GoBackToMainMenu()
    {
        pauseMenu.SetActive(false);
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        StartCoroutine(LoadGameWithTransition());
        Debug.Log("Going to Main Menu");
    }
    public void QuitGame()
    {
        pauseMenu.SetActive(false);
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        StartCoroutine(QuitGameWithTransition());
    }
    
    IEnumerator LoadGameWithTransition()
    {
        Time.timeScale = 1f;

        if(transitionAnimator != null)
        {
            transitionAnimator.SetTrigger("FadeIn");

            yield return new WaitForSeconds(transitionTime);
        }

        SceneManager.LoadScene(0);
        Debug.Log("Going to Main Menu");
    }
    IEnumerator QuitGameWithTransition()
    {
        Time.timeScale = 1f;
        if (transitionAnimator != null)
        {
            transitionAnimator.SetTrigger("FadeIn");

            yield return new WaitForSeconds(transitionTime);
        }

        Application.Quit();
    }
}

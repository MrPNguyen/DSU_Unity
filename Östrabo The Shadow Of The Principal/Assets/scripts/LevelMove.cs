using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] public AudioClip Doorsound;
    [SerializeField] private AudioSource audioSource;

    public Animator transitionAnimator;
    public float transitionTime = 1f;
    SceneTransitionManager scenetransition;

    [Header("Scene")]
    [SerializeField] public int SceneID;

    public GameObject Arrow;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = Doorsound;
    }
    private void Awake()
    {
        scenetransition = FindObjectOfType<SceneTransitionManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            Arrow.SetActive(true);
            if (!audioSource.isPlaying) 
            {
                audioSource.Play();
            }

            Invoke("LoadNextScene", audioSource.clip.length);
            StartCoroutine(LoadNextScene());
        }
    }
    IEnumerator LoadNextScene()
    {
        transitionAnimator.SetTrigger("FadeIn");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(SceneID);
    }
    
}

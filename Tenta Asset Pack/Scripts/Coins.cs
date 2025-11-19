using System;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private ScoreManager scoreManager;
    public AudioSource audioSource;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit");
            audioSource.Play();
            gameObject.SetActive(false);
            scoreManager.AddPoint();
        }
    }
}

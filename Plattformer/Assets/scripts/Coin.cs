using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private ScoreManager scoreManager;
    
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            scoreManager.AddPoint();
        }
    }
}

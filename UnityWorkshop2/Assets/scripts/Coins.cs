using System;
using UnityEngine;

public class Coins : MonoBehaviour
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
            Debug.Log("Hit");
            gameObject.SetActive(false);
            scoreManager.AddPoint();
        }
    }
}

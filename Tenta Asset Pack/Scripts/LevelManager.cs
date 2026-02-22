using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int LevelIndex;
    
    public void StartGame()
    {
        SceneManager.LoadScene(LevelIndex);
    }

    public void EndGame()
    {
        Environment.Exit(0);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit");
            SceneManager.LoadScene(LevelIndex);        
        }
    }
}

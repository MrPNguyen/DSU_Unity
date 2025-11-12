using System;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Exit()
    {
        Environment.Exit(1);
    }
}

using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;
    private float speed;
    
    private Animator animator;
    
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        UpdateScoreText();
        animator = GetComponent<Animator>();
    }

    public void AddPoint()
    {
        score++;
        UpdateScoreText();
        speed = animator.GetFloat("speed");
        if (speed > 1)
        {
            
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}

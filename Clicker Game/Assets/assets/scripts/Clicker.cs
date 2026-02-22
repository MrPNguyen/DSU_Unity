using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class Clicker : MonoBehaviour
{
    public float Score;
    public int gain;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject gainText;
    [SerializeField] private float duration;
    [SerializeField] private float riseAmount;

    private void Start()
    {
        gain = 1;
        Score = 200f;
    }

    private void Update()
    {
        scoreText.text = Mathf.FloorToInt(Score).ToString();
        if (Score < 0)
        {
            Score = 0;
        }
        Debug.Log(Score);
    }

    public void ScoreGain()
    {
        Score += gain;
        scoreText.text = Score.ToString();
        StartCoroutine(ScoreGainBehavoiurroutine());
    }

    private IEnumerator ScoreGainBehavoiurroutine()
    {
        GameObject text = Instantiate(gainText, transform);

        RectTransform rect = text.GetComponent<RectTransform>();
        Vector2 startpos = rect.anchoredPosition = new Vector2(
            Random.Range(-100f, 100f),
            0f
        );
        
        TMP_Text tmp = text.GetComponent<TMP_Text>();
        tmp.text = $"+{gain}";
        float startOpacity = tmp.alpha;

        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            tmp.alpha = Mathf.Lerp(startOpacity, 0f, time / duration);
            rect.anchoredPosition = startpos + new Vector2(0f, riseAmount * time);
            yield return null;
        }
        
        tmp.alpha = 0;
        Destroy(text.gameObject);
    }
}

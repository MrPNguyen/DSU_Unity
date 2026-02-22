using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Clicker clicker;
    private GameObject button;
    
    [Header("Values")]
    private int[] increasePrice;
    private int[] autoIncreasePrice;
    private int indexIncrease;
    private int indexAutoIncrease;
    [SerializeField] private float duration;
    

    private void Start()
    {
        indexIncrease = 0;
        indexAutoIncrease = 0;
        
        increasePrice = new int[4];
        increasePrice[0] = 10;
        increasePrice[1] = 40;
        increasePrice[2] = 100;
        increasePrice[3] = 200;

        autoIncreasePrice = new int[4];
        autoIncreasePrice[0] = 200;
        autoIncreasePrice[1] = 400;
        autoIncreasePrice[2] = 800;
        autoIncreasePrice[3] = 1000;
    }

    public void IncreaseGain()
    {
        if (clicker.Score > increasePrice[indexIncrease])
        {
            switch (indexIncrease)
            {
                case 0:
                    clicker.gain += 2;
                    break;
                case 1:
                    clicker.gain += 5;
                    break;
                case 2:
                    clicker.gain += 10;
                    break;
                case 3:
                    clicker.gain += 20;
                    break;
            }
        }
        else
        {
            StartCoroutine(InsufficientFundsRoutine());
        }
    }

    private IEnumerator InsufficientFundsRoutine()
    {
        Color buttoncolor = button.GetComponent<Image>().color = new Color(255,0,0,255);

        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            buttoncolor.g = Mathf.Lerp(buttoncolor.g, 255f, time / duration);
            buttoncolor.b = Mathf.Lerp(buttoncolor.b, 255f, time / duration);
            yield return null;
        }
        
        buttoncolor.g = 255;
        buttoncolor.b = 255;
    }
    /*
     Upgrade 1: gain goes + 2
     Upgrade 2: Automatic gain. bool "hasUnlocked" becomes true on the first unlock and each upgrade after
     reduces delay
     more currencies?
     */
}

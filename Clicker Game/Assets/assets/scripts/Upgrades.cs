using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Clicker clicker;
    
    [SerializeField] private GameObject btnIncreaseGain;
    [SerializeField] private TMP_Text increasePriceText;
    
    [SerializeField] private GameObject btnAutoGain;
    [SerializeField] private TMP_Text autoPriceText;

    
    [Header("Values")]
    private int[] increasePrice;
    private int[] autoIncreasePrice;
    private int indexIncrease;
    private int indexAutoIncrease;
    [SerializeField] private float duration;
    private bool autoUnlocked;


    private void Awake()
    {
        indexIncrease = 0;
        indexAutoIncrease = 0;
        
        increasePrice = new int[4];
        increasePrice[0] = 100;
        increasePrice[1] = 300;
        increasePrice[2] = 500;
        increasePrice[3] = 1000;

        autoIncreasePrice = new int[4];
        autoIncreasePrice[0] = 200;
        autoIncreasePrice[1] = 400;
        autoIncreasePrice[2] = 800;
        autoIncreasePrice[3] = 1000;
    }

    private void Start()
    {
        autoUnlocked = false;
        increasePriceText.text = $"{increasePrice[0]}$";
        autoPriceText.text = $"{autoIncreasePrice[0]}$";
    }

    private void Update()
    {
        switch (indexIncrease)
        {
            case 0:
                increasePriceText.text = $"{increasePrice[indexIncrease]}$";
                break;
            case 1:
                increasePriceText.text = $"{increasePrice[indexIncrease]}$";
                break;
            case 2:
                increasePriceText.text = $"{increasePrice[indexIncrease]}$";
                break;
            case 3:
                btnIncreaseGain.GetComponent<Button>().enabled = false;
                increasePriceText.text = $"Maxed Out";
                break;
        }

        if (autoUnlocked)
        {
            switch (indexAutoIncrease)
            {
                case 0:
                    clicker.Score += Time.deltaTime  * 0.2f;
                    autoPriceText.text = $"{autoIncreasePrice[indexAutoIncrease]}$";
                    break;
                case 1:
                    clicker.Score += Time.deltaTime * 0.1f;
                    autoPriceText.text = $"{autoIncreasePrice[indexAutoIncrease]}$";
                    break;
                case 2:
                    clicker.Score += Time.deltaTime;
                    autoPriceText.text = $"{autoIncreasePrice[indexAutoIncrease]}$";
                    break;
                case 3:
                    clicker.Score += Time.deltaTime * 2f;
                    btnAutoGain.GetComponent<Button>().enabled = false;
                    autoPriceText.text = $"Maxed Out";
                    break;
            }
        }
    }

    public void IncreaseGain()
    {
        if (clicker.Score >= increasePrice[indexIncrease])
        {
            switch (indexIncrease)
            {
                case 0:
                    clicker.gain += 2;
                    clicker.Score -= increasePrice[indexIncrease];
                    indexIncrease++;
                    break;
                case 1:
                    clicker.gain += 5;
                    clicker.Score -= increasePrice[indexIncrease];
                    indexIncrease++;
                    break;
                case 2:
                    clicker.gain += 10;
                    clicker.Score -= increasePrice[indexIncrease];
                    indexIncrease++;
                    break;
                case 3:
                    clicker.gain += 20;
                    clicker.Score -= increasePrice[indexIncrease];
                    break;
            }
        }
        else
        {
            StartCoroutine(InsufficientFundsRoutine(btnIncreaseGain.GetComponent<Image>()));
        }
    }

    public void AutoGain()
    {
        if (!autoUnlocked)
        {
            if (clicker.Score >= autoIncreasePrice[0])
            {
                clicker.Score -= autoIncreasePrice[0];
                autoUnlocked = true;
                indexAutoIncrease = 0;
            }
            else
            {
                StartCoroutine(InsufficientFundsRoutine(btnAutoGain.GetComponent<Image>()));
            }

            return;
        }
        
        if (clicker.Score >= autoIncreasePrice[indexAutoIncrease] && autoUnlocked)
        {
            switch (indexAutoIncrease)
            {
                case 0:
                    clicker.Score -= increasePrice[indexAutoIncrease];
                    indexAutoIncrease++;
                    break;
                case 1:
                    clicker.Score -= increasePrice[indexAutoIncrease];
                    indexAutoIncrease++;
                    break;
                case 2:
                    clicker.Score -= increasePrice[indexAutoIncrease];
                    indexAutoIncrease++;
                    break;
                case 3:
                    clicker.Score -= increasePrice[indexAutoIncrease];
                    break;
            }
        }
        else
        {
            StartCoroutine(InsufficientFundsRoutine(btnAutoGain.GetComponent<Image>()));
        }
    }

    private IEnumerator InsufficientFundsRoutine(Image buttoncolor)
    {
        Color startColor = Color.red;
        Color endColor = Color.white;

        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            buttoncolor.color = Color.Lerp(startColor, endColor, time / duration);
            yield return null;
        }
        
        buttoncolor.color = endColor;
    }
    /*
     Upgrade 1: gain goes + 2
     Upgrade 2: Automatic gain. bool "hasUnlocked" becomes true on the first unlock and each upgrade after
     reduces delay
     more currencies?
     */
}

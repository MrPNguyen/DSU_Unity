using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ActivateSkip : MonoBehaviour
{
    public GameObject BtnSkip;
    public float delay = 6f;
    // Start is called before the first frame update
    void Start()
    {
        if (BtnSkip != null)
        { 
            BtnSkip.SetActive(false);
        }

        StartCoroutine(ActivateButton());
    }

    IEnumerator ActivateButton()
    {
        yield return new WaitForSeconds(delay);

        BtnSkip.SetActive(true);

        Button BtnComponent = BtnSkip.GetComponent<Button>();
        if (BtnComponent != null)
        { 
            BtnComponent.interactable = true;
            BtnComponent.onClick.AddListener(BtnClicked);
        }
    }

    void BtnClicked()
    {
        SceneManager.LoadSceneAsync("Main_Game");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

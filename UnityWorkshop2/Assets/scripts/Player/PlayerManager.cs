using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int KeyCount;
    public Vector3 originalPosition;
    private int MaxHealth = 3;
    public int currentHealth;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;

    void Awake()
    {
        originalPosition = transform.position;
        currentHealth = MaxHealth;
    }

    public void Hit()
    {
        currentHealth--;
        if (currentHealth == 2)
        {
            Heart3.SetActive(false);
        }
        else if (currentHealth == 1)
        {
            Heart2.SetActive(false);
        }
        else if (currentHealth == 0)
        {
            Heart1.SetActive(false);
        }
        else
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
        }
    }
    public void KeyPickUp()
    {
        KeyCount++;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Player player;
    public Image[] currentHealthImages;
    public Sprite[] healthImages;

    public void UIHealthDecrease(int playerHealth)
    {
        Debug.Log("PlayerHealth = " + playerHealth);
        for (int i = currentHealthImages.Length - 1; i >= playerHealth; i--)
        {
            currentHealthImages[i].sprite = healthImages[1];

            //Debug.Log("Health Changed" + playerHealth);
        }
    }

    public void UIHealthIncrease(int playerHealth)
    {
        Debug.Log("PlayerHealth = " + playerHealth);
        for (int i = 0; i < playerHealth; i++)
        {
            currentHealthImages[i].sprite = healthImages[0];

            //Debug.Log("Health Changed" + playerHealth);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Image[] currentHealthImages;
    public Sprite[] healthImages;

    public void UIHealthDecrease(int playerHealth)
    {
        for (int i = currentHealthImages.Length - 1; i >= playerHealth; i--)
        {
            currentHealthImages[i].sprite = healthImages[1];

            //Debug.Log("Health Changed" + playerHealth);
        }
    }

    public void UIHealthIncrease(int playerHealth)
    {
        currentHealthImages[playerHealth - 1].sprite = healthImages[0];
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

}

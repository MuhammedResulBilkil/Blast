using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public AudioClip pickUpHealth;
    public int health = 4;

    private int playerHealth = 4;

    public float estimatedTime = 3f;
    private float time = 0f;

    public UIController uiController;

    private List<GameObject> heart = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Heart"))
        {
            if (playerHealth < health)
            {
                playerHealth++;
                AudioSource.PlayClipAtPoint(pickUpHealth, transform.position);
                uiController.UIHealthIncrease(playerHealth);
                //Destroy(collision.gameObject);
                heart.Add(collision.gameObject);
                collision.gameObject.SetActive(false);
            }
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            time += Time.deltaTime;
            if (time >= estimatedTime)
            {
                playerHealth--;
                Debug.Log("Player Health = " + playerHealth);
                uiController.UIHealthDecrease(playerHealth);
                time = 0f;
            }
        }

        if (playerHealth <= 0)
            PlayerDie();
    }

    private void OnEnable()
    {
        playerHealth = health;
        transform.position = Vector3.zero;
        //gameObject.SetActive(true);
        //Debug.Log("sklnorn");
        uiController.UIHealthIncrease(health);
        foreach (GameObject hearts in heart)
        {
            hearts.SetActive(true);
        }
        heart.Clear();
    }

    private void PlayerDie()
    {
        gameObject.SetActive(false);
        Debug.Log("Player is Dead!!!");
    }

}

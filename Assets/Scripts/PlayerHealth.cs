using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health = 4;

    private int playerHealth = 4;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            playerHealth--;
            Debug.Log("Player Health = " + playerHealth);
        }

        

        if (playerHealth <= 0)
            PlayerDie();
    }

    private void OnEnable()
    {
        playerHealth = health;
        transform.position = Vector3.zero;
        gameObject.SetActive(true);
    }

    private void PlayerDie()
    {
        gameObject.SetActive(false);
        Debug.Log("Player is Dead!!!");
    }

}

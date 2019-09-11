using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHealth : MonoBehaviour
{
    public AudioClip pickUpHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(pickUpHealth, transform.position);
            Destroy(gameObject);
        }
    }
}

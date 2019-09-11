using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public AudioClip powerSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //AudioSource powerSound = GetComponent<AudioSource>();
            //powerSound.Play();
            //gameObject.SetActive(false);
            AudioSource.PlayClipAtPoint(powerSound, transform.position);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject bullet = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(bullet, 5f);
        Destroy(transform.parent.gameObject, 5f);
        Destroy(gameObject);
    }

    private void Start()
    {
        Destroy(transform.parent.gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GameObject bullet = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(bullet, 5f);
            Destroy(transform.parent.gameObject, 5f);
            Destroy(gameObject);
        }
    }
}

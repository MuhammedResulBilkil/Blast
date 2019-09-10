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
}

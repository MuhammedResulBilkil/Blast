using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float bulletForce = 20f;
    public Transform firePoint;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    private void Shoot()
    {
        //Rigidbody2D rb = Instantiate(bulletPrefab, firePoint).GetComponent<Rigidbody2D>();
        GameObject bullet = Instantiate(bulletPrefab, firePoint);
        Rigidbody2D[] rb = bullet.GetComponentsInChildren<Rigidbody2D>();
        rb[0].AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        rb[1].AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

    }
}

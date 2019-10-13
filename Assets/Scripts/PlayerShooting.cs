using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float bulletForce = 20f;
    public Transform firePoint;
    public GameObject bulletPrefab;
    private AudioSource audioSource;
    public FloatingJoystick shootJoystick;
    public float estimatedTime = 0.5f;


    private float time = 0f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= estimatedTime)
        {
            if (Mathf.Abs(shootJoystick.Horizontal) > 0 || Math.Abs(shootJoystick.Vertical) > 0)
            {
                Shoot();
                LaserSoundPlay();
            }
            time = 0f;
        }

//#if UNITY_EDITOR
//        if (Input.GetMouseButtonDown(0))
//        {
//            Shoot();
//            LaserSoundPlay();
//        }
//#endif
    }

    private void LaserSoundPlay()
    {
        audioSource.Play();
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

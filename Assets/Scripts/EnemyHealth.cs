using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 5;
    public int scorePoint = 1;
    public AnimationClip deathAnim;


    EnemyMovement enemyMovement;
    Rigidbody2D rb2d;
    AudioSource deathSound;
    Collider2D collide2d;
    int enemyHealth = 0;

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        enemyMovement = GetComponent<EnemyMovement>();
        deathSound = GetComponent<AudioSource>();
        collide2d = GetComponent<Collider2D>();
        enemyHealth = health;
    }

    private void OnEnable()
    {
        enemyMovement.isDeath = false;
        health = enemyHealth;
        collide2d.enabled = true;
    }

    private void OnDisable()
    {
        enemyMovement.isDeath = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            ChangeHealth(-2);
        }
    }

    public void ChangeHealth(int damage)
    {
        health += damage;
        // iki mermi oldugundan dolayi isDeath kontrolu yapilir.
        if (health <= 0 && !enemyMovement.isDeath)
            EnemyDie();
    }

    private void EnemyDie()
    {
        rb2d.velocity = Vector2.zero;
        enemyMovement.isDeath = true;
        enemyMovement.anim.SetTrigger("Death");
        collide2d.enabled = false;
        deathSound.Play();

        GameController.Instance.Score(scorePoint);

        //Destroy(gameObject, deathAnim.length);

        StartCoroutine(EnemySpawnController.Instance.ReturnToPool(gameObject,deathAnim.length));

        ;
    }
}

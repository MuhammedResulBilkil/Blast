using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float timeMove = 3f;
    public float moveSpeed = 3f;
    [HideInInspector]
    public bool isDeath = false;
    [HideInInspector]
    public Animator anim;

    protected Rigidbody2D rb2d;
    protected float estimatedTime = 0f;

    // Start is called before the first frame update
    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate()
    {
        estimatedTime += Time.fixedDeltaTime;

        if(estimatedTime >= timeMove && !isDeath)
        {
            Move();
            estimatedTime = 0f;
        }
    }

    protected virtual void Move()
    {
        float posX = UnityEngine.Random.Range(-1f, 1f);
        float posY = UnityEngine.Random.Range(-1f, 1f);

        Vector2 movement = new Vector2(posX, posY);

        Vector2 lookDir = movement - rb2d.position;
        lookDir.Normalize();

        rb2d.velocity = lookDir * moveSpeed;

       // anim.SetFloat("Speed", rb2d.velocity.magnitude);

        //Debug.Log("Enemy Velocity = " + rb2d.velocity);
        //Debug.Log("Enemy Velocity's Magnitude = " + rb2d.velocity.magnitude);
    }
}

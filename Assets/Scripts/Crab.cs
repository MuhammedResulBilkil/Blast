using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : EnemyMovement
{
    protected override void Move()
    {
        base.Move();

        anim.SetFloat("Speed", rb2d.velocity.sqrMagnitude);
    }
}

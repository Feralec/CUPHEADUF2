using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammerProjectileController : EnemyBulletController
{
    public hammerModel hammerModel; //mira yo que sé

    private float vSpeed;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        flipOrNot = -1;
        rb.AddForce(hammerModel.verticalImpulse * Vector2.up, ForceMode2D.Impulse);
        base.Start();
    }
}

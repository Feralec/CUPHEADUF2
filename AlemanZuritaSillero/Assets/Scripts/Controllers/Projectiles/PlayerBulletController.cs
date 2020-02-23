using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : GenericBulletController
{

    private void Start()
    {
        if (GetComponent<SpriteRenderer>().flipX)
            flipOrNot = -1;//así se mueve hacia la izquierda
        else
            flipOrNot = 1;
        base.Start();
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Enemy"||collision.tag=="Boss")
        {
            collision.gameObject.GetComponent<EnemyController>().remainingHealth -= datamodel.damage;
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : GenericBulletController
{
    protected void Start()
    {
        flipOrNot = -1;
        base.Start();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.GInstance.playerHealth -= datamodel.damage;
            AudioManager.instance.PlaySound("HitMarker");
            Destroy(gameObject);
        }
    }
}

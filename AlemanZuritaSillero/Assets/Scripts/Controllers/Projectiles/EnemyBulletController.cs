using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : GenericBulletController
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.GInstance.playerHealth -= datamodel.damage;
            Destroy(gameObject);
        }
    }
}

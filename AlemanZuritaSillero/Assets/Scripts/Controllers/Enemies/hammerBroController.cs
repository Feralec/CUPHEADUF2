using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammerBroController : EnemyController
{
    public hammerBroModel datamodel;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        remainingHealth = datamodel.health;
    }

    void Update()
    {
        if (remainingHealth <= 0)
        {
            GameManager.GInstance.killedEnemies++;
            Destroy(gameObject);
        }
    }
}

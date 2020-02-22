using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursedEmojiController : EnemyController
{
    public CursedEmojiModel datamodel;

    private bool isAttacking;
    private Transform playerTransform;
    private float sqrRadius;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        sqrRadius = datamodel.perceptionRadius * datamodel.perceptionRadius;
        remainingHealth = datamodel.health;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toPlayer = (playerTransform.position - transform.position);
        if (toPlayer.sqrMagnitude<=sqrRadius)
        {
            transform.LookAt(transform.position+Vector3.forward,-toPlayer);
            isAttacking = true;
        } else
        {
            isAttacking=false;
        }
        anim.SetBool("isAttacking", isAttacking);
        if (remainingHealth <= 0)
        {
            GameManager.GInstance.killedEnemies++;
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        if (isAttacking)
        {
            transform.Translate(Vector3.down*Time.deltaTime*datamodel.horizontalSpeed);
        } else { //hago esto para que no se vaya volando al dejar de moverse
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, datamodel.perceptionRadius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            GameManager.GInstance.playerHealth -= datamodel.damage;
            Destroy(gameObject);
        }
    }
}

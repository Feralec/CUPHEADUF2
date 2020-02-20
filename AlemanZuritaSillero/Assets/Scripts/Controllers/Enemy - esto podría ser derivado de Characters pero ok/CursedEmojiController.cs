﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursedEmojiController : Enemy
{
    [Range(0f, 10f)] public float speed = 2f;
    public float perceptionRadius = 3f;
<<<<<<< HEAD
    public int damage = 15;
=======
    public int damage= 50;
>>>>>>> 647038679eb29794facbfd3fdd776379cbfc7139

    private Animator anim;
    private bool isAttacking;
    private Rigidbody2D rb;
    private Transform playerTransform;
    private float sqrRadius;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        sqrRadius = perceptionRadius * perceptionRadius;
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
    }

    void FixedUpdate()
    {
        if (isAttacking)
        {
            transform.Translate(Vector3.down*Time.deltaTime*speed);
        } else { //hago esto para que no se vaya volando al dejar de moverse
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, perceptionRadius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            GameManager.GInstance.playerHealth -= damage;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}

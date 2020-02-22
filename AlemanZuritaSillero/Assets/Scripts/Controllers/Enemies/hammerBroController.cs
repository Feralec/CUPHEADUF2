using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammerBroController : EnemyController
{
    public hammerBroModel datamodel;
    public GameObject hammer;
    public Transform hammerSpawn;

    private float i;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        remainingHealth = datamodel.health;
        i = 0;
    }

    void Update()
    {
        //esto controla que se muera
        if (remainingHealth <= 0)
        {
            GameManager.GInstance.killedEnemies++;
            Destroy(gameObject);
        }

        //con esto hago un "loop" para que tire martillos cada cierto tiempo
        i += Time.deltaTime;
        if (i>=datamodel.timeBetweenHammerThrows)
        {
            i = 0;
            anim.SetTrigger("throwingTrigger");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Bullet")
        {
            i = 0; //reinicia el loop de tirar martillos
            anim.SetBool("isHurt", true);
            StartCoroutine(ImHurt());
        }
    }

    IEnumerator ImHurt()
    {
        yield return new WaitForSeconds(datamodel.invincibilityTimeAfterBeingHurt);
        anim.SetBool("isHurt", false);
    }

    public void ThrowHammer()
    {
        GameObject newHammer = Instantiate(hammer,hammerSpawn.position,Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : EnemyController
{
    public BossModel datamodel;
    public GameObject FireBall;
    public GameObject Enemies;
    public Transform fireballSpawn;
    public Transform enemies;

    private float i,flametimer;

    void Start()
    {
        remainingHealth = datamodel.health;
        i = 0;
        flametimer = datamodel.timeBetweenFire;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingHealth<=0)
        {
            i = 0; //por si acaso
            anim.SetTrigger("bossDeath");
        }

        //con esto hago un "loop" para que tire bolas de fuego
        i += Time.deltaTime;
        if (i >= flametimer)
        {
            i = 0;
            anim.SetTrigger("fireBlast");
        }
    }
    public void theGameIsOver()
    {
        GameManager.GInstance.quitCanvas();
        SceneManager.LoadScene("WinScene");
    }
    public void FlameBlast()
    {
        GameObject hadouken = Instantiate(FireBall,fireballSpawn.position, Quaternion.identity);
        GameObject spawnLittleEnemies = Instantiate(Enemies, enemies.position, Quaternion.identity);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : GenericBulletController
{
    private float flipOrNot;
    private void Start()
    {
        if (GetComponent<SpriteRenderer>().flipX)
            flipOrNot = -1;//así se mueve hacia la izquierda
        else
            flipOrNot = 1; 
        base.Start();
    }
    //yo
    private void Update()
    {

        base.Update();

        //print("prueba"); //ok funciona
    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(Time.deltaTime * speed*flipOrNot, 0, 0);
    }
}

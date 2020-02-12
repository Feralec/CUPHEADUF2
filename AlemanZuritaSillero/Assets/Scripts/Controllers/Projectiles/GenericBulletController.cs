using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//esta es una clase que controla TODOS LSO BULLETS, es decir, los que se usan DERIVAN DE ESTA, nunca se usa esta directamente
public class GenericBulletController : MonoBehaviour
{
    public Bullet datamodel;
    [HideInInspector] public float speed; //este lo hago público para modificarlo porque ESTA ES LA MEJOR FORMA DE HACERLO QUE TENGO AAAAAAAADSHFDSHFO
    protected float maxTime, dmg;

    protected void Start()
    {
        speed = datamodel.horizontalSpeed;
        maxTime = datamodel.maxTimeOnScreen;
        dmg = datamodel.damage;
    }
    protected void Update()
    {
        Destroy(this.gameObject, maxTime);
    }
}


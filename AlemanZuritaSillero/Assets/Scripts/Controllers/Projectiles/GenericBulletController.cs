using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//esta es una clase que controla TODOS LSO BULLETS, es decir, los que se usan DERIVAN DE ESTA, nunca se usa esta directamente
public class GenericBulletController : MonoBehaviour
{
    public BulletModel datamodel;
    [HideInInspector] public float hSpeed; //este lo hago público para modificarlo porque ESTA ES LA MEJOR FORMA DE HACERLO QUE TENGO AAAAAAAADSHFDSHFO

    protected float maxTime, flipOrNot;

    protected void Start()
    {
        hSpeed = datamodel.horizontalSpeed;
        maxTime = datamodel.maxTimeOnScreen;
    }

    protected void FixedUpdate()
    {
        transform.position += new Vector3(Time.deltaTime * hSpeed * flipOrNot, 0, 0);
    }

    protected void Update()
    {
        Destroy(this.gameObject, maxTime);
    }
}


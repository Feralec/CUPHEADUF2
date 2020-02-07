using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMovement : MonoBehaviour
{
    //private Rigidbody2D rig2;
    private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        //rig2 = GetComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;

        Destroy(gameObject, 2f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlat : MonoBehaviour
{
    private Vector3 posA, posB;
    private Vector3 nextPos;
    [SerializeField] private Transform childTransform, transformB;


    [Range(1f, 10f)] public float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        posA = childTransform.localPosition;
        posB = transformB.localPosition;
        nextPos = posB;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextPos, speed * Time.deltaTime);
        
        if(Vector3.Distance(childTransform.localPosition, nextPos) <= 0.1)
        {
            ChangePos();
        }
    }

    private void ChangePos()
    {
        nextPos = nextPos != posA ? posA : posB;
    }
}

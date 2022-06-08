using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacleController : MonoBehaviour
{
    Rigidbody rb { get { return GetComponent<Rigidbody>(); } }

    public float speed = 10f;

    public Transform pos1;
    public Transform pos2;

    private Vector3 destination;

    void Awake()
    {
        destination = pos1.position;
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, pos1.position) <= 0.2)
        {
            destination = pos2.position;
        }

        else if (Vector3.Distance(transform.position, pos2.position) <= 0.2)
        {
            destination = pos1.position;
        }

        var target = (destination - transform.position).normalized;
        rb.MovePosition(transform.position + target * speed * Time.fixedDeltaTime);
    }
}

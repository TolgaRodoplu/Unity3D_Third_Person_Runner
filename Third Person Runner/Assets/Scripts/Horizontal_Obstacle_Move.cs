using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horizontal_Obstacle_Move : MonoBehaviour
{
    Rigidbody rb { get { return GetComponent<Rigidbody>(); } }

    public float speed = 10f;

    public Transform pos_1;
    public Transform pos_2;

    private Vector3 destination;

    void Awake()
    {
        destination = pos_1.position;
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, pos_1.position) <= 0.2)
        {
            destination = pos_2.position;
        }

        else if (Vector3.Distance(transform.position, pos_2.position) <= 0.2)
        {
            destination = pos_1.position;
        }

        var target = (destination - transform.position).normalized;
        rb.MovePosition(transform.position + target * speed * Time.fixedDeltaTime);
    }
}

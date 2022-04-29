using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horizontal_Obstacle_Move : MonoBehaviour
{
    Rigidbody rb { get { return GetComponent<Rigidbody>(); } }

    float speed = 5f;

    public Transform pos_1;
    public Transform pos_2;

    private Vector3 destination;

    void Awake()
    {
        destination = pos_1.position;
    }

    void FixedUpdate()
    {
        var current_pos = transform.position;

        if (Vector3.Distance(current_pos, pos_1.position) <= 0.2)
        {
            destination = pos_2.position;
        }
        else if (Vector3.Distance(current_pos, pos_2.position) <= 0.2)
        {
            destination = pos_1.position;
        }

        var target = (destination - current_pos).normalized;
        rb.MovePosition(current_pos + target * speed * Time.fixedDeltaTime);
    }
}

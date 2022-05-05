using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character_Controller : MonoBehaviour
{
    protected Rigidbody rb { get { return GetComponent<Rigidbody>(); } }
    protected float forward_force_scale = 70f;
    protected float right_force_scale = 70f;
    protected float clamp_value = 10f;
    protected float input;
    protected Vector3 respawn_pos { get { return new Vector3(Random.Range(-9, 9), 0f, 13f); } }
    

    // Update is called once per frame
    protected void Move()
    {
        var right = transform.right * input * right_force_scale;
        var forward = transform.forward * forward_force_scale;

        rb.AddForce(right + forward);

        var x = Mathf.Clamp(rb.velocity.x, -clamp_value, clamp_value);
        var z = Mathf.Clamp(rb.velocity.z, -clamp_value, clamp_value);
        var y = rb.velocity.y;
        rb.velocity = new Vector3(x, y, z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    Rigidbody rb { get { return GetComponent<Rigidbody>(); } }
    float forward_force_scale = 70f;
    float right_force_scale = 70f;
    float clamp_value = 15f;

    float input;

    void Update()
    {
        input = Input.GetAxis("Horizontal");
        Debug.Log(rb.velocity);
        
    }


    void FixedUpdate()
    {
        var right = transform.right * input * right_force_scale;
        var forward = transform.forward * forward_force_scale;
        rb.AddForce(right + forward);

        var x = Mathf.Clamp(rb.velocity.x, -clamp_value, clamp_value);
        var z = Mathf.Clamp(rb.velocity.z, -clamp_value, clamp_value);
        var y = rb.velocity.y;
        rb.velocity = new Vector3(x, y, z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("obstacle"))
            rb.AddForce(collision.GetContact(0).normal * 35f, ForceMode.VelocityChange);
    }

}

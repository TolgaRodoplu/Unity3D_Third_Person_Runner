using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : Character_Controller
{
    void Update()
    {
        input = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        var right = transform.right * input * right_force_scale;
        var forward = transform.forward * forward_force_scale;
        Move(right, forward);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("obstacle") || collision.gameObject.tag.Equals("character"))
            rb.AddForce(collision.GetContact(0).normal * 35f, ForceMode.VelocityChange);

        if (collision.gameObject.tag.Equals("water"))
            transform.position = respawn_pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Finish_Line"))
            gameObject.GetComponent<Transition>().enabled = true;
    }
}

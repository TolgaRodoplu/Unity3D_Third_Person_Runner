using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    Rigidbody rb { get { return GetComponent<Rigidbody>(); } }
    float forward_speed = 20f;
    float horizontal_speed = 10f;

    Vector3 destination;

    void Update()
    {
        destination.x = Input.GetAxis("Horizontal") * forward_speed;
        destination.z = Input.GetAxis("Vertical") * horizontal_speed;
        Debug.Log(rb.velocity);
    }


    void FixedUpdate()
    {
        destination = rb.position + destination * Time.fixedDeltaTime;

        rb.MovePosition(destination);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("obstacle"))
            rb.AddForce(collision.GetContact(0).normal * 100f, ForceMode.Impulse);
    }

}

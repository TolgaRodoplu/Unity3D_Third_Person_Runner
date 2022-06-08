using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{
    float swerve_scale = 1f;
    Vector3 mouse_start = Vector3.zero;
    Vector3 mouse_end = Vector3.zero;

    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouse_start = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }

        else if (Input.GetMouseButton(0))
        {
            mouse_end = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            input = (mouse_end.x - mouse_start.x) * 200f;
            mouse_start = mouse_end;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            input = 0f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Add force if player bumps to obstacles or other players
        if (collision.gameObject.tag.Equals("obstacle") || collision.gameObject.tag.Equals("character"))
            rb.AddForce(collision.GetContact(0).normal * 35f, ForceMode.VelocityChange);

        //respawn player if touched the water
        if (collision.gameObject.tag.Equals("water"))
            transform.position = respawnPos;
    }
}

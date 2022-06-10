using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : CharacterController
{
    public Transform rayOrigin;
    private float senseDistance = 15f;
    private float mapBorder = 9f;

    private void Update()
    {
        if(isRunning)
            Avoid();
    }

    private void Avoid()
    {
        //Define a ray in the direction of forward
        Ray ray_forward = new Ray(rayOrigin.position, transform.forward);
        RaycastHit hit;

        //Check if the Ray hit an object and the object that it hit is an obstacle if not try to stay in the middle
        if ((Physics.Raycast(ray_forward, out hit)) && (hit.collider.tag.Equals("obstacle")))
        {
            //Check if the object is close enough to react if not do not react
            if ((Vector3.Distance(hit.point, transform.position) < senseDistance))
            {

                //Check if the character is too close to the edge of the arena if it is dodge to the opposite side
                if (transform.position.x >= mapBorder)
                {
                    input = -1f;
                }

                else if (transform.position.x <= -mapBorder)
                {
                    input = 1f;
                }

                else
                {

                    //Check if the obstacle is a rotator all the rotators turns the same way so dodge accordingly (this can be bound to the rotation speed to determine which side the obstacle rotating towards)
                    if (hit.transform.name.Contains("RotatingStick") || hit.transform.name.Contains("Rotator"))
                    {
                        input = -1f;
                    }
                    else
                    {
                        //Check if the player is left or right of the obstale and dodge to the direction you are closer
                        if ((hit.point.x < hit.collider.transform.position.x))
                        {
                            input = -1f;
                        }

                        else if ((hit.point.x >= hit.collider.transform.position.x))
                        {
                            input = 1f;
                        }

                    }

                }

            }

            else
                input = 0;

        }

        else
        {
            if (transform.position.x > 0)
                input = -1f;

            else
                input = 1f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Respawn character if collided with obstacle or water
        if (collision.gameObject.tag.Equals("obstacle") || collision.gameObject.tag.Equals("water"))
            transform.position = respawnPos;

        //Add force if character bumps to other players
        if (collision.gameObject.tag.Equals("character"))
            rb.AddForce(collision.GetContact(0).normal * 35f, ForceMode.VelocityChange);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("FinishLine"))
        {
            StopRunning();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent_Controller : Character_Controller
{
    public Transform ray_origin;
    float sense_distance = 9f;
    float map_border = 9f;

    private void Start()
    {
        //Start the running animation when script activated
        GetComponent<Animator>().SetBool("isRunning", true);
    }

    private void FixedUpdate()
    {

        Avoid();
        Move();

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Respawn character if collided with obstacle or water
        if (collision.gameObject.tag.Equals("obstacle") || collision.gameObject.tag.Equals("water"))
            transform.position = respawn_pos;

        //Add force if character bumps to other players
        if (collision.gameObject.tag.Equals("character"))
            rb.AddForce(collision.GetContact(0).normal * 35f, ForceMode.VelocityChange);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Deactivate the character if finish line is touched
        if (other.name.Equals("Finish_Line"))
            gameObject.SetActive(false);

    }
    void Avoid()
    {
        //Define a ray in the direction of forward
        Ray ray = new Ray(ray_origin.position, transform.forward);
        RaycastHit hit;


        //Check if the Ray hit an object and the object that it hit is an obstacle if not try to stay in the middle
        if ((Physics.Raycast(ray, out hit)) && (hit.collider.tag.Equals("obstacle")))
        {
            //Check if the object is close enough to react if not do not react
            if ((Vector3.Distance(hit.point, transform.position) < sense_distance))
            {
                //Check if the player is left or right of the obstale and dodge to the direction you are closer
                if ((hit.point.x < hit.collider.transform.position.x))
                {
                    input = -1f;
                }

                else
                {
                    input = 1f;
                }

                //Check if the character is too close to the edge of the arena if it is dodge to the opposite side
                if (transform.position.x >= map_border)
                {
                    input = -1f;
                }

                else if (transform.position.x <= -map_border)
                {
                    input = 1f;
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

}

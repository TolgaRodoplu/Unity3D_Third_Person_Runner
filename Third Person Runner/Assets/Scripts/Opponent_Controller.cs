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
        GetComponent<Animator>().SetBool("isRunning", true);
    }

    private void FixedUpdate()
    {
        Ray ray = new Ray(ray_origin.position, transform.forward);
        RaycastHit hit;

        

        if((Physics.Raycast(ray, out hit)) && (hit.collider.tag.Equals("obstacle")))
        {

            if((Vector3.Distance(hit.point, transform.position) < sense_distance))
            {

                if ((hit.point.x < hit.collider.transform.position.x))
                {
                    input = -1f;
                }

                else
                {
                    input = 1f;
                }

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

        Move();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("obstacle") || collision.gameObject.tag.Equals("water"))
            transform.position = respawn_pos;

        if (collision.gameObject.tag.Equals("character"))
            rb.AddForce(collision.GetContact(0).normal * 35f, ForceMode.VelocityChange);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.name.Equals("Finish_Line"))
            gameObject.SetActive(false);

    }


}

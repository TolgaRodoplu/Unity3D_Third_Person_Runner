using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : Character_Controller
{
    private void Start()
    {
        //Start the running animation when script activated
        GetComponent<Animator>().SetBool("isRunning", true);

        //Get the characters array
        Transform[] characters = FindObjectOfType<Game_Maneger>().characters;

        //Activate the controller script of the opponents
        for (int i = 1; i < characters.Length; i++)
        {
            characters[i].GetComponent<Opponent_Controller>().enabled = true;
        }
    }
    

    void Update()
    {
        FindObjectOfType<Game_Maneger>().Update_Rank();

        //Get the player input
        input = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        //Move the player
        Move();
    }

    


    private void OnCollisionEnter(Collision collision)
    {
        //Add force if player bumps to obstacles or other players
        if (collision.gameObject.tag.Equals("obstacle") || collision.gameObject.tag.Equals("character"))
            rb.AddForce(collision.GetContact(0).normal * 35f, ForceMode.VelocityChange);

        //respawn player if touched the water
        if (collision.gameObject.tag.Equals("water"))
            transform.position = respawn_pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Enable the transition to painting on colliding with finish line
        if (other.name.Equals("Finish_Line"))
            gameObject.GetComponent<Transition>().enabled = true;
    }

}

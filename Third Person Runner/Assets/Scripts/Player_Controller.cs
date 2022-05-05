using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : Character_Controller
{
    

    private void Start()
    {
        GetComponent<Animator>().SetBool("isRunning", true);

        Transform[] characters = FindObjectOfType<Game_Maneger>().characters;

        for (int i = 1; i < characters.Length; i++)
        {
            characters[i].GetComponent<Opponent_Controller>().enabled = true;
        }
    }

    void Update()
    {
        FindObjectOfType<Game_Maneger>().Update_Rank();
        input = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        Move();
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

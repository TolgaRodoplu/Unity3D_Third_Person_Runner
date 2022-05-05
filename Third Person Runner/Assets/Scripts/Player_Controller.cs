using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : Character_Controller
{
    public Transform[] characters = new Transform[11];
    int player_index = 0;
    public Animator anim_controller;

    private void Start()
    {
        GetComponent<Animator>().SetBool("isRunning", true);

        for (int i = 1; i < characters.Length; i++)
        {
            characters[i].GetComponent<Opponent_Controller>().enabled = true;
        }
    }

    void Update()
    {
       
        Bubble_Sort();
        GetComponent<Game_Maneger>().Update_Rank(player_index + 1);
        
        input = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        Move();
    }

    void Bubble_Sort()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            for (int j = 0; j < characters.Length; j++)
            {

                if (characters[i].position.z > characters[j].position.z)
                {
                    if (j == player_index)
                        player_index = i;

                    else if (i == player_index)
                        player_index = j;

                    Transform temp = characters[i];
                    characters[i] = characters[j];
                    characters[j] = temp;
                }

            }
        }
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

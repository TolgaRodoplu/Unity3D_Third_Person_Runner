using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    Rigidbody rb { get { return GetComponent<Rigidbody>(); } }
    float forward_speed = 5f;
    float horizontal_speed = 0.5f;
    Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        var axis = Input.GetAxis("Horizontal");
        var horizontal_vect = transform.right * horizontal_speed * axis;
        var vertical_vect = transform.forward * forward_speed;
        move = transform.position + (horizontal_vect + vertical_vect * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(move);    
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Rotate : MonoBehaviour
{
    
    Rigidbody rb { get { return GetComponent<Rigidbody>(); } }
    public float rotation_speed = 100;
    Quaternion rotate;

    // Start is called before the first frame update
    void Start()
    {
        rotate = Quaternion.Euler(Vector3.up * rotation_speed * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        rb.MoveRotation(rb.rotation * rotate);
    }
}

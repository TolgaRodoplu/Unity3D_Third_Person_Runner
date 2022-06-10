using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{
    protected Rigidbody rb { get { return GetComponent<Rigidbody>(); } }
    protected float forwardForceScale = 70f;
    protected float rightForceScale = 70f;
    protected float clampValue = 10f;
    protected float input;
    protected Vector3 respawnPos { get { return new Vector3(Random.Range(-9, 9), 0f, 13f); } }
    protected bool isRunning = false;

    private void Start() 
    {
        //Register to the appropriate event
        EventSystem.instance.runningStarted += StartRunning;
        EventSystem.instance.runningStopped += StopRunning;
    }

    private void FixedUpdate()
    {
        if(isRunning)
            Move();
    }

    protected void Move()
    {
        //Set the x and z vectors of the movement force
        var right = transform.right * input * rightForceScale;
        var forward = transform.forward * forwardForceScale;

        //Apply The force to the character
        rb.AddForce(right + forward);

        //Clamp the velocity
        var x = Mathf.Clamp(rb.velocity.x, -clampValue, clampValue);
        var z = Mathf.Clamp(rb.velocity.z, -clampValue, clampValue);
        var y = rb.velocity.y;
        rb.velocity = new Vector3(x, y, z);
    }

    protected void StartRunning()
    {
        //Start the running animation when script activated
        GetComponent<Animator>().SetBool("isRunning", true);

        isRunning = true;
    }

    protected void StopRunning()
    {
        EventSystem.instance.runningStarted -= StartRunning;
        EventSystem.instance.runningStopped -= StopRunning;
        gameObject.SetActive(false);
    }
}

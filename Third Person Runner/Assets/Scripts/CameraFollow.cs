using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform camTransform { get { return Camera.main.transform; } }
    public Vector3 offset;
    private bool isFollowing = false;

    private void Start()
    {
        EventSystem.instance.runningStarted += StartFollow;
        EventSystem.instance.runningStopped += StopFollow;
        //Set the camera position at the start
        offset = camTransform.position - transform.position;
    }

    private void StartFollow()
    {
        isFollowing = true;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        //Follow the player
        if (isFollowing)
            camTransform.position = transform.position + offset;
    }
    private void StopFollow()
    {
        isFollowing = false;
        EventSystem.instance.runningStarted -= StartFollow;
        EventSystem.instance.runningStopped -= StopFollow;
        this.enabled = false;
    }
}

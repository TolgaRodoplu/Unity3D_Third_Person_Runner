using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Camera cam { get { return Camera.main; } }
    public Vector3 offset = new Vector3(0f, 9f, -10f);

    private void Start()
    {
        EventSystem.instance.runningStopped += StopFollow;
        //Set the camera position at the start
        cam.transform.rotation = Quaternion.Euler(new Vector3(27f, 0f, 0f));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Follow the player
        cam.transform.position = transform.position + offset;
    }

    private void StopFollow()
    {
        EventSystem.instance.runningStopped -= StopFollow;
        this.enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform player_transform;
    Vector3 offset = new Vector3(0f, 9f, -10f);

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player_transform.position + offset;
    }
}

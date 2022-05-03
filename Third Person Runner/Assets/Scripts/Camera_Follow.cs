using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    Camera cam { get { return Camera.main; } }
    Vector3 offset = new Vector3(0f, 9f, -10f);

    private void Awake()
    {
        cam.transform.rotation = Quaternion.Euler(new Vector3(27f, 0f, 0f));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        cam.transform.position = transform.position + offset;
    }
}

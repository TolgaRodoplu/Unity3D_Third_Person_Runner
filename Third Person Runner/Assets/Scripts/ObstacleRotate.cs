using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotate : MonoBehaviour
{
    Rigidbody rb { get { return GetComponent<Rigidbody>(); } }
    public float rotationSpeed = 100;
    Quaternion rotate;

    // Start is called before the first frame update
    void Start()
    {
        rotate = Quaternion.Euler(Vector3.up * rotationSpeed * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MoveRotation(rb.rotation * rotate);
    }
}

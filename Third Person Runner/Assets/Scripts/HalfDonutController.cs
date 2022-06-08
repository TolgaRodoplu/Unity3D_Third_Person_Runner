using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDonutController : MonoBehaviour
{
    Rigidbody rb { get { return GetComponent<Rigidbody>(); } }

    float speed;

    float push_speed = 10f;
    float retract_speed = 2f;

    public int interval = 2;

    public Transform pos_1;
    public Transform pos_2;

    bool isMoving = true;

    private Vector3 destination;

    void Awake()
    {
        transform.position = pos_1.position;
    }

    void FixedUpdate()
    {

        if (Vector3.Distance(transform.position, pos_1.position) <= 0.2)
        {
            destination = pos_2.position;
            speed = push_speed;

            StartCoroutine(Count());
        }

        else if (Vector3.Distance(transform.position, pos_2.position) <= 0.2)
        {
            speed = retract_speed;
            destination = pos_1.position;
        }

        if (isMoving)
        {
            var target = (destination - transform.position).normalized;
            rb.MovePosition(transform.position + target * speed * Time.fixedDeltaTime);
        }
    }
        

    IEnumerator Count()
    {
        isMoving = false;

        yield return new WaitForSeconds(interval);

        isMoving = true;

        var target = (destination - transform.position).normalized;
        rb.MovePosition(transform.position + target * speed * Time.fixedDeltaTime); 
    }

}

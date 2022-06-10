using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    Vector3 spawn_point;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>().SetBool("isRunning", true);
        spawn_point = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-transform.right * 10 * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag.Equals("Respawn"))
            transform.position = spawn_point;
    }
}

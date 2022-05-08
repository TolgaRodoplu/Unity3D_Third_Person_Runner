using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    Camera cam { get { return Camera.main; } }
    public Transform end_pos;
    
    // Start is called before the first frame update
    private void OnEnable()
    {
        gameObject.GetComponent<Player_Controller>().enabled = false;
        gameObject.GetComponent<Camera_Follow>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(cam.transform.position, end_pos.position) < 2)
            this.enabled = false;

        cam.transform.position = Vector3.Lerp(cam.transform.position, end_pos.position, Time.deltaTime);
        cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, end_pos.rotation, Time.deltaTime);

    }

    private void OnDisable()
    {
        gameObject.GetComponent<Game_Maneger>().Update_Percent(0);
        FindObjectOfType<Paint>().enabled = true;
    }
}

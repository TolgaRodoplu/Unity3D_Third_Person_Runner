using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Paint : MonoBehaviour
{
    Camera cam { get { return Camera.main; } }
    public Material red_paint;
    float painted = 0f;
    public GameObject end_canvas;

    // Update is called once per frame
    void Update()
    {
        //If mouse button is pressed paint the wall
        if (Input.GetMouseButton(0))
            Paint_Object();

    }

    void Paint_Object()
    {
        //Define a ray from the camera
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //If the ray hit and the object is pixel and it is not already painted
        if((Physics.Raycast(ray, out hit)) && (hit.collider.tag.Equals("pixel")) && !(hit.collider.gameObject.GetComponent<MeshRenderer>().material.name.Equals("red_paint (Instance)")))
        {
            //Change the hit objects material to red paint
            hit.transform.GetComponent<MeshRenderer>().material = red_paint;

            //increment the painted square count
            painted += 1f;

            //Get the percentage of the painted portion
            var painted_percent = ((painted / 260) * 100);

            //Update the percent in UI
            FindObjectOfType<Game_Maneger>().Update_Percent((int)painted_percent);

            //If all of the canvas is painted activate the end screen
            if (painted_percent == 100)
            {
                end_canvas.SetActive(true);
            }
        }
    }
}

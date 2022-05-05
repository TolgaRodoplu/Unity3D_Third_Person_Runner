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

        if (Input.GetMouseButton(0))
            Paint_Object();

    }

    void Paint_Object()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if((Physics.Raycast(ray, out hit)) && (hit.collider.tag.Equals("pixel")) && !(hit.collider.gameObject.GetComponent<MeshRenderer>().material.name.Equals("red_paint (Instance)")))
        {
            hit.transform.GetComponent<MeshRenderer>().material = red_paint;
            painted += 1f;
            var painted_percent = ((painted / 260) * 100);
            gameObject.GetComponent<Game_Maneger>().Update_Percent((int)painted_percent);

            if (painted_percent == 100)
            {
                end_canvas.SetActive(true);
            }
        }
    }
}

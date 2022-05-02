using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour
{
    Camera cam { get { return Camera.main; } }
    public GameObject brush_prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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


        if((Physics.Raycast(ray, out hit)) && (hit.collider.tag.Equals("painting_wall")))
        {
            Instantiate(brush_prefab, hit.point, Quaternion.Euler(-90f, 0f, 0f));
        }
    }
}

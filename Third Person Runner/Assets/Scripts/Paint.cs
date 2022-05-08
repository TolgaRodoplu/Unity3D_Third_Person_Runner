using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Paint : MonoBehaviour
{
    Vector3 input;
    bool isMoving = false;
    float speed = 40f;
    Transform target;
    Vector3 mouse_start = Vector3.zero;
    Vector3 mouse_end = Vector3.zero;
    int col = 5;
    int row = 8;
    public Transform[,] canvas;
    int brush_col = 0;
    int brush_row = 0;
    float painted = 0f;
    float total;
    public Material Paint_Mat;


    private void Start()
    {
        canvas = new Transform[col, row];

        var child = 5;
        float unpaintable = 0;

        for (int i = 0; i < col; i++)
        {
            for (int j = 0; j < row; j++)
            {
                canvas[i, j] = transform.parent.GetChild(child);

                if (canvas[i, j].tag.Equals("Unpaintable"))
                    unpaintable++;

                child++;
            }
        }

        total = (col * row) - unpaintable;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isMoving)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mouse_start = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            }
            if (Input.GetMouseButtonUp(0))
            {

                mouse_end = Camera.main.ScreenToViewportPoint(Input.mousePosition);
                input = mouse_end - mouse_start;
                

                if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
                    input = transform.right * input.x;

                if (Mathf.Abs(input.y) > Mathf.Abs(input.x))
                    input = transform.forward * input.y;

                input = input.normalized;
                Check_if_Movable();
            }
        }

        if (isMoving)
        {
            if (transform.position == target.position)
            {
                if(!target.tag.Equals("painted"))
                {
                    target.GetComponent<MeshRenderer>().material = Paint_Mat;

                    target.tag = "painted";

                    painted += 1f;

                    var percent = (painted / total) * 100;

                    FindObjectOfType<Game_Maneger>().Update_Percent((int)percent);

                    if(percent == 100)
                    {
                        FindObjectOfType<Game_Maneger>().Activate_End_Canvas();
                        this.enabled = false;
                    }
                }

                if (Check_if_Movable())
                    isMoving = false;
            }

            else
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }



    }

    private void FixedUpdate()
    {
       
        
    }

    bool Check_if_Movable()
    {
        if ((brush_col - (int)input.y >= 0) && (brush_col - (int)input.y < col) && (brush_row + (int)input.x >= 0) && (brush_row + (int)input.x < row) && (canvas[brush_col - (int)input.y, brush_row + (int)input.x].tag.Equals("pixel") || canvas[brush_col - (int)input.y, brush_row + (int)input.x].tag.Equals("painted")))
        {
            brush_col -= (int)input.y;
            brush_row += (int)input.x;
            target = canvas[brush_col, brush_row];
            isMoving = true;
            return false;
        }

            else
                return true;

    }

        


   


}

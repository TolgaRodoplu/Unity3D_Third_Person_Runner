using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrushController : MonoBehaviour
{
    private Vector3 input;
    private Vector3 mouse_start = Vector3.zero;
    private Vector3 mouse_end = Vector3.zero;
    private bool canPaint = false;
    private bool isMoving = false;
    private int brush_col = 0;
    private int brush_row = 0;
    private float speed = 40f;
    private float painted = 0f;
    private float total;
    private int col = 5;
    private int row = 8;
    public Transform[,] canvas;
    private Transform target;
    public Material Paint_Mat;

    private void Start()
    {
        //Register to the appropriate event
        EventSystem.instance.paintingStarted += StartPainting;
        EventSystem.instance.gameEnded += StopPainting;
    }

    private void Update()
    {
        if (canPaint)
        {
            PaintCanvas();
        }
    }

    private void PaintCanvas()
    {

        // If the brush is not moving get input
        if (!isMoving)
        {
            GetInput();
        }

        // If brush is moving
        if (isMoving)
        {
            // If brush reached the destination
            if (transform.position == target.position)
            {

                // If target is not painted already
                if (!target.tag.Equals("painted"))
                {
                    PaintObject();
                }

                if (Check_if_Movable())
                    isMoving = false;
            }

            // If the brush did not reach its target yet move
            else
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

    }

    private void PaintObject()
    {
        // Paint the object to red
        target.GetComponent<MeshRenderer>().material = Paint_Mat;

        // Mark it as painted
        target.tag = "painted";

        // Increment the painted count
        painted += 1f;

        // Calculate the painted in percent
        var percent = (painted / total) * 100;

        //Notify the EventSystem that percent is updated
        EventSystem.instance.UpdatePercent((int)percent);
    }

    private bool Check_if_Movable()
    {
        if ((brush_col - (int)input.y >= 0) && 
            (brush_col - (int)input.y < col) && 
            (brush_row + (int)input.x >= 0) && 
            (brush_row + (int)input.x < row) && 
            (canvas[brush_col - (int)input.y, brush_row + (int)input.x].tag.Equals("pixel") || canvas[brush_col - (int)input.y, brush_row + (int)input.x].tag.Equals("painted")))
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

    private void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouse_start = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {

            mouse_end = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            input = mouse_end - mouse_start;

            // If inputs x value is bigger take it as only x direction
            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
                input = transform.right * input.x;

            // If inputs y value is bigger take it as only y direction
            if (Mathf.Abs(input.y) > Mathf.Abs(input.x))
                input = transform.forward * input.y;

            // Normalize the input
            input = input.normalized;

            Check_if_Movable();
        }
    }

    private void StartPainting()
    {
        InitilizeCanvas();
        canPaint = true;
    }
    private void StopPainting()
    {
        canPaint = false;
        EventSystem.instance.paintingStarted -= StartPainting;
        EventSystem.instance.gameEnded -= StopPainting;
        this.enabled = false;
    }

    private void InitilizeCanvas()
    {
        // Initilize the canvas
        canvas = new Transform[col, row];

        //Skip first 6
        var child = 5;
        var unpaintable = 0;

        for (int i = 0; i < col; i++)
        {
            for (int j = 0; j < row; j++)
            {
                // Initilize the elements of the canvas array
                canvas[i, j] = transform.parent.GetChild(child);

                // If the element is unpaintable count it
                if (canvas[i, j].tag.Equals("Unpaintable"))
                    unpaintable++;

                child++;
            }
        }

        // Calculate how many paintable elements there are
        total = (col * row) - unpaintable;
    }
}

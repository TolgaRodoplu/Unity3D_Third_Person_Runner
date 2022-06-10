using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingPercentObserver : MonoBehaviour
{
    private void Start()
    {
        //Register to the appropriate event
        EventSystem.instance.percentUpdated += ObservePercent;
    }

    private void ObservePercent(object sender, int percent)
    {
        if(percent == 100)
        {
            EventSystem.instance.percentUpdated -= ObservePercent;
            EventSystem.instance.StopPainting();
            EventSystem.instance.EndGame();
        }
    }
}

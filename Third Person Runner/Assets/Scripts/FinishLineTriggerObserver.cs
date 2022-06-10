using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineTriggerObserver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Player"))
        {
            EventSystem.instance.StopRunning();
            EventSystem.instance.StartCameraTranslate();
        }
    }
}

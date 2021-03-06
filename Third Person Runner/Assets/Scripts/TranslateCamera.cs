using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateCamera : MonoBehaviour
{
    public Transform endPos;

    private void Start()
    {
        //Register to the appropriate event
        EventSystem.instance.cameraTranslateStarted += StartTranslate;
    }

    private void StartTranslate()
    {
        StartCoroutine(CameraTranslate());
    }

    private IEnumerator CameraTranslate()
    {
        var cam = Camera.main;

        while (Vector3.Distance(cam.transform.position, endPos.position) > 2)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, endPos.position, Time.deltaTime);
            cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, endPos.rotation, Time.deltaTime);
            yield return null;
        }

        EventSystem.instance.cameraTranslateStarted -= StartTranslate;
        EventSystem.instance.StartPainting();
        this.enabled = false;
    }
}

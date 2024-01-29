using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraZoom : MonoBehaviour
{
    public bool ZoomActive;
    public Vector3[] Target;
    public Camera Cam;
    public float Speed;

    private void Start()
    {
        Cam = Camera.main;
    }

    public void LateUpdate()
    {
        if (ZoomActive)
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 1.38f, Speed);
            Cam.transform.position = Vector3.Lerp(Cam.transform.position, Target[1], Speed);
        }
        else
        {
            Cam.orthographicSize = Mathf.Lerp(Cam.orthographicSize, 4.472006f, Speed);
            Cam.transform.position = Vector3.Lerp(Cam.transform.position, Target[0], Speed);
        }
    }
}
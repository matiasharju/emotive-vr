using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindRenderCamera : MonoBehaviour
{
    Canvas canvas;
    Camera renderCamera;

    void Start()
    {
        canvas = GetComponent<Canvas>();
        GameObject XRCameraObject = GameObject.Find("XR_Camera");
        renderCamera = XRCameraObject.GetComponent<Camera>();
        if (canvas != null && renderCamera != null) canvas.worldCamera = renderCamera;
    }

    void Update()
    {
        
    }
}

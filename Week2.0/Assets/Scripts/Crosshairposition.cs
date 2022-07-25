using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshairposition : MonoBehaviour
{
    public Camera sceneCamera;
    private Vector2 mousePosition;

    private void FixedUpdate()
    {
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = mousePosition;
    }
}

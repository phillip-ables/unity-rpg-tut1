using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCamera : MonoBehaviour {
    public VirtualJoystick cameraJoystick;

    private float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivityX = 0.0f;
    private float sensitivityY = 0.0f;

    private void Update()
    {
        currentX += cameraJoystick.InputDirection.x * sensitivityX;
        currentY += cameraJoystick.InputDirection.z * sensitivityY;
    }

    private void LateUpdate()
    {
        
    }
}

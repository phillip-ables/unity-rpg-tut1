using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt;

    private Vector3 desiredPosition;
    private Vector3 offset;

    private Vector2 touchPosition;
    private float swipeResistance = 200.0f;

    private float smoothSpeed = 7.5f;
    private float distance = 8.0f;
    private float yOffset = 3.5f;

    private void Start()
    {
        offset = new Vector3(0, yOffset, -1 * distance);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            SlideCamera(true);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            SlideCamera(false);

        if (Input.GetMouseButtonDown(0)//leftclick or first touch{
            || Input.GetMouseButtonDown(1))//rightclick or two fingers
        {
            touchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0)//leftclick or first touch{
            || Input.GetMouseButtonUp(1))//rightclick or two fingers
        {
            //only want to rotate camera so we dont need the y axis
            float swipeForce = touchPosition.x - Input.mousePosition.x;
            if(Mathf.Abs(swipeForce) > swipeResistance)//successfulswipe
            {
                if (swipeForce < 0)//swiping left
                    SlideCamera(true);
                else
                    SlideCamera(false);
            }

        }

    }

    private void FixedUpdate()
    {
        //this really helped with the frame rate
        desiredPosition = lookAt.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(lookAt.position + Vector3.up);
    }

    public void SlideCamera(bool left)
    {
        if (left)
            offset = Quaternion.Euler(0, 90, 0) * offset;
        else
            offset = Quaternion.Euler(0, -90, 0) * offset;
    }
}

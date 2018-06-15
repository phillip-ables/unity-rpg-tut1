using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMoving : MonoBehaviour {

    public float speed;
    private Vector3 move;

    private void Update()
    {
        move = new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0);
        Camera.main.transform.position += move;
    }

    private void LateUpdate()
    {
        transform.position += move;
    }

}

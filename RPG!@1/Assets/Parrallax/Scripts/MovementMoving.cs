using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMoving : MonoBehaviour {

    public float speed;
    public float horizontal;
    private Vector3 move;

    private void Start()
    {
        Camera.main.transform.Translate(10,0,0);

    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        move = new Vector3(horizontal, 0);
        Camera.main.transform.Translate(move);
    }

    private void LateUpdate()
    {
        transform.position = move;
    }

}

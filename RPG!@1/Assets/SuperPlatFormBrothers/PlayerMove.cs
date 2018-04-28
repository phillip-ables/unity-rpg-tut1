using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public int playerSpeed;
    public bool facingRight;
    public int playerJumpPower;

    private float horizontalAxis;
    private Vector3 playerMove;

    private void Start()
    {
        Vector3 playerMove = transform.position;
    }

    private void Update()
    {
        Vector3 playerMove = transform.position;

        horizontalAxis = Input.GetAxis("Horizontal");
        if (Input.GetAxis("Horizontal") > 0)
        {
            facingRight = true;
            Debug.Log(facingRight);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            facingRight = false;
            Debug.Log(facingRight);
        }

        playerMove.x += horizontalAxis * playerSpeed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y < 1)
            playerMove.y += playerJumpPower;

        if (facingRight)
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        else
            transform.rotation = Quaternion.Euler(0.0f, 180f, 0.0f);
        transform.position = playerMove;

    }

}

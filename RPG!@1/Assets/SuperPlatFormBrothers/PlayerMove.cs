using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public int playerSpeed = 10;
    public bool facingRight = true;
    public int playerJumpPower = 1250;
    public float moveX;

    private void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        //CONTROLS
        moveX = Input.GetAxis("Horizontal");
        //ANIMATIONS
        //PLAYER DIRECTION
        if (moveX < 0.0f && facingRight == false)
            FlipPlayer();
        if (moveX > 0.0f && facingRight == true)
            FlipPlayer();
        //PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        //JUMPING CODE
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}

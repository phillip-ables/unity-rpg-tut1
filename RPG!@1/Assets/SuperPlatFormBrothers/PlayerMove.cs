using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public int playerSpeed = 10;
    public int playerJumpPower = 10;
    private float moveX;
    private bool facingRight = true;

    private void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        //CONTROLS
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
            Jump();
        //ANIMATIONS
        //PLAYER DIRECTION
        if (moveX < 0.0f && facingRight == false)
            FlipPlayer();
        else if (moveX > 0.0f && facingRight == true)
            FlipPlayer();
        //PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    
}

    void Jump()
    {
        Vector2 velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        velocity.y = playerJumpPower;
        gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
        //AddForce wasn't working :(
        //GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}

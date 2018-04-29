using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public int playerSpeed;
    public int playerJumpPower;
    public float downDistance;
    public int playBounce;
    public int enBounce;

    private float moveX;
    private bool facingRight = true;
    private bool isGrounded;

    private void Update()
    {
        PlayerRaycast();
        MovePlayer();

    }

    void MovePlayer()
    {
        //CONTROLS
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded)
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
        isGrounded = false;

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

    void PlayerRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit.collider != null 
                && hit.distance < downDistance)
        {
            if (hit.collider.tag != "Enemy")
                isGrounded = true;
            else
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * playBounce);
                GameObject enemy = hit.collider.gameObject;
                enemy.GetComponent<Rigidbody2D> ().AddForce(Vector2.right * enBounce);
                enemy.GetComponent<Rigidbody2D>().gravityScale = 4;
                enemy.GetComponent<Rigidbody2D>().freezeRotation = false;
                enemy.GetComponent<BoxCollider2D>().enabled = false;
                enemy.GetComponent<EnemyMove>().enabled = false;
            }
        }
            
    }
}

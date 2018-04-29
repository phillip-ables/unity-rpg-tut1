using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public int playerSpeed;
    public int playerJumpPower;
    public float castDistance;
    public int playBounce;
    public int enBounce;

    private float moveX;
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
        if (moveX < 0.0f)
            GetComponent<SpriteRenderer>().flipX = true;
        else if (moveX > 0.0f)
            GetComponent<SpriteRenderer>().flipX = false;
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

    void PlayerRaycast()
    {
        RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up);
        if(rayUp.collider != null
                && rayUp.distance < castDistance)
        {
            Destroy(rayUp.collider.gameObject);
        }
        RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down);
        if (rayDown.collider != null 
                && rayDown.distance < castDistance)
        {
            if (rayDown.collider.tag != "Enemy")
                isGrounded = true;
            else
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * playBounce);
                GameObject enemy = rayDown.collider.gameObject;
                enemy.GetComponent<Rigidbody2D> ().AddForce(Vector2.right * enBounce);
                enemy.GetComponent<Rigidbody2D>().gravityScale = 4;
                enemy.GetComponent<Rigidbody2D>().freezeRotation = false;
                enemy.GetComponent<BoxCollider2D>().enabled = false;
                enemy.GetComponent<EnemyMove>().enabled = false;
            }
        }
            
    }
}

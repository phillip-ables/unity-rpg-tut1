using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public float jumpPower = 10.0f;
    public bool isGrounded = false;
    private float posX = 0.0f;
    private bool isGameOver;

    Rigidbody2D myRigidbody;
    ChallengeController myChallengeController;

    private void Start()
    {
        myRigidbody = transform.GetComponent<Rigidbody2D>();
        posX = transform.position.x;
        isGameOver = false;
        myChallengeController = GameObject.FindObjectOfType<ChallengeController>();
    }

    private void Update()
    {
        if(transform.position.x < posX)
        {
            GameOver();
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            myRigidbody.AddForce(Vector3.up * (jumpPower * myRigidbody.mass * myRigidbody.gravityScale * 20.0f));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    void GameOver()
    {
        isGameOver = true;
        myChallengeController.GameOver();
    }
}

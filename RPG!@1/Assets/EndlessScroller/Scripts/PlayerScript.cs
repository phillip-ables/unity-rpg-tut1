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
    GameController myGameController;

    public AudioClip jumpSound;
    public AudioClip scoreSound;
    public AudioClip deathSound;
    AudioSource myAudioPlayer;

    private void Start()
    {
        myRigidbody = transform.GetComponent<Rigidbody2D>();
        posX = transform.position.x;
        isGameOver = false;
        myChallengeController = GameObject.FindObjectOfType<ChallengeController>();
        myGameController = GameObject.FindObjectOfType<GameController>();

        myAudioPlayer = GameObject.FindObjectOfType<AudioSource>();
    }

    private void Update()
    {
        if(transform.position.x < posX && !isGameOver)
        {
            GameOver();
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded && !isGameOver)
        {
            myRigidbody.AddForce(Vector3.up * (jumpPower * myRigidbody.mass * myRigidbody.gravityScale * 20.0f));
            myAudioPlayer.PlayOneShot(jumpSound);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy" && !isGameOver)
        {
            GameOver();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Star")
        {
            myGameController.IncrementScore();
            Destroy(collision.gameObject);
            myAudioPlayer.PlayOneShot(scoreSound);
        }
    }

    void GameOver()
    {
        isGameOver = true;
        myChallengeController.GameOver();
        myAudioPlayer.PlayOneShot(deathSound);
    }
}

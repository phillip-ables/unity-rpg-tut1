using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour {

    private float timeLeft = 120;
    private int playerScore;

    private void Start()
    {
        playerScore = 0;
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0.1)
            SceneManager.LoadScene("SuperPlatFormBrothers");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CountScore();
    }

    void CountScore()
    {
        playerScore += (int)(timeLeft * 10);
    }
}

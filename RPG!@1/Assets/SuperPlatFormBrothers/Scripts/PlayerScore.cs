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
        Debug.Log(timeLeft);
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0.1)
            SceneManager.LoadScene("SuperPlatFormBrothers");
    }

}

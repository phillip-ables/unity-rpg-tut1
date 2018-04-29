using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

    private float timeLeft = 120;
    private int playerScore;

    public GameObject timeUI;
    public GameObject scoreUI;

    private void Start()
    {
        playerScore = 0;
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        timeUI.GetComponent<Text>().text = ("Time: " + (int)timeLeft);
        scoreUI.GetComponent<Text>().text = ("Score: " + playerScore);

        if (timeLeft < 0.1)
            SceneManager.LoadScene("SuperPlatFormBrothers");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Finish")
            FinishLevel();
        if (collision.gameObject.name == "Coin")
        {
            playerScore += 10;
            Destroy(collision.gameObject);
        }
    }

    void FinishLevel()
    {
        playerScore += (int)(timeLeft * 10);
        DataManagement.dataManagement.SaveData();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int score = 0;

    public Text bestText;
    public Text currentText;
    public GameObject newText;
    public Text scoreText;
    public GameObject gameOverPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Star")
        {
            IncrementScore();
        }
    }

    public void GameOver()
    {
        Invoke("ShowOverPanel", 2.0f);
    }

    void ShowOverPanel()
    {
        scoreText.gameObject.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevelName);
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
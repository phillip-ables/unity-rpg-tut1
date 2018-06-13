using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void GameOver()
    {
        Invoke("ShowOverPanel", 2.0f);
    }

    void ShowOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevelName);
    }
}
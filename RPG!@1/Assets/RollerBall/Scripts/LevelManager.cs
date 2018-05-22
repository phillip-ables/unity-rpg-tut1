using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    public GameObject pauseMenu;
    public GameObject pauseButton;

    private float startTime;
    public float silverTime;
    public float goldTime;

    public void Start()
    {
        instance = this;
        pauseMenu.SetActive(false);
        startTime = Time.time; //keep time stamp
    }

    public void TogglePauseMenu()
    {
        pauseButton.SetActive(!pauseButton.activeSelf);
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("RollerBall_Main_Menu");
    }

    public void Victory()
    {
        float duration = Time.time - startTime;

        if (duration < goldTime)
        {
            GameManager.Instance.currency += 50;
        }
        else if (duration < silverTime)
            GameManager.Instance.currency += 25;
        else
            GameManager.Instance.currency += 5;
    }
}

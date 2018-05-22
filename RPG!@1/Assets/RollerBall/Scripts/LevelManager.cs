using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    public GameObject pauseMenu;
    public GameObject pauseButton;

    public void Start()
    {
        instance = this;
        pauseMenu.SetActive(false);
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
        Debug.Log("VICTORY");
    }
}

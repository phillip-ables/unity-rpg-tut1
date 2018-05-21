using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public GameObject pauseMenu;
    public GameObject pauseButton;

    public void Start()
    {
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
}

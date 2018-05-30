using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    public GameObject pauseMenu;
    public GameObject pauseButton;
    public Transform respawnPoint;
    private GameObject player;

    private float startTime;
    public float silverTime;
    public float goldTime;

    public void Start()
    {
        instance = this;
        pauseMenu.SetActive(false);
        startTime = Time.time; //keep time stamp
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = respawnPoint.position;
    }

    private void Update()
    {
        //this is where we kill the player




        if (player.transform.position.y < -11.0f)
            Death();

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
            GameManager.Instance.currency += 50;
        else if (duration < silverTime)
            GameManager.Instance.currency += 25;
        else
            GameManager.Instance.currency += 5;

        GameManager.Instance.Save();

        string saveString = ""; // "30&60&45"

        LevelData level = new LevelData(SceneManager.GetActiveScene().name);

        saveString += (level.BestTime > duration || level.BestTime == 0.0f) ? duration.ToString() : level.BestTime.ToString();
        saveString += '&';
        saveString += silverTime.ToString();
        saveString += '&';
        saveString += goldTime.ToString();

        PlayerPrefs.SetString(SceneManager.GetActiveScene().name, saveString);

        SceneManager.LoadScene("RollerBall_Main_Menu");
    }

    public void Death()
    {
        player.transform.position = respawnPoint.position;
        Rigidbody rigid = player.GetComponent<Rigidbody>();
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }
}

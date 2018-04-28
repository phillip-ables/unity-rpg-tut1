﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public bool hasDied;
    public int playerHealth;

    private void Start()
    {
        hasDied = false;
    }

    private void Update()
    {
        if(gameObject.transform.position.y < -5.0f)
        {
            hasDied = true;
        }
        if(hasDied == true)
        {
            //start co-routine, 
            //very similar to methods or functions
            //but you can wait or pause
            StartCoroutine("Die");
        }  
    }

    IEnumerator Die()
    {
        SceneManager.LoadScene("SuperPlatformer");
        yield return null;
    }
}

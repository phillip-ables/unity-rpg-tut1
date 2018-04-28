using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    private void Update()
    {
        if(gameObject.transform.position.y < -5.0f)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene("SuperPlatFormBrothers");
    }
}

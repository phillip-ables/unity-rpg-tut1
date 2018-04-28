using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public bool hasDied;
    public int playerHealth;

    private void Start()
    {
        hasDied = false;
    }

    private void Update()
    {
        if(gameObject.transform.position.y < -3)
        {
            hasDied = true;
        }
        Debug.Log("Player Has Died " + hasDied);
    }

}

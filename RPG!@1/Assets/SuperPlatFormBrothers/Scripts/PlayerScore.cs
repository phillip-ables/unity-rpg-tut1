using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour {

    public float timeLeft = 120;

    private void Update()
    {
        timeLeft -= Time.deltaTime;
    }

}

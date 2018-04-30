using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    private GameObject player;


    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)     
            player = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {

        if (GameObject.FindGameObjectWithTag("Player") != null)
            player = GameObject.FindGameObjectWithTag("Player");
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}

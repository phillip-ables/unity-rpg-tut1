using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour {

    public float speed;
    private float xDir;

    private void Start()
    {
        xDir = transform.position.x;
    }

    private void Update()
    {
        xDir -= Time.deltaTime * speed;
        transform.position = new Vector3(xDir, transform.position.y, transform.position.z);
    }

}

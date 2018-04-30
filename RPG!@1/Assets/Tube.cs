using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour {

    public GameObject spawnPoint;

    private void OnTriggerStay2D(Collider2D collision)
    {
        print("Collision Stay");
        print(Input.GetAxis("Vertical"));
        if (Input.GetAxis("Vertical") < 0.0f)
        {
            print("Down");
            collision.gameObject.transform.position = spawnPoint.transform.position;
        }
    }
}

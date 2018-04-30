using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportDoor : MonoBehaviour {

    public GameObject spawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.position = spawnPoint.gameObject.transform.position;
    }

}

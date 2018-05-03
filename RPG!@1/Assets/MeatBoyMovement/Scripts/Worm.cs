using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : MonoBehaviour {

    public Vector2[] verticies;
    public GameObject wormSprite;
    private float vertixDistance = 5.0f;
    private float spriteLength = 0.18f;
    private float straightLength;
    private Vector3 currentPos;
    

	void Start () {
        currentPos = transform.position;

        //positions verticies

        for(int i = 0; i < vertixDistance/spriteLength; i++)
        {
            Instantiate(wormSprite, currentPos, Quaternion.identity);
            currentPos.x += spriteLength;
        }
    }
	
}

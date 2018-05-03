﻿using System.Collections;
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
        Vector2[] verticies =
        {
            new Vector2(1.736f, -2.098f),
            new Vector2(1.736f, 1.93f)
        };

        for(int i = 0; i < vertixDistance/spriteLength; i++)
        {
            Instantiate(wormSprite, currentPos, Quaternion.identity);
            currentPos.x += spriteLength;
        }
    }
	
}

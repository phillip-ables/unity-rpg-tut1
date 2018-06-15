using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackgroundScript : MonoBehaviour {

    public float backgroundSize;

    private Transform cameraTransform;
    private Transform[] layers;
    private float viewZone = 10;
    private int leftIndex;
    private int rightIndex;


    private void Start()
    {
        cameraTransform = Camera.main.transform;
        layers = new Transform[transform.childCount];

        for(int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }

        leftIndex = 0;
        rightIndex = layers.Length - 1;
    }

    private void ScrollLeft()
    {

    }

    private void ScrollRight()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaunchArcRenderer : MonoBehaviour {

    LineRenderer lr;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }
}

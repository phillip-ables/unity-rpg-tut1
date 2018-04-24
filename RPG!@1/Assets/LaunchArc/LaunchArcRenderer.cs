using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaunchArcRenderer : MonoBehaviour {

    LineRenderer lr;

    public float velocity;
    public float angle;
    public int resolution;

    float g;
    float radianAngle;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        g = Mathf.Abs(Physics2D.gravity.y);
    }

    private void Start()
    {
        RenderArc();
    }

    //populating line renderer with settings
    void RenderArc()
    {
        lr.positionCount = (resolution + 1);
        lr.SetPosition(CalculateArray());
    }
    
}

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

    //if inspector of this class changes, run this code agian;
    private void OnValidate()
    {
        if(lr != null && Application.isPlaying)
        {
            RenderArc();
        }
    }

    private void Start()
    {
        RenderArc();
    }

    //populating line renderer with settings
    void RenderArc()
    {
        lr.positionCount = (resolution + 1);
        lr.SetPositions(CalculateArray());
    }
    
    Vector3[] CalculateArray()
    {
        Vector3[] arcArray = new Vector3[resolution + 1];

        radianAngle = Mathf.Deg2Rad * angle;
        float maxDistance = (velocity * velocity * Mathf.Sin(2 * radianAngle) )/ g;

        for(int i = 0; i <= resolution; i++)
        {
            float t = (float)i / (float)resolution;
            arcArray[i] = CalculateArcPoint(t, maxDistance);
        }

        return arcArray;
    }

    //calculate height and distance of each vertex
    Vector3 CalculateArcPoint(float t, float maxDistance)
    {
        float x = t * maxDistance;
        float y = x * Mathf.Tan(radianAngle) - ( (g * x * x) / (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle)));
        return new Vector3(x, y);
    }
}

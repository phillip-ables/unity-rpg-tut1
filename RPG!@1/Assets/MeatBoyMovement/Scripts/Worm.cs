using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : MonoBehaviour {

    public Transform[] verticies;
    public GameObject wormSprite;
    public GameObject wormHead;
    public float slowDistance;
    public float wormAcc;
    private float delay = .1f;


    private float rotDeg = 90;



    private float spriteLength = 0.18f;
    private float straightLength;

    private Vector3 relativePosition;
    private Quaternion turnRotation;
    private bool rotating = false;
    private float rotationTime;

    private float xChangePer, yChangePer;
    private Vector3 currentPos;
    

    /*
     * head turn toward next waypoint
     * move through way points
     * body need to be parented
     * instantiate at distance long enough from spawn
    */

	void Start () {
        StartCoroutine(MakeSnake());
    }

    IEnumerator MakeSnake()
    {
        currentPos = transform.position;
        GameObject head = Instantiate(wormHead, currentPos, Quaternion.identity);

        for (int i = 0; i <= verticies.Length; i++) //2
        {
            //distance formula
            straightLength = Mathf.Sqrt(((verticies[i].position.y - currentPos.y) * (verticies[i].position.y - currentPos.y))
                                        + ((verticies[i].position.x - currentPos.x) * (verticies[i].position.x - currentPos.x)));
            xChangePer = (verticies[i].position.x - currentPos.x) / (straightLength / spriteLength);
            yChangePer = (verticies[i].position.y - currentPos.y) / (straightLength / spriteLength);


            if (i + 1 < verticies.Length)
            {


                //you dont need to think you need to know

                //law of sins
                //tan inverse equals
                float adj = verticies[i + 1].position.x - currentPos.x;
                float opp = verticies[i + 1].position.y - currentPos.y;
                float thetaA = Mathf.Atan(opp / adj);

                float hyp = Mathf.Sqrt(adj * adj + opp * opp);
                //adj/thetaA = hyp/theta
                //adj*sinhyp = hyp*sinadj
                //invsintheta of hyp * sinthetaA / adj
                rotDeg = Mathf.Asin((hyp * Mathf.Sin(thetaA)) / adj);
                print("adj " + adj + ", opp " + opp + ", theta " + rotDeg);
            }

            for (int j = 0; j < straightLength / spriteLength; j++)
            {

                //need a slow down effect
                if (Mathf.Abs((verticies[i].position.x - currentPos.x)) < slowDistance
                        && Mathf.Abs((verticies[i].position.y - currentPos.y)) < slowDistance)
                {
                    delay *= wormAcc;
                    //print("SlowDown "+delay);
                    //delay = 0.2f;
                }
                else
                {
                    delay /= wormAcc;
                    //print("SpeedUp " + delay);
                    //delay = 0.08f;
                }
                head.transform.position = currentPos;
                Instantiate(wormSprite, currentPos, Quaternion.identity);
                currentPos = new Vector3(
                                currentPos.x + xChangePer,
                                currentPos.y + yChangePer,
                                currentPos.z
                                );
                yield return new WaitForSeconds(delay);
            }
            head.transform.rotation = Quaternion.Euler(0, 0, rotDeg);
        }
    }
}

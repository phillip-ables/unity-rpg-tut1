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


    private float theta; // i think theta should equal 0 @ initial



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
                //law of cosines
                //inverse cos = (a*a)+ (b*b)- (c*c)   / (2*a*b)
                float a = verticies[i + 1].position.x - currentPos.x;
                float b = verticies[i + 1].position.y - currentPos.y;
                float c = Mathf.Sqrt((a * a) + (b * b));
                theta += Mathf.Acos(((a * a) + (b * b) - (c * c)) / (2 * a * b)) * (180 / Mathf.PI);
                //you dont need to think you need to know
                //print("angle " + i + " " + theta);
                print("adj " + a + ", opp " + b + ", hyp "+c+", theta " + theta);
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
            head.transform.rotation = Quaternion.Euler(0, 0, theta);
        }
    }
}

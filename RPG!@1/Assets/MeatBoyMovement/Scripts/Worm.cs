using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : MonoBehaviour {

    public Vector2[] verticies;
    public GameObject wormSprite;
    public GameObject wormHead;
    public float slowDistance;
    public float wormAcc;
    private float delay = .1f;



    private float spriteLength = 0.18f;
    private float straightLength;
    private float xChangePer, yChangePer;
    private Vector3 currentPos;
    

    /*
     * switch to transform array
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


        //positions verticies
        //this should be turned into a public transform of waypoint gameObjects
        Vector2[] verticies =
        {
            new Vector2(1.736f, -2.098f),
            new Vector2(1.736f, 0.602f),
            new Vector2(-3.34f, 0.602f),
            new Vector2(-3.34f, 2.54f),
            new Vector2(2.43f, 1.142f),
            new Vector2(3.88f, -2.7f)
        };
        for (int i = 0; i <= verticies.Length; i++) //2
        {
            //distance formula
            straightLength = Mathf.Sqrt(((verticies[i].y - currentPos.y) * (verticies[i].y - currentPos.y))
                                        + ((verticies[i].x - currentPos.x) * (verticies[i].x - currentPos.x)));
            xChangePer = (verticies[i].x - currentPos.x) / (straightLength / spriteLength);
            yChangePer = (verticies[i].y - currentPos.y) / (straightLength / spriteLength);
            

            //look at next vertex!!
            for (int j = 0; j < straightLength / spriteLength; j++)
            {
                //need a slow down effect
                if (Mathf.Abs((verticies[i].x - currentPos.x)) < slowDistance
                        && Mathf.Abs((verticies[i].y - currentPos.y)) < slowDistance)
                {
                    delay *= wormAcc;
                    print("SlowDown "+delay);
                    //delay = 0.2f;
                }
                else
                {
                    delay /= wormAcc;
                    print("SpeedUp " + delay);
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
        }
    }
}

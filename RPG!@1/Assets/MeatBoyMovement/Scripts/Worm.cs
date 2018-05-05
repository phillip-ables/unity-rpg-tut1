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
        
        for (int i = 0; i <= verticies.Length; i++) //2
        {
            //distance formula
            straightLength = Mathf.Sqrt(((verticies[i].position.y - currentPos.y) * (verticies[i].position.y - currentPos.y))
                                        + ((verticies[i].position.x - currentPos.x) * (verticies[i].position.x - currentPos.x)));
            xChangePer = (verticies[i].position.x - currentPos.x) / (straightLength / spriteLength);
            yChangePer = (verticies[i].position.y - currentPos.y) / (straightLength / spriteLength);


            //look at next vertex!!
            head.transform.LookAt(verticies[i].position);
            for (int j = 0; j < straightLength / spriteLength; j++)
            {
                //need a slow down effect
                if (Mathf.Abs((verticies[i].position.x - currentPos.x)) < slowDistance
                        && Mathf.Abs((verticies[i].position.y - currentPos.y)) < slowDistance)
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {


    private void Start()
    {

        string[] messages = { "welcom", "TO", "this", "AMAZING", "game" };
        StartCoroutine(PrintMessages(messages, .5f));

    }

    IEnumerator Move(Vector3 destination, float speed)
    {
        while(transform.position != destination)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return null;  // wait one frame
        }
    }

    IEnumerator PrintMessages(string[] messages, float delay)
    {
        foreach (string msg in messages)
        {
            print(msg);
            yield return new WaitForSeconds(delay);
        }
    }
}

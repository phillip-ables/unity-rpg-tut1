using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {


    private void Start()
    {

        string[] messages = { "welcom", "TO", "this", "GAME" };
        StartCoroutine(PrintMessages(messages, .5f));

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

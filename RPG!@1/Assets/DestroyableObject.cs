using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour {
    public float forceRequired = 3.0f;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.impulse);
    }
}

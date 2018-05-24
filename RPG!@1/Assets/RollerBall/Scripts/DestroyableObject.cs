using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour {
    public float forceRequired = 10.5f;

    private void OnCollisionEnter(Collision collision)
    {
        //7 no run start -- 9-11 with run -- 11-13 with boost
        if (collision.impulse.magnitude > forceRequired)
            Destroy(gameObject);
    }
}

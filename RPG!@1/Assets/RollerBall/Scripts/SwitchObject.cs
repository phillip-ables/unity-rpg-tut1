﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObject : MonoBehaviour {
    public Transform target;

    private void OnCollisionEnter(Collision collision)
    {
        if(target != null)
            Destroy(target.gameObject);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour {
    public float moveSpeed = 5.0f;
    public float drag = 0.5f;
    public float terminalRotationSpeed = 25.0f;

    private Rigidbody controller;

    private void Start()
    {
        controller = GetComponent<Rigidbody>();
        controller.maxAngularVelocity = terminalRotationSpeed;
        controller.drag = drag;
    }
}

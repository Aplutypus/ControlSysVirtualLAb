using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropulsionForce : MonoBehaviour
{
    [SerializeField] private Rigidbody pendulum;
    [SerializeField] private Transform pendulumTransform;
    [SerializeField] private Transform propellerTransform;
    [SerializeField] private float force;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            pendulum.AddForceAtPosition(new Vector3(0,0,-force), propellerTransform.position, ForceMode.Force);
        }
        
        // Debug.Log(pendulumTransform.rotation);
    }
}

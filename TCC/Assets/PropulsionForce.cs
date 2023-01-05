using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropulsionForce : MonoBehaviour
{
    [SerializeField] private Rigidbody stemPropeller;
    [SerializeField] private Transform propellerReference;
    [SerializeField] private float force;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            stemPropeller.AddForceAtPosition(new Vector3(0,0,-force), propellerReference.position, ForceMode.Force);
        }
    }
}

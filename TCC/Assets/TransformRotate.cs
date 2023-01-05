using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformRotate : MonoBehaviour
{
    private enum Axis
    {
        x,
        y,
        z
    }

    [SerializeField] private Transform transformRotate;
    [SerializeField] private float velocity;
    [SerializeField] private Axis axis;

    private float speed;

    private void Start()
    {
        speed = velocity * Time.deltaTime;
    }

    void Update()
    {
        switch (axis)
        {
            case Axis.x:
                transformRotate.Rotate(speed ,0,0);
                break;
            case Axis.y:
                transformRotate.Rotate( 0,speed,0);
                break;
            case Axis.z:
                transformRotate.Rotate(0 ,0,speed);
                break;
            default: return;
        }
    }
}

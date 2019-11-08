using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Probeller : MonoBehaviour
{

    public float turnSpeed = 0.5f;
    public bool flip = false;


    private void FixedUpdate()
    {
        if (flip)
            transform.Rotate(0, turnSpeed, 0);

        else
            transform.Rotate(0, -1 * turnSpeed, 0);
    }
}

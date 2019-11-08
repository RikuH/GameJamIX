using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snek_rotation : MonoBehaviour
{
    public float x_speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(x_speed, 0, 0);
         //Rotation amount or degree of rotation per frame (x,y,z)
    }
}

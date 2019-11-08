using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snek_rotate : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(5, 0, 0);
    }
}

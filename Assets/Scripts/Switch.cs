using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    public Room Room;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Room.ToggleExit();
        }
    }
}

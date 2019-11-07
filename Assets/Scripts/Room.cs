using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    //These are empty gameobjects, that are rooms children.
    public GameObject RoomCameraPosition;
    public GameObject RoomPlayerSpawn;
    public GameObject RoomExitPosition;

    public bool ExitUnlocked;
    public Door Door;
  
    private bool DoorMoving = false;

    private void Start()
    {
        ExitUnlocked = false;

    }

    public void ToggleExit()
    {
        Debug.Log("ToggleExit");
        DoorMoving = true;

        if (!ExitUnlocked)
        {
            ExitUnlocked = true;
        }

        else
        {
            ExitUnlocked = false;
        }
    }
}

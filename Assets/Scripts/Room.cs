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

    private void Start()
    {
        ExitUnlocked = false;

    }

    public void ToggleExit()
    {

        if (!ExitUnlocked)
        {
            ExitUnlocked = true;
        }

        else
        {
            ExitUnlocked = false;
        }

        Door.ToggleDoor();
    }
}

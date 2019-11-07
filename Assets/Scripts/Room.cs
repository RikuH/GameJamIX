using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool ExitUnlocked;

    //These are empthy gameobjects, that are rooms children.
    public GameObject RoomCameraPosition;
    public GameObject RoomPlayerSpawn;
    public GameObject RoomExitPosition;

    private void Start()
    {
        ExitUnlocked = false;
    }
}

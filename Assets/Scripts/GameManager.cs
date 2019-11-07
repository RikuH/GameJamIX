using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera GameCamera;
    public PlayerMovement player;
    public Room currentRoom;

    //List of all rooms in scene
    public List<Room> RoomList;
    //Lisr index of current room
    public int RoomIndex;


    // Start is called before the first frame update
    void Start()
    {
        RoomIndex = 0;
        currentRoom = RoomList[RoomIndex];
        ChangeRoom(currentRoom);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (currentRoom.ExitUnlocked)
            GoToNextRoom();
    }

    public void GoToNextRoom()
    {
        if (RoomIndex < RoomList.Count - 1)
            RoomIndex++;

        else
            RoomIndex = 0;

        ChangeRoom(RoomList[RoomIndex]);
    }

    public void ChangeRoom(Room room)
    {
        currentRoom = room;
        UpdateCameraPosition(room);
        player.transform.position = room.RoomPlayerSpawn.transform.position;

        //Move the gamemanager object to exit location
        this.transform.position = room.RoomExitPosition.transform.position;
    }

    private void UpdateCameraPosition(Room room)
    {
        GameCamera.transform.position = room.RoomCameraPosition.transform.position;
        GameCamera.transform.rotation = room.RoomCameraPosition.transform.rotation;
    }

    
}

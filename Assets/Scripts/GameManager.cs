using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera GameCamera;
    public PlayerMovement player;

    public Room currentRoom;
    public List<Room> RoomList;

    

    // Start is called before the first frame update
    void Start()
    {
        currentRoom = RoomList[0];
        UpdateCameraPosition(currentRoom);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateCameraPosition(Room room)
    {
        GameCamera.transform.position = room.RoomCameraPosition.transform.position;
        GameCamera.transform.rotation = room.RoomCameraPosition.transform.rotation;
    }

    
}

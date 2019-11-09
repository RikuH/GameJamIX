using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera GameCamera;
    public PlayerMovement player;
    public Room currentRoom;
    public Light WorldLight;

    //List of all rooms in scene
    public List<Room> RoomList;
    //Lisr index of current room
    public int RoomIndex;

    void Start()
    {
        RoomIndex = 0;
        currentRoom = RoomList[RoomIndex];
        ChangeRoom(currentRoom);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (currentRoom.ExitUnlocked && other.tag == "Player")
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

        // If the room has dark tag dimm the lights
        if (currentRoom.tag == "Dark")
        {
            Debug.Log("Pimee");
            WorldLight.intensity = 0.05f;
        }

        else if (currentRoom.tag == "Ice")
        {
            Debug.Log("Jaata");
            GameObject.Find("LuistelevaKusipaa").GetComponent<SkatingEnemyScript>().isActive = true;
            WorldLight.intensity = 1.0f;
            WorldLight.color = new Color(0.7f, 1, 1);
        }
        else if (currentRoom.tag == "Convoyer")
        {
            Debug.Log("Convoyer");
            WorldLight.color = new Color(1, 1, 1);
            player.soundOfMusic.FactorySounds(true);
        }
        else if (currentRoom.tag == "Inverted")
        {
            Debug.Log("Inverted");
            WorldLight.intensity = 1.0f;
            player.soundOfMusic.confused();
        }
        else
        {

            player.soundOfMusic.FactorySounds(false);
            GameObject.Find("LuistelevaKusipaa").GetComponent<SkatingEnemyScript>().isActive = false;
            WorldLight.color = new Color(1, 1, 1);
            WorldLight.intensity = 1.0f;
        }
    }

    private void UpdateCameraPosition(Room room)
    {
        GameCamera.transform.position = room.RoomCameraPosition.transform.position;
        GameCamera.transform.rotation = room.RoomCameraPosition.transform.rotation;
    }


}

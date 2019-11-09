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

    public Boss_movement Bosautus;
    public GameOverHUD menut;

    public GameObject slaideri;

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
            player.soundOfMusic.confused(false);
            WorldLight.intensity = 0.05f;
        }

        if (currentRoom.tag == "DarkInverted")
        {
            WorldLight.intensity = 0.05f;
            player.soundOfMusic.confused(true);

        }

        if (currentRoom.tag == "Ice")
        {
            Debug.Log("Jaata");
            player.soundOfMusic.confused(false);
            GameObject.Find("LuistelevaKusipaa").GetComponent<SkatingEnemyScript>().isActive = true;
            WorldLight.intensity = 1.0f;
            WorldLight.color = new Color(0.7f, 1, 1);
        }
        if (currentRoom.tag == "Convoyer")
        {
            Debug.Log("Convoyer");
            player.soundOfMusic.confused(false);
            WorldLight.color = new Color(1, 1, 1);
            player.soundOfMusic.FactorySounds(true);
        }
        if (currentRoom.tag == "Inverted")
        {
            Debug.Log("Inverted");
            WorldLight.intensity = 1.0f;
            player.soundOfMusic.confused(true);
        }
        if (currentRoom.tag == "VictoryRoom")
        {
            slaideri.SetActive(false);
            menut.voitto();
            player.soundOfMusic.doTadaa();
        }
        if (currentRoom.tag == "BossRoom")
        {
            slaideri.SetActive(true);
            player.soundOfMusic.confused(false);
            player.soundOfMusic.Bosautus();
            Bosautus.isActive = true;
            WorldLight.color = new Color(0.8F, 1, 0.8F);
            WorldLight.intensity = 1.0f;
        }
        if (currentRoom.tag == "Untagged")
        {
            player.soundOfMusic.confused(false);
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

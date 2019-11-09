using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int hitpoints = 3;
    public Room Room;

    public GameObject valois;

    // Start is called before the first frame update
    public void takeHit()
    {
        hitpoints--;
        Debug.Log("boss takes hit");

        if (hitpoints <= 0){

            Room.ToggleExit();
            valois.SetActive(true);   
        }
    }
}

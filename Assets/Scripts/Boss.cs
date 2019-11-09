using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int hitpoints = 3;
    public Room Room;

    public GameObject valois;
    public Slider bossHpSlider;

    public audioController asdasd;

    public bool isdead = false;
    // Start is called before the first frame update
    public void takeHit()
    {

        bossHpSlider.value = hitpoints - 1;
        hitpoints--;
        Debug.Log("boss takes hit");

        if (hitpoints <= 0)
        {
            isdead = true;
            Room.ToggleExit();
            valois.SetActive(true);
        }
    }
}

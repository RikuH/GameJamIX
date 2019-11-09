using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui : MonoBehaviour
{
    public List<Image> hearts;
    public PlayerMovement player;

    private Color Red = new Color(191, 191, 191, 255);
    private Color Black = new Color(0, 0, 0, 255);

    // Start is called before the first frame update
    void Start()
    {
        foreach( Image heart in hearts)
        {
            heart.color = Red;
        }
    }

    private void Update()
    {
        if(player.health >= 0)
        {
            for (int i = player.health; i < 3; i++)
            {
                hearts[i].color = Black;
            }
        }
        Canvas.ForceUpdateCanvases();
    }
}

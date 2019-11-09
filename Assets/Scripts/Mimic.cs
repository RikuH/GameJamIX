using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimic : MonoBehaviour
{

    public Room mimicRoom;
    public GameManager GameManager;
    private PlayerMovement Player;
    private Quaternion targerRotation;

    [SerializeField] AnimController animations;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameManager.player;
    }

    private void FixedUpdate()
    {
        if (GameManager.currentRoom == mimicRoom)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Player.transform.rotation, Player.TurnSpeed * Time.deltaTime);
            transform.forward = transform.forward * -1;
            Move();
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position -= Vector3.forward * Time.deltaTime * Player.moveSpeed;
            animations.walkAnimation();
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += Vector3.forward * Time.deltaTime * Player.moveSpeed;
            animations.walkAnimation();
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position -= Vector3.left * Time.deltaTime * Player.moveSpeed;
            animations.walkAnimation();
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += Vector3.left * Time.deltaTime * Player.moveSpeed;
            animations.walkAnimation();
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            animations.idleAnimation();
        }
    }
}

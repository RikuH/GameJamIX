using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_movement : MonoBehaviour
{
    Transform player;
    public ParticleSystem particle;
    public PlayerMovement playerHP;
    public Boss boss;
    UnityEngine.AI.NavMeshAgent nav;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHP = player.GetComponent<PlayerMovement>();
        boss = GetComponent<Boss>();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }


    void Update ()
    {
       if(boss.hitpoints > 0 && playerHP.health > 0)
       {
           nav.SetDestination (player.position);
       }
       else
       {
           nav.enabled = false;
            Destroy(this.gameObject);
       }
    }
}
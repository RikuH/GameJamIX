using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_movement : MonoBehaviour
{
    Transform player;
    public GameObject particle;
    public PlayerMovement playerHP;
    public Boss boss;
    UnityEngine.AI.NavMeshAgent nav;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHP = player.GetComponent<PlayerMovement>();
        boss = GetComponent<Boss>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    void Update()
    {
        if (boss.hitpoints > 0)
        {
            if (playerHP.health > 0)
                nav.SetDestination(player.position);
        }
        else
        {
            particle.SetActive(true);
            particle.transform.position = this.transform.position;
            nav.enabled = false;
            Destroy(this.gameObject);
        }
    }
}
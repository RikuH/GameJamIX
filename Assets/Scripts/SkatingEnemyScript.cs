using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkatingEnemyScript : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject[] rndPoints;
    int newRandom;

    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        RandomizeNextPosition();
        newRandom = rndPoints.Length + 1;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(player.transform);
    }

    void RandomizeNextPosition()
    {
        int random = Random.Range(0, rndPoints.Length);
        Debug.Log("Old Random: " + random + " new Random: " + newRandom);

        if (random != newRandom)
        {
            Debug.Log("Next position 1");
            newRandom = random;
            agent.SetDestination(rndPoints[newRandom].transform.position);
            Debug.Log("Next position 2");
        }
        else
        {
            Debug.Log("Same Random");
            RandomizeNextPosition();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Untagged")
        {
            //Debug.Log(other.tag);

            if (other.tag == "rndPos")
            {
                //StartCoroutine(delay());
                RandomizeNextPosition();
            }
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(1);
        RandomizeNextPosition();
    }
}


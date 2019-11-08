using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class snek_patrol : MonoBehaviour
{
    public float speed;
    public float startWaitTime;
    private float waitTime;
    public Transform[] moveSpots;
    private Transform currentSpot;
    public NavMeshAgent navMeshAgent;
    private int RandomIndex;

    NavMeshAgent agent;
    public GameObject[] rndPoints;
    int newRandom;
    [SerializeField] private GameObject snake;
    public float DestTreshold;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        RandomIndex = Random.Range(0, moveSpots.Length-2);
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(moveSpots[RandomIndex].position);
        agent = GetComponent<NavMeshAgent>();
        RandomizeNextPosition();
        newRandom = rndPoints.Length + 1;

    }

    void Update()
    {
        transform.LookAt(snake.transform);
        CheckDestinationReached();
    }

    void RandomizeNextPosition()
    {
        int random = Random.Range(0, rndPoints.Length -1);
        //Debug.Log("Old Random: " + random + " new Random: " + newRandom);

        if (random != newRandom)
        {
            //Debug.Log("Next position 1");
            newRandom = random;
            currentSpot = rndPoints[newRandom].transform;
            agent.SetDestination(currentSpot.position);
            //Debug.Log("Next position 2");
        }
        else
        {
            //Debug.Log("Same Random");
            RandomizeNextPosition();
        }
    }

    void CheckDestinationReached()
    {
        float distanceToTarget = Vector3.Distance(transform.position, currentSpot.position);
        if (distanceToTarget < DestTreshold)
        {
            print("Destination reached");
            RandomizeNextPosition();
        }
    }
    // Update is called once per frame
    /*
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomspot].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, moveSpots[randomspot].position) < 0.2f) 
        {
            if (waitTime <= 0)
            {
                randomspot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
                navMeshAgent.SetDestination(moveSpots[randomspot].position);    




                // Get the point along the ray that hits the calculated distance.
                Vector3 targetPoint = moveSpots[randomspot].position;

                // Determine the target rotation.  This is the rotation if the transform looks at the target point.
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

                // Smoothly rotate towards the target point.
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 100 * Time.deltaTime);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

  void OnTriggerEnter(Collider other)
{
    if (other.tag != "Untagged")
    {
        //Debug.Log(other.tag);

        if (other.tag == "rndPos")
        {
            Debug.Log("asdasd");
            //StartCoroutine(delay());
            RandomizeNextPosition();
        }
    }
}

         // Get the point along the ray that hits the calculated distance.
        //Vector3 targetPoint = moveSpots[randomspot].position;

        // Determine the target rotation.  This is the rotation if the transform looks at the target point.
        //Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

        // Smoothly rotate towards the target point.
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 100 * Time.deltaTime);*/
}

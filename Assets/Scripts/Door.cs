using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    private Vector3 startMarker;
    private Vector3 endMarker;

    // Movement speed in units per second.
    public float speed = 1.0f;
    // Time when the movement started.
    private float startTime;
    // Total distance between the markers.
    private float journeyLength;
    // Distance moved equals elapsed time times speed.
    private float distCovered;
    // Fraction of journey completed equals current distance divided by total distance.
    private float fractionOfJourney;

    public bool DoorOpening = false;
    public bool DoorOpen = false;

    void Start()
    {
        startMarker = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        endMarker = new Vector3(transform.position.x, transform.position.y - 2.0f, transform.position.z);

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker, endMarker);
    }

    // Move to the target end position.
    void Update()
    {
        if (DoorOpening)
        {

            distCovered = (Time.time - startTime) * speed;

            fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            if(!DoorOpen)
                transform.position = Vector3.Lerp(startMarker, endMarker, fractionOfJourney);
            else
                transform.position = Vector3.Lerp(endMarker, startMarker, fractionOfJourney);

            if (fractionOfJourney >= 1)
            {
                DoorOpening = false;

                //Toggle DoorOpen
                if (DoorOpen)
                    DoorOpen = false;

                else
                    DoorOpen = true;
            }
        }
    }

    public void ToggleDoor()
    {

        // Keep a note of the time the movement started.
        startTime = Time.time;

        DoorOpening = true;
    }
}

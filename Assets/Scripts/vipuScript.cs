using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vipuScript : MonoBehaviour
{
    [SerializeField] int toggleDelay;
    public Room Room;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (GameObject.Find("Lonk").GetComponent<PlayerHit>().isHitting)
            {
                Room.ToggleExit();
                this.transform.rotation = new Quaternion(-40, 0, 0, 0);

                StartCoroutine(closeDoor());
            }
        }
    }
    IEnumerator closeDoor()
    {
        yield return new WaitForSeconds(toggleDelay);
        this.transform.rotation = new Quaternion(-135, 0, 0, 0);
        Room.ToggleExit();
    }
}

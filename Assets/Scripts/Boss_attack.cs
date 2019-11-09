using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_attack : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.transform.tag);
        if (col.transform.tag == "Player")
        {
            if (this.transform.position.z > Player.transform.position.z)
                Player.transform.position -= Vector3.forward * Time.deltaTime * 100;
            else
                Player.transform.position += Vector3.forward * Time.deltaTime * 100;

            StartCoroutine(GameObject.Find("RealLonk").GetComponent<PlayerMovement>().PlayerTakeDamage());
        }
    }
}

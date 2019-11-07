using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vipuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other){
        if(other.tag == "Player"){
            if(GameObject.Find("Lonk").GetComponent<PlayerHit>().isHitting){
                Debug.Log("vipu");
                this.transform.rotation = new Quaternion(-40,0,0,0);
            }
        }
    }
}

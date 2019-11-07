using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public bool isHitting = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isHitting)
            {
                Debug.Log("VIUH " + isHitting);
                isHitting = true;
                //GameObject.Find("Sword").GetComponent<Animator>().SetBool("CanHit", true);
                //GameObject.Find("Sword").GetComponent<Animator>().SetTrigger("swordHit");
                StartCoroutine(hitDelay());
            }

        }
    }

    IEnumerator hitDelay()
    {
        yield return new WaitForSeconds(0.2f);
        isHitting = false;
        Debug.Log(isHitting);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "interact")
        {
            Debug.Log("Taalla");
        }
    }
}

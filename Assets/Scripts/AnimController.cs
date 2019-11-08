using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    Animator animator;
    public int condition;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void idleAnimation()
    {
        condition = 0;
        //Debug.Log("Pysähtyy");
        animator.SetInteger("condition", condition);
    }
    public void walkAnimation()
    {
        condition = 1;
        animator.SetInteger("condition", condition);
    }
    public void swingAnimation()
    {
        condition = 2;
        animator.SetInteger("condition", condition);
    }
    public void deadAnimation(){
        condition = 3;
        animator.SetInteger("condition", condition);
    }
}

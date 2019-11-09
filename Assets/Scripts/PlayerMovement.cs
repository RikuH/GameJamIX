using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float TurnSpeed;

    public int health = 3;

    bool iceGround = true;
    Rigidbody rb;

    bool canTakeDamage = true;

    [SerializeField] AnimController animations;

    public Collider hitCollider;
    public Boss Boss;
    public bool bootLegHitReg;

    public audioController soundOfMusic;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hitCollider.isTrigger = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health <= 0 || Input.GetKeyDown(KeyCode.K))
        {
            //GGwww
            soundOfMusic.playDeathSound();
            animations.deadAnimation();
            //Time.timeScale = 0;
        }
        else
        {

            Move();
            LookAtCamera();
            checkHit();
        }


    }

    void Move()
    {

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
            animations.walkAnimation();
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position -= Vector3.forward * Time.deltaTime * moveSpeed;
            animations.walkAnimation();
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += Vector3.left * Time.deltaTime * moveSpeed;
            animations.walkAnimation();
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position -= Vector3.left * Time.deltaTime * moveSpeed;
            animations.walkAnimation();
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            animations.idleAnimation();
        }

    }

    void checkHit()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bootLegHitReg = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            bootLegHitReg = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (bootLegHitReg)
        {
            if (other.transform.tag == "Boss")
            {

                Boss.takeHit();
            }
        }
    }


    void LookAtCamera()
    {
        // Generate a plane that intersects the transform's position with an upwards normal.
        Plane playerPlane = new Plane(Vector3.up, transform.position);

        // Generate a ray from the cursor position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Determine the point where the cursor ray intersects the plane.
        // This will be the point that the object must look towards to be looking at the mouse.
        // Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
        //   then find the point along that ray that meets that distance.  This will be the point
        //   to look at.
        float hitdist = 0.0f;
        // If the ray is parallel to the plane, Raycast will return false.
        if (playerPlane.Raycast(ray, out hitdist))
        {
            // Get the point along the ray that hits the calculated distance.
            Vector3 targetPoint = ray.GetPoint(hitdist);

            // Determine the target rotation.  This is the rotation if the transform looks at the target point.
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, TurnSpeed * Time.deltaTime);
        }
    }

    public IEnumerator PlayerTakeDamage()
    {
        health--;
        canTakeDamage = false;
        Debug.Log(health);

        yield return new WaitForSeconds(1);
        canTakeDamage = true;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Enemy")
        {
            if (canTakeDamage)
            {
                this.transform.position -= Vector3.forward * Time.deltaTime * moveSpeed * 20;
                StartCoroutine(PlayerTakeDamage());
            }
        }
        if (col.transform.tag == "SpikesLeft")
        {
            if (canTakeDamage)
            {
                this.transform.position -= Vector3.left * Time.deltaTime * moveSpeed * 20;
                StartCoroutine(PlayerTakeDamage());
            }
        }
        if (col.transform.tag == "SpikesRight")
        {
            if (canTakeDamage)
            {
                this.transform.position += Vector3.left * Time.deltaTime * moveSpeed * 20;
                StartCoroutine(PlayerTakeDamage());
            }
        }
        if (col.transform.tag == "SpikesTop")
        {
            if (canTakeDamage)
            {
                this.transform.position -= Vector3.forward * Time.deltaTime * moveSpeed * 20;
                StartCoroutine(PlayerTakeDamage());
            }
        }
    }

    void OnCollisionStay(Collision col)
    {
        //Debug.Log(col.transform.tag);
        if (col.transform.tag == "rightConvoyer")
        {
            if (canTakeDamage)
            {
                Debug.Log("Right");
                this.transform.position -= Vector3.left * Time.deltaTime * moveSpeed * 2;
            }

        }
        if (col.transform.tag == "leftConvoy")
        {
            if (canTakeDamage)
            {
                Debug.Log("Left");
                this.transform.position += Vector3.left * Time.deltaTime * moveSpeed * 2;
            }
        }
    }

}

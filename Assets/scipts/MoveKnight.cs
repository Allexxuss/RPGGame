using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKnight : MonoBehaviour
{

    CharacterController player;

    public float speed = 3.0f, gravity = 1008f;
    private bool walk = false, attack = false, run = false;

    Animator animator;
    Rigidbody rigcoll;

    // Use this for initialization
    void Start()
    {
        player = this.GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        //rigcoll = GetComponent<Rigidbody>;
        //rigcoll.useGravity = true;

    }


    void OnCollisionEnter(Collision collision)
    {
        // Debug-draw all contact points and normals
    }



    // Update is called once per frame
    void Update()
    {
        Movement();
        GetInput();
    }

    void Movement()
    {
        if (attack)
            return;

        float AD = Input.GetAxis("Horizontal");
        float WS = Input.GetAxis("Vertical");
        if (WS != 0)
        {
            walk = true;
            //animator.SetBool("running", true);
            animator.SetInteger("condition", 1);
            //if(run)
        }
		else
        {
            animator.SetInteger(name: "condition", value: 0);
            walk = false;
            //animator.SetBool("running", false);
        }
        var horizontalMovement = transform.TransformDirection(new Vector3(AD, 0, 0));
        var forwardMovement = new Vector3(0, 0, WS);
        forwardMovement = transform.TransformDirection(forwardMovement);
        var gravityMovement = new Vector3(0, -gravity * Time.deltaTime, 0);

        player.Move(motion: (horizontalMovement + forwardMovement + gravityMovement) * speed * Time.deltaTime);
    }


    void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (walk/*animator.GetBool("running") == true*/)
            {
                walk = false;
                //animator.SetBool("running", false);
                animator.SetInteger("condition", 0);
            }
            if (walk == false/*animator.GetBool("running") == false */)
            {
                Attacking();
            }

        }
    }

    void Attacking()
    {
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        attack = true;
        //animator.SetBool("attacking", true);
        animator.SetTrigger("attack");
        yield return new WaitForSeconds(1);
        //animator.SetInteger("condition", 2);
        attack = false;
        //animator.SetBool("attacking", false);
    }
}


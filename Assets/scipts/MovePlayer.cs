using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

	CharacterController player;
	public float speed = 3.0f, runspeed;
	Vector3 moveDerection = Vector3.zero;
	Animator animator;

	private bool flag = true;

	// Use this for initialization
	void Start () {
		player = this.GetComponent<CharacterController> ();
		animator = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		runspeed = speed * 0.7f;
			float AD = Input.GetAxis ("Horizontal");
			float WS = Input.GetAxis ("Vertical");
			/*moveDerection = new Vector3 (AD, 0, WS);
			moveDerection = transform.TransformDirection (moveDerection);
			moveDerection *= speed;
			player.Move (moveDerection * Time.deltaTime);
			*/
			if (AD != 0)
			{
				//transform.Rotate(0f, AD * speed, 0f);
				//moveDerection = new Vector3 (AD, 0, 0);
				moveDerection = transform.TransformDirection (new Vector3 (AD, 0, 0));
				moveDerection *= speed;
				player.Move (moveDerection * Time.deltaTime);

			}
			//var pos = moveDerection;
			if(WS != 0)
			{
				//	var pos = moveDerection;
				//Vector3 moveDerection2 = Vector3.zero;
				moveDerection = new Vector3 (0, 0, WS);			
				moveDerection = transform.TransformDirection (moveDerection);
				/* if(Input.GetKeyDown(KeyCode.LeftShift) && flag)
				{
					player.Move (moveDerection * runspeed * Time.deltaTime);
					animator.SetBool ("Run", true);
					flag = false;
				}
				else
				{
					flag = true;
				}
				if(flag)
				{
					player.Move (moveDerection * speed * Time.deltaTime);
					animator.SetBool ("Walk", true);
				}
				*/
				if(Input.GetKey(KeyCode.LeftShift))
				{
					player.Move (moveDerection *runspeed * Time.deltaTime);
					animator.SetBool ("Run", true);
				}
				else
				{	
					animator.SetBool ("Run", false);
				}
				player.Move (moveDerection * speed * Time.deltaTime);
				animator.SetBool ("Walk", true);						
				//player.Move (moveDerection * Time.deltaTime);
				//var speed2 = player.velocity.magnitude;
				//Debug.Log(pos);
				//var pos2 = moveDerection;
				//animator.SetBool ("Walk", true);
			}
			else
			{
				animator.SetBool ("Walk", false);
			}
			


			/*
			if(Input.GetKeyDown(KeyCode.Space))
			{
				
				if (flag) {
					animator.SetBool ("Walk", true);
					flag = !flag;
				} else
				{
					animator.SetBool ("Walk", false);
					flag = !flag;

				}
					
			}
			*/
				
	}
}

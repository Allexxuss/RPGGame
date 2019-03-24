using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

	CharacterController MyPownBody;

    public GameObject player;

	float moveY, moveX;
	public float sensY = 10, sensX = 5;
	/*private Vector2 MinMax_Y = new Vector2(-360,360),
					MinMax_X = new Vector2 (-360,360);*/
	private float Distance;
	private float MinDistance = 1, MaxDistance = 6, speedScroll = 2;


    static float ClampAngle (float angle, float min, float max)
	{
		if(angle < 360) 
			angle += 360;
		if (angle > 360)
			angle -= 360;
		return Mathf.Clamp (angle, min, max);
	}
	// Use this for initialization
	void Start () {

		MyPownBody = this.GetComponent<CharacterController> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(MyPownBody)
		{
			moveY -= Input.GetAxis ("Mouse Y") * sensY;
			//moveY = ClampAngle (moveY, MinMax_Y.x, MinMax_Y.y);

			moveX += Input.GetAxis ("Mouse X") * sensX;

			//moveX = ClampAngle (moveX, MinMax_X.x, MinMax_X.y);

		//	MyPownBody.transform.rotation = Quaternion.Euler (moveY, moveX, 0);

			transform.RotateAround (player.transform.position, transform.up, moveX*Time.deltaTime);
			transform.RotateAround (player.transform.position, transform.right, moveY*Time.deltaTime);

			transform.rotation = Quaternion.LookRotation (player.transform.position - transform.position);
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, 0);
			
		}
		if(Input.GetAxis("Mouse ScrollWheel") != 0)
		{
			Distance = Vector3.Distance (transform.position, player.transform.position);
			if (Input.GetAxis ("Mouse ScrollWheel") > 0 && Distance > MinDistance) 
			{
				transform.Translate (Vector3.forward * Time.deltaTime * speedScroll);
			}
			if (Input.GetAxis ("Mouse ScrollWheel") < 0 && Distance < MinDistance) 
			{
				transform.Translate (Vector3.forward * Time.deltaTime * -speedScroll);
			}
		}





		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	public float sensativeX = 3f, sensativeY = 3f;
	public float minX = -360, minY = -60, maxX = 360, maxY = 60;

	private Quaternion originalRot;
	private float rotX = 0, rotY = 0;
	
	void Start () {
		Rigidbody RB = GetComponent<Rigidbody>();
		if(RB)
			RB.freezeRotation = true;
		
		originalRot = transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
		rotX += Input.GetAxis("Mouse X") * sensativeX;
		rotY += Input.GetAxis("Mouse Y") * sensativeY;

		rotX %= 360;
		rotY %= 360;
		
		rotX = Mathf.Clamp(rotX,minX,maxX);
		rotY = Mathf.Clamp(rotY,minY,maxY);

		Quaternion xQuaternion = Quaternion.AngleAxis(rotX,Vector3.up);
		Quaternion yQuaternion = Quaternion.AngleAxis(rotY,Vector3.left);

		transform.localRotation = originalRot * xQuaternion * yQuaternion;
		
	}
}

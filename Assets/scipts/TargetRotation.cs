using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotation : MonoBehaviour {

	public Transform PosTarget;
	public float turnSpeed;

	// Update is called once per frame
	void Update () {
		/*
		Vector3 dir = PosTarget.position - transform.position;
		dir.y = 0;
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (dir), turnSpeed * Time.deltaTime);
		Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
		PosTarget.position = ray.GetPoint (15);
		 */

	}
}

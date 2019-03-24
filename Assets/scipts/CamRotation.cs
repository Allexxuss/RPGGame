using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotation : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform PosTarget;
   // Camera m_MainCamera;
    

    // void Start()
    // {
    //     //This gets the Main Camera from the Scene
    //     m_MainCamera = Camera.main;
    //     //This enables Main Camera
    //     m_MainCamera.enabled = true;
    //     //Use this to disable secondary Camera
    //     m_CameraTwo.enabled = false;
    // }
	public float turnSpeed;

	// Update is called once per frame
	void Update () {
		Vector3 dir = PosTarget.position - transform.position;
		dir.y = 0;
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (dir), turnSpeed * Time.deltaTime);
		Ray ray = new Ray (UnityEngine.Camera.main.transform.position, UnityEngine.Camera.main.transform.forward);
		PosTarget.position = ray.GetPoint (15);

	}
}

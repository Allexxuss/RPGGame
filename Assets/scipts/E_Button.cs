using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class E_Button : MonoBehaviour
{
    GameObject canv;
    new UnityEngine.Camera camera;
    void Awake()
    {
        this.camera = UnityEngine.Camera.main;
    }

    private void LateUpdate()
    {
        transform.LookAt(UnityEngine.Camera.main.transform);
        transform.Rotate(0, 180, 0);

    }
}

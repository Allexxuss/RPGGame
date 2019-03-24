using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamTarget : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject player;
    public float distance = 100f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + Vector3.up * distance;
    }
}

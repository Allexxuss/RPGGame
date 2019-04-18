using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnPickUp : MonoBehaviour
{
    public Item item;
    public float minDistance = 4f;
    Inventory inv;
    GameObject player;
    Canvas canv;
    new UnityEngine.Camera camera;
    Vector3 positionOffset;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        this.camera = UnityEngine.Camera.main;
        canv = GetComponentInChildren<Canvas>();
        canv.enabled = false;
        inv = FindObjectOfType<Inventory>();
        positionOffset = Vector3.zero;//gameObject.transform.localPosition;
        positionOffset.y += 1f;
        //positionOffset
    }

    private void LateUpdate()
    {
        if(player != null)
        {
            float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);
            if(distance <= minDistance)
            {
                canv.enabled = true;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    inv.AddItem(item);
                    Destroy(gameObject);
                }
                    
            }
            else
                canv.enabled = false;
        }
        canv.transform.position = canv.transform.parent.position + positionOffset;//positionOffset;
        canv.transform.LookAt(camera.transform);
        canv.transform.Rotate(0, 180, 0);

    }
}

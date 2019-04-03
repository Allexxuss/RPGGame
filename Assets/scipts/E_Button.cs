using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class E_Button : MonoBehaviour
{
    public Item item;
    Inventory inv;
    GameObject player, e_item;
    Canvas canv;
    new UnityEngine.Camera camera;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        e_item = GameObject.FindGameObjectWithTag("Item");
        this.camera = UnityEngine.Camera.main;
        canv = GetComponent<Canvas>();
        canv.enabled = false;
    }

    private void LateUpdate()
    {
        if(player != null)
        {
            float distance = Vector3.Distance(e_item.transform.position, player.transform.position);
            if(distance <= 4f)
            {
                canv.enabled = true;
                if(Input.GetKeyDown(KeyCode.E))
                {
                    inv.AddItem(item);
                    Destroy(e_item);
                }
                    
            }
            else
                canv.enabled = false;
        }
        transform.LookAt(UnityEngine.Camera.main.transform);
        transform.Rotate(0, 180, 0);

    }
}

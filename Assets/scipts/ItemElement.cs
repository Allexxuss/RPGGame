using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemElement : MonoBehaviour
{
    GameObject player, items;
    private Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        items = GameObject.FindGameObjectWithTag("Item");

        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            float distance = Vector3.Distance(items.transform.position, player.transform.position);
            if(distance <= 3f)
            {
                canvas.enabled = true;
                if(Input.GetKeyDown(KeyCode.E))
                    Destroy(items);
            }
            else
                canvas.enabled = false;
        }

    }
}

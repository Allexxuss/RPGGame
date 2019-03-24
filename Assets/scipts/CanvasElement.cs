using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasElement : MonoBehaviour
{

    public float radius = 5f;
    GameObject player, shield;
    private Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shield = GameObject.FindGameObjectWithTag("shield");
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            float distance = Vector3.Distance(shield.transform.position, player.transform.position);
            if(distance <= 3f)
                canvas.enabled = true;
            else
                canvas.enabled = false;
        }

    }
}

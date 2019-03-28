using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoverMiniMap : MonoBehaviour
{
    bool cover;
    private GameObject MiniMap;
    void Awake()
    {
        MiniMap = GameObject.FindWithTag("MiniMap");
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            if(cover)
            {
                MiniMap.SetActive(false);
                cover = !cover;
            }
            else
            {
                MiniMap.SetActive(true);
                cover = !cover;
            }
        }
    }

}

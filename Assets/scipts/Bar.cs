using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    Damagable CurHP;
    private GameObject player;
    private Image HealthIMG;
    private Image Armor0IMG;
    private Image Armor1IMG;
    private Image Armor2IMG;

    void Awake()
    {
        
        //player = GameObject.FindGameObjectWithTag("Player");
        //player = GetComponent<Damagable>().CurrentHp;
        //HealthIMG = transform.Find("HealthBar").Find("bar").GetComponent<Image>();
        // HealthIMG = GameObject.FindGameObjectWithTag("health_bar").GetComponent<Image>();
        // Armor0IMG = transform.Find("ArmorBar0").Find("bar").GetComponent<Image>();
        // Armor1IMG = transform.Find("ArmorBar1").Find("bar").GetComponent<Image>();
        // Armor2IMG = transform.Find("ArmorBar2").Find("bar").GetComponent<Image>();
        
    }

    void Update()
    {
        //HealthIMG.fillAmount = player.Damagable;
    }

}

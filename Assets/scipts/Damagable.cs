using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damagable : MonoBehaviour
{
    private Image HealthIMG;
    public float MaxHp;
    public float CurrentHp { get; set; }
    
    void Awake()
    {
        CurrentHp = MaxHp;
        HealthIMG = GameObject.FindGameObjectWithTag("health_bar").GetComponent<Image>();
    }

    void Update()
    {
        HealthIMG.fillAmount = CurrentHp/100;
    }
    public void DealDamage(float damage)
    {
        CurrentHp -= damage;
        
        if(CurrentHp <= 0)
        {
            Destroy(gameObject);
        }

    }
}

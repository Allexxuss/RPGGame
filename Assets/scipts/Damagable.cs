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
    public float HPFraction {get {return CurrentHp/MaxHp;} }
    
    void Awake()
    {
        CurrentHp = MaxHp;
    }
    public void DealDamage(float damage)
    {
        CurrentHp -= damage;
        
        if(CurrentHp <= 0)
        {
            foreach (var dropItem in GetComponentsInChildren<DropItemOnDestroy>())
                dropItem.OnDamagableDestroy();

            Destroy(gameObject);
        }

    }
}

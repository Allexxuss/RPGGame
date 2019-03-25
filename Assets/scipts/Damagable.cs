using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public float MaxHp;

    public float CurrentHp { get; private set; }

    void Awake()
    {
        CurrentHp = MaxHp;
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

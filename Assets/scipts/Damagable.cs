using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damagable : MonoBehaviour
{
    public GameObject BloodPrefab;
    public float MaxHp;
    public float CurrentHp { get; set; }
    public float HPFraction { get { return CurrentHp / MaxHp; } }
    private Inventory inventory;

    void Awake()
    {
        inventory = GetComponent<Inventory>();
        CurrentHp = MaxHp;
    }

    public void RestoreHp(float hp, bool amulet)
    {
        CurrentHp += hp;
        CurrentHp = Mathf.Clamp(value: CurrentHp, min: 0, max: MaxHp);
        if(amulet)
        {
            StartCoroutine(RestoredHP(hp));
        }
    }

    public void DealDamage(float damage)
    {
        if (inventory && inventory.CurrentShield)
            damage = inventory.CurrentShield.DamageShield(damage);

        CurrentHp -= damage;

        if (CurrentHp <= 0)
        {
            foreach (var dropItem in GetComponentsInChildren<DropItemOnDestroy>())
                dropItem.OnDamagableDestroy();

            Destroy(gameObject);
        }
    }

    IEnumerator RestoredHP(float HPRestored)
    {
        while(true)
        {
            CurrentHp += HPRestored;
            CurrentHp = Mathf.Clamp(value: CurrentHp, min: 0, max: MaxHp);
            yield return new WaitForSeconds(3f);
        }
        

    }
}

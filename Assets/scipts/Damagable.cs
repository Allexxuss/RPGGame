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

    public void RestoreHp(float hp)
    {
        CurrentHp += hp;
        CurrentHp = Mathf.Clamp(value: CurrentHp, min: 0, max: MaxHp);
    }

    public void StartHpRegen(float hpRegen)
    {
        StopAllCoroutines();
        StartCoroutine(RestoredHP(hpRegen));
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

            if (inventory)
                inventory.DropAllItems();

            Destroy(gameObject);
        }
    }

    IEnumerator RestoredHP(float HPRestored)
    {
        while(true)
        {
            RestoreHp(HPRestored);
            yield return new WaitForSeconds(3f);
        }
    }
}

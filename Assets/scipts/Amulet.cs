using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;



[CreateAssetMenu]
public class Amulet : Item
{
    public float HPRestored;

    public override void OnUse(Inventory inventory)
    {
        inventory.EquipItem(this);
        var damagable = inventory.GetComponent<Damagable>();
        damagable.StartHpRegen(HPRestored);
        Debug.Log("Amulet was used");
    }

    
}
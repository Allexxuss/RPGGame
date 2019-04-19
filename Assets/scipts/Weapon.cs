using UnityEngine;

[CreateAssetMenu]
public class Weapon : Item
{
    public float DamageDealt;
    public override void OnUse(Inventory inventory)
    {
        inventory.EquipItem(this);
        inventory.GetComponentInChildren<DamageDealer>().damage = DamageDealt;
        Debug.Log("weapon was used");
    }
} 
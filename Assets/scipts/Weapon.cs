using UnityEngine;

[CreateAssetMenu]
public class Weapon : Item
{
    public float DamageDealt;
    public override void OnUse()
    {
        var inventory = Object.FindObjectOfType<Inventory>();
        inventory.EquipItem(this);
        Debug.Log("weapon was used");
    }
}
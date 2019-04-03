using UnityEngine;

[CreateAssetMenu]
public class Amulet : Item
{
    public float HealthRecovery;
    public override void OnUse()
    {
        var inventory = Object.FindObjectOfType<Inventory>();
        inventory.EquipItem(this);
        Debug.Log("Amulet was used");
    }
}
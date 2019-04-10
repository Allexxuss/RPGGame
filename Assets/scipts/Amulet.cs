using UnityEngine;

[CreateAssetMenu]
public class Amulet : Item
{
    public float HealthRecovery;

    public override void OnUse(Inventory inventory)
    {
        inventory.EquipItem(this);
        Debug.Log("Amulet was used");
    }
}
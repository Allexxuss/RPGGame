using UnityEngine;

[CreateAssetMenu]
public class Shield : Item
{
    [Range(1, 3)]
    public int ShieldPoints = 1;

    public override void OnUse()
    {
        var inventory = Object.FindObjectOfType<Inventory>();
        inventory.EquipItem(this);
        Debug.Log("Shield was used");
    }
}
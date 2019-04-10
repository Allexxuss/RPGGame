using UnityEngine;

[CreateAssetMenu]
public class Potion : Item
{
    public float HPRestored;
    public float ShieldRestored;

    public override void OnUse(Inventory inventory)
    {
        var damagable = inventory.GetComponent<Damagable>();
        damagable.RestoreHp(HPRestored);

        if (inventory.CurrentShield != null)
            inventory.CurrentShield.RestoreShield(ShieldRestored);
    }
}
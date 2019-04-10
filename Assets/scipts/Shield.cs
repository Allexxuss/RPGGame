using UnityEngine;

[CreateAssetMenu]
public class Shield : Item
{
    [Range(1, 3)]
    public int ShieldPoints = 1;

    public float ShieldHpPerPoint = 50f;

    public float CurrentShieldHp { get; set; } = 0;

    public float TotalShieldHpPoints => ShieldPoints * ShieldHpPerPoint;

    void OnEnable()
    {
        CurrentShieldHp = TotalShieldHpPoints;
    }

    public void RestoreShield(float hp)
    {
        CurrentShieldHp += hp;
        CurrentShieldHp = Mathf.Clamp(value: CurrentShieldHp, min: 0, max: TotalShieldHpPoints);
    }

    public float DamageShield(float damage)
    {
        float unblockedDamage = Mathf.Clamp(damage - CurrentShieldHp, 0, damage);
        CurrentShieldHp -= damage;
        CurrentShieldHp = Mathf.Clamp(value: CurrentShieldHp, min: 0, max: TotalShieldHpPoints);
        return unblockedDamage;
    }

    public override void OnUse(Inventory inventory)
    {
        inventory.EquipItem(this);
        var armorUI = Object.FindObjectOfType<ArmorUI>();
        armorUI.UpdateArmorPoints(ShieldPoints);
        Debug.Log("Shield was used");
    }
}
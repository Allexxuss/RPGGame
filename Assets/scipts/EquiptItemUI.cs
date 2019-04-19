using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquiptItemUI : MonoBehaviour
{
    public enum EquipmentType { Weapon, Shield, Amulet }

    public EquipmentType type;
    Inventory inventory;

    void Update()
    {
        if (!inventory)
            inventory = FindObjectOfType<Inventory>();

        var image = GetComponent<Image>();
        if (type == EquipmentType.Weapon)
        {
            var item = inventory.CurrentWeapon;
            image.sprite = item?.Sprite;
        }
        if (type == EquipmentType.Shield)
        {
            var item = inventory.CurrentShield;
            image.sprite = item?.Sprite;
        }
        if (type == EquipmentType.Amulet)
        {
            var item = inventory.CurrentAmulet;
            image.sprite = item?.Sprite;
        }
        

        image.enabled = image.sprite != null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string itemDesc;
    public GameObject droppedLootPrefab;
    public int itemPower;
    public Sprite Sprite;

    public virtual void OnUse(Inventory inventory)
    {
        
    }

    public virtual void OnPickUp()
    {
        
    }

    void OnValidate()
    {
        if (droppedLootPrefab == null)
            Debug.LogError($"Item {this} has no droppedLootPrefab", this);
    }

    public string GetTooltipDescription()
    {
        return $"<color=#000000>{name}</color>\n\n{itemDesc}\n\n<color=#000000>Power:</color><color=#e52b2b> {itemPower}</color>";
    }
}

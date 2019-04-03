using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string itemDesc;
    public int itemID;
    public int itemPower;
    public int itemSpeed;
    public Sprite Sprite;

    public virtual void OnUse()
    {
        
    }

    public virtual void OnPickUp()
    {
        
    }

    public string GetTooltipDescription()
    {
        return $"<color=#000000>{name}</color>\n\n{itemDesc}\n\n<color=#000000>Power:</color><color=#e52b2b> {itemPower}</color>";
    }
}

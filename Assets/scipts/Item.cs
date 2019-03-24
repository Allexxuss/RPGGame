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
    public ItemType itemType;

    public Sprite Sprite;

    public enum ItemType
    {
        Weapon,
        Consumable,
        Quest
    }

    public virtual void OnUse()
    {
        
    }


    // public Item(string name, int id, string desc, int power, int speed, ItemType type)
    // {
    //     this.itemName = name;
    //     this.itemDesc = desc;
    //     this.itemID = id;
    //     //this.itemIcon = Resources.Load<Texture2D>("Item Icons/" + itemName);
    //     this.itemPower = power;
    //     this.itemSpeed = speed;
    //     this.itemType = type;
    //     this.Sprite = Resources.Load<Sprite>("Sprites/Item Icons/" + itemName);
    // }




    // public Item()
    // {
    //     this.itemID = -1;
    // }


}

[CreateAssetMenu]
public class Potion : Item
{
    public float hpRestored;
    public override void OnUse()
        => Debug.Log("potion was used");
}
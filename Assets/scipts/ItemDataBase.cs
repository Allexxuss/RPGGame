using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemDataBase : MonoBehaviour
{
    public List<Item> items = new List<Item>();


    public Item FetchItemByID(int id)
    {   
        for(int i = 0; i < items.Count; i++)
            if(items[i].itemID == id)
                return items[i];
        return null;
    }
    // public Item FetchItemByID(int id) => items.First(x => x.itemID == id);


    // void Awake()
    // {
    //     items.Add(new Item("Amulet of Player", 0, "An amulet enchanted by players",2,0, Item.ItemType.Weapon));
    //     items.Add(new Item("Shield of Player", 1, "Shield of Player",5,0, Item.ItemType.Consumable));
    //     items.Add(new Item("Shied Potion", 2, "That potion increases your shield",0,0, Item.ItemType.Consumable));
    // }
}
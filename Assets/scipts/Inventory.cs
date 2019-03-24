using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    GameObject InventoryPanel;
    GameObject SlotPanel;
    public GameObject InventorySlot;
    public GameObject InventoryItem;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();
    int slotAmount;
    void Start()
    {
        slotAmount = 12;
        InventoryPanel = GameObject.Find("Inventory Panel");
        SlotPanel = InventoryPanel.transform.FindChild("Slot Panel").gameObject;

        for (int i = 0; i < slotAmount; i++)
        {
            slots.Add(Instantiate(InventorySlot));
            slots[i].transform.SetParent(SlotPanel.transform);
            GameObject itemObj = Instantiate(InventoryItem);
            itemObj.transform.SetParent(slots[i].transform);
            itemObj.transform.position = Vector2.zero;
        }

        RefreshInventoryDisplay();
    }

    public bool AddItem(Item item)
    {
        if (items.Count >= slots.Count)
            return false;
        // var potion = ScriptableObject.CreateInstance<Potion>();
        items.Add(item);
        RefreshInventoryDisplay();
        return true;
    }

    public void UseItem(Item item)
    {
        items.Remove(item);
        RefreshInventoryDisplay();
        item.OnUse();
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        RefreshInventoryDisplay();
    }

    [ContextMenu("Refresh")]
    void RefreshInventoryDisplay()
    {
        for (int i = 0; i < items.Count; ++i)
        {
            var item = items[i];
            var slot = slots[i].transform.GetChild(0);
            if (item != null)
            {
                slot.name = item.name;
                slot.GetComponent<Image>().enabled = true;
                slot.GetComponent<Image>().sprite = item.Sprite;
            }
            else
            {
                slot.name = "empty";
                slot.GetComponent<Image>().enabled = false;
            }
        }
    }

}


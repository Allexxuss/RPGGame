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
    public Weapon CurrentWeapon;
    public Shield CurrentShield;
    public Amulet CurrentAmulet;
    public GameObject InventorySlot;
    public GameObject InventoryItem;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();
    private GameObject ShowInv;
    int slotAmount;
    bool ShowInventory;
    void Start()
    {
        slotAmount = 12;
        InventoryPanel = GameObject.Find("Inventory Panel");
        SlotPanel = InventoryPanel.transform.Find("Slot Panel").gameObject; 
        ShowInv = GameObject.FindGameObjectWithTag("InventoryUI");
        for (int i = 0; i < slotAmount; i++)
        {
            slots.Add(Instantiate(InventorySlot));
            slots[i].transform.SetParent(SlotPanel.transform);
            GameObject itemObj = Instantiate(InventoryItem);
            itemObj.transform.SetParent(slots[i].transform);
            itemObj.transform.position = Vector2.zero;
        }
        ShowInv.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ShowInventory = !ShowInventory;
            ShowInv.SetActive(ShowInventory);
            RefreshInventoryDisplay();
        }
        else
            return;
        //ShowInventory();
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
        item.OnUse();
        RefreshInventoryDisplay();
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        RefreshInventoryDisplay();
    }

    [ContextMenu("Refresh")]
    void RefreshInventoryDisplay()
    {
        for (int i = 0; i < slots.Count; ++i)
        {
            Item item = null;
            if (i < items.Count)
                item = items[i];

            var sprite = slots[i].transform.GetChild(0);
            if (item != null)
            {
                sprite.name = item.name;
                sprite.GetComponent<Image>().enabled = true;
                sprite.GetComponent<Image>().sprite = item.Sprite;
                sprite.parent.GetComponent<Tooltip>().CurrentItem = item;
            }
            else
            {
                sprite.name = "empty";
                sprite.GetComponent<Image>().enabled = false;
                sprite.parent.GetComponent<Tooltip>().CurrentItem = null;
            }
        }
    }


    public void EquipItem(Item item)
    {
        if (item is Weapon)
        {
            AddItem(CurrentWeapon);
            CurrentWeapon = item as Weapon;
        }
        if (item is Shield)
        {
            AddItem(CurrentShield);
            CurrentShield = item as Shield;
        }
        if (item is Amulet)
        {
            AddItem(CurrentAmulet);
            CurrentAmulet = item as Amulet;
        }
    }

}


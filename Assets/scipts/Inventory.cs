using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Weapon CurrentWeapon;
    public Shield CurrentShield;
    public Amulet CurrentAmulet;
    public GameObject InventorySlot;
    public GameObject InventoryItem;
    public List<Item> items = new List<Item>();
    int slotAmount;
    bool ShowInventory;
    public static List<GameObject> slots = new List<GameObject>();
    private static GameObject InventoryPanel;
    private static GameObject SlotPanel;
    private static GameObject ShowInv;

    void Start()
    {
        slotAmount = 12;

        if (!InventoryPanel)
            InventoryPanel = GameObject.Find("Inventory Panel");
        if (!SlotPanel)
            SlotPanel = InventoryPanel.transform.Find("Slot Panel").gameObject; 
        if (!ShowInv)
            ShowInv = GameObject.FindGameObjectWithTag("InventoryUI");

        if (slots.Count != slotAmount)
        {
            for (int i = 0; i < slotAmount; i++)
            {
                slots.Add(Instantiate(InventorySlot));
                slots[i].transform.SetParent(SlotPanel.transform);
                GameObject itemObj = Instantiate(InventoryItem);
                itemObj.transform.SetParent(slots[i].transform);
                itemObj.transform.position = Vector2.zero;
            }
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
        item.OnUse(this);
        RefreshInventoryDisplay();
    }

    public void DropItem(Item item)
    {
        items.Remove(item);
        RefreshInventoryDisplay();
        var instance = Instantiate(item.droppedLootPrefab, transform.position + transform.forward * 0.5f + transform.up * 0.3f, Random.rotation);
        instance.GetComponent<OnPickUp>().item = item;
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

    public void DropAllItems()
    {
        foreach (var item in items.ToArray())
            DropItem(item);
    }

    void OnValidate()
    {
        if (InventorySlot == null || InventoryItem == null)
            Debug.LogError("Inventory is not set up");
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


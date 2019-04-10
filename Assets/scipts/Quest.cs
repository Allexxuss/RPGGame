using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public QuestItem requiredItem;
    public int amount = 3;
    public UnityEvent @event;
    Inventory inventory;

    void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    void Update()
    {
        if (inventory.items.Count(x => x == requiredItem) >= amount)
        {
            enabled = false;
            for (int i = 0; i < amount; ++i)
                inventory.RemoveItem(requiredItem);

            @event.Invoke();
        }
    }
    
}

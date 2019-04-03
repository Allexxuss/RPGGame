using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public QuestItem requiredItem;
    public int ammount;
    public UnityEvent @event;
    Inventory inventory;

    void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    void Update()
    {
        if (inventory.items.Count(x => x == requiredItem) > ammount)
        {
            enabled = false;
            @event.Invoke();
        }
    }
    
}

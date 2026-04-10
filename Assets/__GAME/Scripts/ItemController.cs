using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Item
{
    public string name;
    public string description;
    public int weight;
}

public class InventorySlot
{
    public string itemName;
    public int count;
}

public class ItemController : MonoBehaviour
{
    public List<Item> itemList;
    public Dictionary<int, InventorySlot> inventory;

    public void AddItem(string itemName, int count)
    {
        InventorySlot slot = null;
        foreach (InventorySlot s in inventory.Values)
        {
            if (s.itemName != itemName) 
                continue;

            slot = s;
            break;
        }

        if (slot == null)
        {
            slot = new InventorySlot() 
            { 
                itemName = itemName, 
                count = count
            };

            inventory.Add(inventory.Count, slot);
        }
        else
        {
            slot.count += count;
        }
    }

    public void RemoveItem(string itemName, int count)
    {
        if (GetItemCount(itemName) < count)
            return;

        foreach (InventorySlot slot in inventory.Values)
        {
            if (slot.itemName != itemName)
                continue;

            slot.count -= count;
            break;
        }

    }

    public int GetItemCount(string itemName)
    {
        int totalCount = 0;
        foreach (InventorySlot slot in inventory.Values)
        {
            if (slot.itemName != itemName) 
                continue;

            totalCount += slot.count;
        }

        return totalCount;
    }

}

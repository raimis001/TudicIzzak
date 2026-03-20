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

    }

    public void RemoveItem(string itemName, int count)
    {

    }

    public int GetItemCount(string itemName)
    {
        return 0;
    }

}

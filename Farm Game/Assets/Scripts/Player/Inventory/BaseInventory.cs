using Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInventory : MonoBehaviour
{
    const int maxItems = 32;

    public List<InventoryMenuItem> items;
    protected InventoryItemHolder inventoryItemHolder;

    protected int FindItemIndex(InventoryItem item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemType == item) { return i; }
        }

        return -2; //using -2 as representation of null
    }

    public void AddItem(InventoryItem item)
    {
        int index = FindItemIndex(item);

        //if already has any of item then increase quantity
        if (index != -2) //if index isnt 'null' then has item
        {
            items[index].quantity++;
        }
        //otherwise add item to items
        else
        {
            InventoryMenuItem newMenuItem = new(item);
            if (items.Count < maxItems) { items.Add(newMenuItem); }
        }

        inventoryItemHolder.UpdateItems(items);
    }

    public void RemoveItem(InventoryMenuItem menuItem)
    {
        int index = FindItemIndex(menuItem.itemType);
        items[index].quantity--;
        if (items[index].quantity <= 0) { items.RemoveAt(index); }

        inventoryItemHolder.UpdateItems(items);
    }

    public InventoryMenuItem RemoveItemAndReturn(InventoryMenuItem menuItem)
    {
        bool hasAnyLeft = true;

        int index = FindItemIndex(menuItem.itemType);
        items[index].quantity--;
        if (items[index].quantity <= 0) { items.RemoveAt(index); hasAnyLeft = false; }

        inventoryItemHolder.UpdateItems(items);

        return hasAnyLeft ? items[index] : null;
    }
}
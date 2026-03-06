using Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    const int maxItems = 32;

    private List<InventoryMenuItem> items;
    private InventoryMenuItem heldItem;

    private Menu inventoryMenu;
    private InventoryItemHolder inventoryItemHolder;

    private void SetInventoryMenus()
    {
        inventoryMenu = UIManager.Instance.FindMenuByName("inventory");
        inventoryItemHolder = inventoryMenu.GetComponentInChildren<InventoryItemHolder>(true);
    }


    private void Start()
    {
        items = new List<InventoryMenuItem>();
        Invoke(nameof(SetInventoryMenus), 0.5f);
    }

    private void OnEnable()
    {
        Player.Instance.input.actions["UseItem"].performed += UseHeldItem;
    }

    private void OnDisable()
    {
        Player.Instance.input.actions["UseItem"].performed -= UseHeldItem;
    }


    private int FindItemIndex(InventoryItem item)
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
            if(items.Count < maxItems) { items.Add(newMenuItem); }
        }

        inventoryItemHolder.UpdateItems(items);
    }

    public void RemoveItem(InventoryMenuItem menuItem)
    {
        ////remove current status of helditem from items
        //items.Remove(menuItem);

        ////decrease quantity of held item since used 1
        //menuItem.quantity--;

        ////if quantity is 1 or more then readd to items
        //if (menuItem.quantity >= 1) { items.Add(menuItem); }
        ////otherwise stop holding item since we don't have any of it left
        //else { menuItem = null; }

        int index = FindItemIndex(menuItem.itemType);
        items[index].quantity--;
        if (items[index].quantity <= 0) { items.RemoveAt(index); }

        inventoryItemHolder.UpdateItems(items);
    }


    public void SetHeldItem(InventoryMenuItem menuItem)
    {
        heldItem = menuItem;
    }

    //runs when use item input is pressed
    public void UseHeldItem(InputAction.CallbackContext context)
    {
        Debug.Log(heldItem.itemType.Name.ToString());

        if (heldItem == null) { return; } //no held item so nothing happens

        //if not currently in menu then proceed
        if(UIManager.Instance.currentMenu == null)
        {
            if (heldItem.itemType.GetType() == typeof(Crop))
            {
                if (Player.Instance.farming.PlantSeed((Crop)heldItem.itemType))
                {
                    RemoveItem(heldItem);
                    //plant seed animation
                }
            }
        }
    }
}

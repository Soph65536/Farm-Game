using Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    private List<InventoryMenuItem> items;
    private InventoryMenuItem heldItem;

    private Menu inventoryMenu;
    private void SetInventoryMenu() { inventoryMenu = UIManager.Instance.FindMenuByName("inventory"); }

    private void Start()
    {
        SetInventoryMenu();
    }

    private void OnEnable()
    {
        Player.Instance.input.actions["UseItem"].performed += UseHeldItem;
    }

    private void OnDisable()
    {
        Player.Instance.input.actions["UseItem"].performed -= UseHeldItem;
    }

    //runs when use item control is pressed
    public void UseHeldItem(InputAction.CallbackContext context)
    {
        if (heldItem == null) { return; } //no held item so nothing happens

        if(heldItem.GetType() == typeof(Crop))
        {
            if (Player.Instance.farming.PlantSeed((Crop)heldItem.itemType)) 
            { 
                RemoveHeldItem(); 
                //plant seed animation
            }
        }
    }

    private void RemoveHeldItem()
    {
        if(heldItem != null)
        {
            //remove current status of helditem from items
            items.Remove(heldItem);

            //decrease quantity of held item since used 1
            heldItem.quantity--;

            //if quantity is 1 or more then readd to items
            if(heldItem.quantity >= 0) { items.Add(heldItem); }
            //otherwise stop holding item since we don't have any of it left
            else { heldItem = null; }
        }
    }
}

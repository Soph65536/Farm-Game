using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    private List<InventoryItem> items;
    private InventoryItem heldItem;

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
            if (Player.Instance.farming.PlantSeed((Crop)heldItem)) 
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
            items.Remove(heldItem);
            heldItem = null;
        }
    }
}

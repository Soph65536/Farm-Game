using Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : BaseInventory
{
    const int maxItems = 32;

    private InventoryMenuItem heldItem;
    private Menu inventoryMenu;

    private HUD hud;

    private void SetInventoryMenus()
    {
        inventoryMenu = UIManager.Instance.FindMenuByName("inventory");
        inventoryItemHolder = inventoryMenu.GetComponentInChildren<InventoryItemHolder>(true);
        hud = Player.Instance.hud.GetComponent<HUD>();
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


    public void SetHeldItem(InventoryMenuItem menuItem)
    {
        heldItem = menuItem;
        hud.UpdateHeldItem(menuItem == null? null : menuItem.itemType.Sprite);
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
                    SetHeldItem(null);
                    //plant seed animation
                }
            }
        }
    }
}

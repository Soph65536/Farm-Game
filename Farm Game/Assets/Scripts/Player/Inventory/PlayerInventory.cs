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

    private void SetUIRefs()
    {
        inventoryMenu = UIManager.Instance.FindMenuByName("inventory");
        inventoryItemHolder = inventoryMenu.GetComponentInChildren<InventoryItemHolder>(true);
        hud = Player.Instance.hud.GetComponent<HUD>();

        Player.Instance.input.actions["UseItem"].performed += UseHeldItem;
    }


    private void Start()
    {
        items = new List<InventoryMenuItem>();
        Invoke(nameof(SetUIRefs), 0.5f);
    }

    private void OnEnable()
    {
        Player.Instance.input.actions["UseItem"].performed += UseHeldItem;
    }

    private void OnDisable()
    {
        Player.Instance.input.actions["UseItem"].performed -= UseHeldItem;
    }


    public bool CheckForItem(InventoryItem item)
    {
        return FindItemIndex(item) != -2;
    }

    public bool SetHeldItem(InventoryMenuItem menuItem)
    {
        if (Player.Instance.farmTeleport.inFarm)
        {
            heldItem = menuItem;
            hud.UpdateHeldItem(menuItem);
            return true;
        }
        return false;
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
                    SetHeldItem(RemoveItemAndReturn(heldItem)); //remove 1 of item and then set held item to updated version of item
                    //plant seed animation
                }
            }
        }
    }
}

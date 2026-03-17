using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MerchantItemButton : InventoryItemButton
{
    //merchant functions
    public void Sell()
    {
        StatManager.Instance.ChangeMoney(menuItem.itemType.Value);
        Player.Instance.inventory.RemoveItem(menuItem);
        MerchantMenu.Instance.currentMerchant.AddItem(menuItem.itemType);

        MerchantMenu.Instance.UpdateInventoryHolders();
    }

    public void Buy()
    {
        StatManager.Instance.ChangeMoney(-menuItem.itemType.Value);
        Player.Instance.inventory.AddItem(menuItem.itemType);
        MerchantMenu.Instance.currentMerchant.RemoveItem(menuItem);

        MerchantMenu.Instance.UpdateInventoryHolders();
    }
}

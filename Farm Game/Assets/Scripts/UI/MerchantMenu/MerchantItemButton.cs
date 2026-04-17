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

        AudioManager.Instance.PlayAudio(false, Player.Instance.audioSource, "sesellitem");

        MerchantMenu.Instance.UpdateInventoryHolders();
    }

    public void Buy()
    {
        if (StatManager.Instance.money < menuItem.itemType.Value) 
        {
            AudioManager.Instance.PlayAudio(false, Player.Instance.audioSource, "sebuzzer");
            return; 
        }

        StatManager.Instance.ChangeMoney(-menuItem.itemType.Value);
        Player.Instance.inventory.AddItem(menuItem.itemType);
        MerchantMenu.Instance.currentMerchant.RemoveItem(menuItem);

        AudioManager.Instance.PlayAudio(false, Player.Instance.audioSource, "sebuyitem");

        MerchantMenu.Instance.UpdateInventoryHolders();
    }
}

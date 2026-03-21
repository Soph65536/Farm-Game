using Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantInventory : BaseInventory
{
    [SerializeField] private InventoryItem[] itemsToAdd;

    private void Start()
    {
        items = new List<InventoryMenuItem>();
        inventoryItemHolder = MerchantMenu.Instance.merchantItems;

        Invoke(nameof(AddInventoryItems), 0.5f);
    }

    private void AddInventoryItems()
    {
        foreach (InventoryItem item in itemsToAdd) { AddItem(item); }
    }

    public void InvokeMerchantMenu(float delay)
    {
        Invoke(nameof(EnterMerchantMenu), delay);
    }

    public void EnterMerchantMenu()
    {
        //set merchant to this then open the merchant menu
        MerchantMenu.Instance.SetMerchant(this);
        UIManager.Instance.EnterMenu("merchant");
    }
}

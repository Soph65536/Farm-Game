using Inventory;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(MultiMouseClickButton))]
public class InventoryItemButton : MonoBehaviour
{
    private InventoryMenuItem menuItem;

    private Image image;
    private TextMeshProUGUI text;

    public void SetupItem(InventoryMenuItem menuItemParam)
    {
        image = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();

        menuItem = menuItemParam;

        //set appearance
        image.sprite = menuItem.itemType.Sprite;
        text.text = menuItem.quantity.ToString();
    }

    //inventory functions
    public void Hold()
    {
        Player.Instance.inventory.SetHeldItem(menuItem);
        UIManager.Instance.ExitMenu();
    }

    public void Discard()
    {
        Player.Instance.inventory.RemoveItem(menuItem);
    }

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

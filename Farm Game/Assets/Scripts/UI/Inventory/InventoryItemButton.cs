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
    protected InventoryMenuItem menuItem;
    [SerializeField] protected GameObject inventoryDescriptorPrefab;
    private GameObject inventoryDescriptor;

    private Image image;
    private TextMeshProUGUI text;

    public void SetupItem(InventoryMenuItem menuItemParam)
    {
        inventoryDescriptor = null;

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
        if (Player.Instance.inventory.SetHeldItem(menuItem)) { UIManager.Instance.ExitMenu(); }
    }

    public void Eat()
    {
        if(menuItem.itemType.GetType() == typeof(Food))
        {
            Food foodItem = (Food)menuItem.itemType;
            StatManager.Instance.ChangeHunger(foodItem.HungerIncrease);
            Player.Instance.inventory.RemoveItem(menuItem);
        }
    }

    public void Discard()
    {
        Player.Instance.inventory.RemoveItem(menuItem);
    }

    public void StartHover()
    {
        if (inventoryDescriptor == null) 
        { 
            inventoryDescriptor = Instantiate(inventoryDescriptorPrefab, gameObject.transform.position, Quaternion.identity,gameObject.transform.parent.parent);
            inventoryDescriptor.GetComponent<InventoryDescriptor>().SetupItem(menuItem);
        }
    }

    public void StopHover()
    {
        Destroy(inventoryDescriptor);
        //inventoryDescriptor = null;
    }
}

using Inventory;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyValue;
    [SerializeField] private Slider hungerSlider;
    [SerializeField] private Image heldItemImage;
    [SerializeField] private TextMeshProUGUI heldItemQuantity;

    private void Awake()
    {
        UpdateMoneyValue();

        hungerSlider.maxValue = StatManager.Instance.maxHunger;
        UpdateHungerSlider();

        UpdateHeldItem(null);
    }

    public void UpdateMoneyValue()
    {
        moneyValue.text = StatManager.Instance.money.ToString();
    }

    public void UpdateHungerSlider()
    {
        hungerSlider.value = StatManager.Instance.hunger;
    }

    public void UpdateHeldItem(InventoryMenuItem item)
    {
        if(item != null)
        {
            heldItemImage.sprite = item.itemType.Sprite;
            heldItemQuantity.text = item.quantity.ToString();
        }

        //set to inactive if no item to show
        heldItemImage.enabled = item != null;
        heldItemQuantity.enabled = item != null;
    }
}

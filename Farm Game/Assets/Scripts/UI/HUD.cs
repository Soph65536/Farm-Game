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

    public void UpdateHeldItem(Sprite sprite)
    {
        heldItemImage.sprite = sprite;
        heldItemImage.enabled = sprite != null; //set to inactive if no sprite to show
    }
}

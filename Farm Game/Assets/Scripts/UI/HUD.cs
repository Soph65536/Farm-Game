using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyValue;
    [SerializeField] private Slider hungerSlider;

    private void Awake()
    {
        UpdateMoneyValue();

        hungerSlider.maxValue = StatManager.Instance.maxHunger;
        UpdateHungerSlider();
    }

    public void UpdateMoneyValue()
    {
        moneyValue.text = StatManager.Instance.money.ToString();
    }

    public void UpdateHungerSlider()
    {
        hungerSlider.value = StatManager.Instance.hunger;
    }
}

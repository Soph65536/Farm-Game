using Inventory;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryDescriptor : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI valueText;

    public void SetupItem(InventoryMenuItem menuItemParam)
    {
        nameText.text = menuItemParam.itemType.Name;
        valueText.text = "Value: " + menuItemParam.itemType.Value;
    }
}

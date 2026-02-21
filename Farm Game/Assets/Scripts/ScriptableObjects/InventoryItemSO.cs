using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/InventoryItem")]
[System.Serializable]
public class InventoryItem : ScriptableObject
{
    //inspector editable variables
    [SerializeField] private String itemName;
    [SerializeField] private Sprite icon;

    public string Name { get { return itemName; } }
    public Sprite Icon { get { return icon; } }
}

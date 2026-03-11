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
    [SerializeField] private Sprite sprite;
    [SerializeField] private int value;

    public string Name { get { return itemName; } }
    public Sprite Sprite { get { return sprite; } }
    public int Value { get { return value; } }
}

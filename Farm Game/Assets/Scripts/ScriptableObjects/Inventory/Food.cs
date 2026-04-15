using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/InventoryFood")]
[System.Serializable]
public class Food : InventoryItem
{
    [SerializeField] private int hungerIncrease;

    public int HungerIncrease { get { return hungerIncrease; } }
}

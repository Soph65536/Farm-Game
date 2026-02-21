using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/InventoryCrop")]
[System.Serializable]
public class Crop : InventoryItem
{
    [SerializeField] private GameObject prefab;

    public GameObject Prefab { get { return prefab; } }
}

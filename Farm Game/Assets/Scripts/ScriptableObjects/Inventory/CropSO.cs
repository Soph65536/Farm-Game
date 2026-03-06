using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/InventoryCrop")]
[System.Serializable]
public class Crop : InventoryItem
{
    [SerializeField] private float baseGrowthSpeed;
    [SerializeField] private GameObject prefab;
    [SerializeField] private InventoryItem harvestableItem;

    public float BaseGrowthSpeed { get { return baseGrowthSpeed; } }
    public GameObject Prefab { get { return prefab; } }
    public InventoryItem HarvestableItem { get { return harvestableItem; } }
}

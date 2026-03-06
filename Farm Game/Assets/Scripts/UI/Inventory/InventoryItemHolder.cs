using Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//should be added to the inventory item container
public class InventoryItemHolder : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab;

    public void UpdateItems(List<InventoryMenuItem> items)
    {
        ClearItems();

        foreach (InventoryMenuItem item in items)
        {
            GameObject newItem = Instantiate(itemPrefab, transform);

            newItem.GetComponent<InventoryItemButton>().SetupItem(item);
        }
    }

    private void ClearItems()
    {
        foreach (Transform child in transform) { Destroy(child.gameObject); } //remove all children within this
    }
}

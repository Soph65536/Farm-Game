using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] private GameObject parentObject;
    [SerializeField] private List<InventoryItem> itemsToPickup;

    public void SetPickupItem(List<InventoryItem> items)
    {
        itemsToPickup = new List<InventoryItem>();
        foreach (InventoryItem item in items)
        {
            itemsToPickup.Add(item);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            foreach (InventoryItem item in itemsToPickup)
            {
                Player.Instance.inventory.AddItem(item);
            }
            Destroy(parentObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] private GameObject parentObject;
    [SerializeField] private InventoryItem pickupItem;

    public void SetPickupItem(InventoryItem item)
    {
        pickupItem = item;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            Player.Instance.inventory.AddItem(pickupItem);
            Destroy(parentObject);
        }
    }
}

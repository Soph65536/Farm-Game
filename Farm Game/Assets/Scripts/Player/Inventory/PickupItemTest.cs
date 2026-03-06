using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItemTest : MonoBehaviour
{
    [SerializeField] private InventoryItem PickupItem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            Player.Instance.inventory.AddItem(PickupItem);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToInventory : MonoBehaviour
{
    [SerializeField] private InventoryItem[] itemsToAdd;
    [SerializeField] private int moneyToAdd;

    public void AddItemsToInventory()
    {
        foreach (InventoryItem item in itemsToAdd)
        {
            Player.Instance.inventory.AddItem(item);
        }
    }

    public void AddMoneyToInventory()
    {
        foreach (InventoryItem item in itemsToAdd)
        {
            StatManager.Instance.ChangeMoney(moneyToAdd);
        }
    }
}

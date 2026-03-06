using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class InventoryMenuItem
    {
        public InventoryItem itemType;
        public int quantity;

        public InventoryMenuItem(InventoryItem itemTypeParam) 
        { 
            itemType = itemTypeParam;
            quantity = 1;
        }
    }
}
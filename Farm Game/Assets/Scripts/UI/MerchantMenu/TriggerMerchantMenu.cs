using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMerchantMenu : MonoBehaviour
{
    [SerializeField] private MerchantInventory merchantInventory;

    private void OnTriggerEnter(Collider other)
    {
        merchantInventory.EnterMerchantMenu();
    }
}

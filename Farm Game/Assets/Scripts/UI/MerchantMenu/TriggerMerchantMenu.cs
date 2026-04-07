using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerMerchantMenu : Interactable
{
    [SerializeField] private MerchantInventory merchantInventory;

    protected override void Interact(InputAction.CallbackContext context)
    {
        if (interactable)
        {
            interactPromptUI.SetActive(false);
            merchantInventory.EnterMerchantMenu();
        }
    }
}

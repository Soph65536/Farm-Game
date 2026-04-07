using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerTeleport : Interactable
{
    [SerializeField] private GameObject teleportPosition;

    protected override void Interact(InputAction.CallbackContext context)
    {
        if (interactable)
        {
            interactPromptUI.SetActive(false);
            Player.Instance.transform.position = teleportPosition.transform.position;
            Player.Instance.transform.rotation = teleportPosition.transform.rotation;
        }
    }
}

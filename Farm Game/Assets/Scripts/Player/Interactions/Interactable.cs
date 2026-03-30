using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public abstract class Interactable : MonoBehaviour
{
    protected GameObject interactPromptUI;
    protected bool interactable;
    protected abstract void Interact(InputAction.CallbackContext context);

    protected void SetUIRefs()
    {
        interactPromptUI = Player.Instance.hud.GetComponent<HUD>().interactPrompt;
        Player.Instance.input.actions["UseItem"].performed += Interact;
    }

    private void Start()
    {
        interactable = false;
        Invoke(nameof(SetUIRefs), 0.5f);
    }


    private void OnEnable()
    {
        Player.Instance.input.actions["UseItem"].performed += Interact;
    }

    private void OnDisable()
    {
        Player.Instance.input.actions["UseItem"].performed -= Interact;
        SetInteractable(false);
    }


    protected void SetInteractable(bool value)
    {
        interactable = value;
        interactPromptUI.SetActive(interactable);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            SetInteractable(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            SetInteractable(false);
        }
    }
}

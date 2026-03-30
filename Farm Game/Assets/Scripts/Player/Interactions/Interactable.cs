using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            interactable = true;
            interactPromptUI.SetActive(interactable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            interactable = false;
            interactPromptUI.SetActive(interactable);
        }
    }
}

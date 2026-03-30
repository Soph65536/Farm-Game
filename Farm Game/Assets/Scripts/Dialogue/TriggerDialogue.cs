using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerDialogue : Interactable
{
    public Menu dialogueMenu;
    [SerializeField] private string conversationAsset;
    [SerializeField] private bool runOnAwake;
    [SerializeField] private bool destroyAfterRun;

    [Header("Changes Camera Angle?")]
    [SerializeField] private bool HasCameraChange;

    [Header("If Changes Camera Angle:\nNew gameobject for Camera Controller to move to")]
    [SerializeField] private GameObject NewCameraLocation;

    private void Start()
    {
        if (runOnAwake) { InvokeDialogue(0.5f); } //build wants to run this start function before dialogue handler is setup so must invoke this

        interactable = false;
        Invoke(nameof(SetUIRefs), 0.5f);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.GetComponent<Player>() != null && !runOnAwake) { RunDialogue(); }
    //}

    public void InvokeDialogue(float delay)
    {
        Invoke(nameof(RunDialogue), delay);
    }

    protected override void Interact(InputAction.CallbackContext context)
    {
        if (interactable && !runOnAwake) { 
            interactPromptUI.SetActive(false); 
            RunDialogue(); 
        }
    }

    private void RunDialogue()
    {
        dialogueMenu = UIManager.Instance.FindMenuByName("dialogue");
        dialogueMenu.GetComponentInChildren<DialogueHandler>(true).conversationAsset = conversationAsset;

        UIManager.Instance.EnterMenu(dialogueMenu);

        //if camerachange, change camera to new location
        if (HasCameraChange) { CameraController.Instance.FocusOnObject(NewCameraLocation); }

        if (destroyAfterRun) { Destroy(gameObject); }
    }
}
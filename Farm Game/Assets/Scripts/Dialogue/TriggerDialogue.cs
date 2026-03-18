using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public Menu dialogueMenu;
    [SerializeField] private string conversationAsset;
    [SerializeField] private bool runOnAwake;

    [Header("Changes Camera Angle?")]
    [SerializeField] private bool HasCameraChange;

    [Header("If Changes Camera Angle:\nNew gameobject for Camera Controller to move to")]
    [SerializeField] private GameObject NewCameraLocation;

    private void Start()
    {
        if (runOnAwake) { Invoke(nameof(RunDialogue), 0.5f); } //build wants to run this start function before dialogue handler is setup so must invoke this
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !runOnAwake) { RunDialogue(); }
    }

    public void RunDialogue()
    {
        dialogueMenu = UIManager.Instance.FindMenuByName("dialogue");
        dialogueMenu.GetComponentInChildren<DialogueHandler>(true).conversationAsset = conversationAsset;

        UIManager.Instance.EnterMenu(dialogueMenu);

        //if camerachange, change camera to new location
        if (HasCameraChange) { CameraController.Instance.FocusOnObject(NewCameraLocation); }

        Destroy(gameObject);
    }
}
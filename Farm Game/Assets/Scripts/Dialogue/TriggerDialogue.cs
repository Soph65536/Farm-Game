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
        if (runOnAwake) { RunDialogue(); }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !runOnAwake) { RunDialogue(); }
    }

    private void RunDialogue()
    {
        dialogueMenu = UIManager.Instance.FindMenuByName("dialogue");
        dialogueMenu.GetComponentInChildren<DialogueHandler>(true).conversationAsset = conversationAsset;

        UIManager.Instance.EnterMenu(dialogueMenu);

        //if camerachange, change camera to new location
        //if (HasCameraChange) { other.GetComponentInChildren<CameraController>().ChangeCameraFocus(NewCameraLocation); }

        Destroy(gameObject);
    }
}
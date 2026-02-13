using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public Menu dialogueMenu;
    [SerializeField] private string conversationAsset;

    [Header("Changes Camera Angle?")]
    public bool HasCameraChange;

    [Header("If Changes Camera Angle:\nNew gameobject for Camera Controller to move to")]
    public GameObject NewCameraLocation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //if first time opening then find through uimanager
            if (dialogueMenu == null) { dialogueMenu = UIManager.Instance.FindMenuByName("dialogue"); }

            dialogueMenu.GetComponentInChildren<DialogueHandler>().conversationAsset = conversationAsset;

            UIManager.Instance.EnterMenu(dialogueMenu);

            //if camerachange, change camera to new location
            //if (HasCameraChange) { other.GetComponentInChildren<CameraController>().ChangeCameraFocus(NewCameraLocation); }

            Destroy(gameObject);
        }
    }
}
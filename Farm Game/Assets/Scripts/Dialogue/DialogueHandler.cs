using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHandler : MonoBehaviour
{
    private DialogueTreeSaveData dialogueTreeData;

    public DialogueSaveData currentData = null;

    [SerializeField] private GameObject PlayerTextPrefab;
    [SerializeField] private GameObject PlayerTextContainer;
    public string conversationAsset;

    private void Awake()
    {
        if (currentData.dialogueItem == null)
        {
            CloseDialogue();
        }
    }

    private void OnEnable()
    {
        GetTreeData();
    }

    public void CloseDialogue()
    {
        ClearPlayerDialogueOptions();

        //close this menu
        UIManager.Instance.ExitMenu();
    }

    private void GetTreeData()
    {
        dialogueTreeData = Resources.Load(conversationAsset) as DialogueTreeSaveData; //loads the example conversation from resources

        //first foreach loop to find what the root dialogue is
        foreach (DialogueSaveData dialogueData in dialogueTreeData.dialogueData)
        {
            if (dialogueData.previousguids.Count == 0) { currentData = dialogueData; }
        }

        //update player options
        SetPlayerDialogueOptions();
    }

    public void GetNextDialogueData(DialogueSaveData playerOption)
    {
        //check for event in player option before next choice
        if(playerOption.dialogueItem.EventText != string.Empty)
        {
            EventManager.Instance.RunEvent(playerOption.dialogueItem.EventText);
        }

        //get new dialogue!!
        currentData = null; //set currentdata to empty
        foreach(Transform child in PlayerTextContainer.transform) { Destroy(child.gameObject); } //remove all children within player text

        foreach (DialogueSaveData dialogueData in dialogueTreeData.dialogueData)
        {
            if (dialogueData.previousguids.Contains(playerOption.guid) && !dialogueData.dialogueItem.IsPlayerTextOptionRO)
            {
                currentData = dialogueData;
            }
        }

        //close dialogue if no more data
        if(currentData == null) { CloseDialogue(); }

        //check for event in dialogue option
        else if (currentData.dialogueItem.EventText != string.Empty)
        {
            EventManager.Instance.RunEvent(currentData.dialogueItem.EventText);
        }

        //update player options
        SetPlayerDialogueOptions();
    }

    private void ClearPlayerDialogueOptions()
    {
        foreach (Transform child in PlayerTextContainer.transform) { Destroy(child.gameObject); } //remove all children within player text
    }

    private void SetPlayerDialogueOptions()
    {
        //if current item isnt null
        if (currentData != null)
        {
            //foreach loop to find which playeroptions are children of the current item
            foreach (DialogueSaveData dialogueData in dialogueTreeData.dialogueData)
            {
                if (dialogueData.previousguids.Contains(currentData.guid) && dialogueData.dialogueItem.IsPlayerTextOptionRO)
                {
                    GameObject playeroption = Instantiate(PlayerTextPrefab, PlayerTextContainer.transform);
                    playeroption.GetComponent<PlayerOptionDisplay>().PlayerOption = dialogueData;
                }
            }
        }
    }
}

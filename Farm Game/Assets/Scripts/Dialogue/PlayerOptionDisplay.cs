using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOptionDisplay : MonoBehaviour
{
    public DialogueSaveData PlayerOption;
    [SerializeField] private DialogueHandler dialogueHandler;

    [SerializeField] private TextMeshProUGUI PlayerSpeechTextNoImage;
    [SerializeField] private TextMeshProUGUI PlayerSpeechTextWImage;
    [SerializeField] private Image PlayerImage;

    private void Update()
    {
        dialogueHandler = GetComponentInParent<DialogueHandler>();

        PlayerSpeechTextNoImage.text = PlayerOption.dialogueItem.DialogueText;
        PlayerSpeechTextWImage.text = PlayerOption.dialogueItem.DialogueText;
        PlayerImage.sprite = PlayerOption.dialogueItem.IconRO;

        //enable/disable text and image based on if there is an image with this
        PlayerSpeechTextNoImage.enabled = PlayerImage.sprite == null;
        PlayerSpeechTextWImage.enabled = PlayerImage.sprite != null;
        PlayerImage.enabled = PlayerImage.sprite != null;
    }

    public void onPress()
    {
        dialogueHandler.GetNextDialogueData(PlayerOption);
    }
}

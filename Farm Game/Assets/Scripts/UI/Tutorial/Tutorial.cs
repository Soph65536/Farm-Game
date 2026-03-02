using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tutorialText;
    [SerializeField] private string[] tutorialDialogue;
    private int currentDialogueIndex;

    private void Awake()
    {
        SetText();
    }

    private void SetText()
    {
        if(currentDialogueIndex > tutorialDialogue.Length) { CloseTutorial(); }
        else
        {
            tutorialText.text = tutorialDialogue[currentDialogueIndex];
        }
    }

    public void ContinueTutorial()
    {
        currentDialogueIndex++;
        SetText();
    }

    public void CloseTutorial()
    {
        Destroy(gameObject);
    }
}

using Inventory;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SubmitQuestDisplay : MonoBehaviour
{
    private Color submitTextEnabledColour = new(120, 134, 43);
    private Color submitTextDisabledColour = new(91, 152, 96, 0.5f);
    private Color disabledColour = new(63, 167, 145, 0.5f);

    private Quest submittingQuest;
    private bool hasAllItems;

    [SerializeField] private TextMeshProUGUI questNameText;
    [SerializeField] private GameObject submittableItemsContainer;
    [SerializeField] private GameObject submittableItemButtonPrefab;
    [SerializeField] private GameObject notAllItemsCollected;
    [SerializeField] private GameObject submitButton;

    private void OnEnable()
    {
        submittingQuest = QuestManager.Instance.submittingQuest; //get local copy so code is cleaner
        if (submittingQuest == null) { UIManager.Instance.ExitMenu(); } //exit if no quest being submitted

        foreach (Transform child in submittableItemsContainer.transform) { Destroy(child.gameObject); }

        questNameText.text = submittingQuest.QuestName;
        hasAllItems = true; //start off as true, if find any item missing from inventory then set to false

        foreach (InventoryItem item in submittingQuest.ItemsToSubmit)
        {
            InventoryMenuItem menuItem = new(item);

            GameObject submittableItem = Instantiate(submittableItemButtonPrefab, submittableItemsContainer.transform);
            submittableItem.GetComponent<InventoryItemButton>().SetupItem(menuItem);

            if (Player.Instance.inventory.CheckForItem(item) == false)
            {
                hasAllItems = false;

                submittableItem.GetComponent<Image>().color = disabledColour;
            }
        }

        //set other ui elements based on if hasallitems
        submitButton.GetComponent<Image>().color = hasAllItems ? Color.white : disabledColour;
        submitButton.GetComponentInChildren<TextMeshProUGUI>().color = hasAllItems ? submitTextEnabledColour : submitTextDisabledColour;
        notAllItemsCollected.SetActive(!hasAllItems);
    }

    public void SubmitQuest()
    {
        if (hasAllItems)
        {
            QuestManager.Instance.CompleteQuest(submittingQuest);
            UIManager.Instance.ExitMenu();
            if (submittingQuest.CompletionEvent != string.Empty) { EventManager.Instance.RunEvent(submittingQuest.CompletionEvent); }
        }
        else
        {
            AudioManager.Instance.PlayAudio(false, Player.Instance.audioSource, "sebuzzer");
        }
    }
}

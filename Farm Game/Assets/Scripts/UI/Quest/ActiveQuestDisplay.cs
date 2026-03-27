using Inventory;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActiveQuestDisplay : MonoBehaviour
{
    [SerializeField] private GameObject questContainer;
    [SerializeField] private GameObject questViewerButtonPrefab;

    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI itemsToSubmitText;
    [SerializeField] private GameObject submittableItemsContainer;
    [SerializeField] private GameObject submittableItemButtonPrefab;

    private void OnEnable()
    {
        DisplayQuests();
        SetSelectedQuest(null);
    }

    private void DisplayQuests()
    {
        foreach(Transform child in questContainer.transform) { Destroy(child.gameObject); }

        foreach(Quest quest in QuestManager.Instance.activeQuests)
        {
            GameObject newButton = Instantiate(questViewerButtonPrefab, questContainer.transform);
            newButton.GetComponent<QuestViewerButton>().SetQuest(quest, this);
        }
    }

    public void SetSelectedQuest(Quest quest)
    {
        foreach (Transform child in submittableItemsContainer.transform) { Destroy(child.gameObject); }

        if (quest == null)
        {
            descriptionText.text = "Click on a quest to display it here.";
            itemsToSubmitText.enabled = false;
            return;
        }

        descriptionText.text = quest.QuestDescription;
        itemsToSubmitText.enabled = quest.ItemsToSubmit.Length != 0;

        foreach(InventoryItem item in quest.ItemsToSubmit)
        {
            InventoryMenuItem menuItem = new(item);

            GameObject submittableItem = Instantiate(submittableItemButtonPrefab, submittableItemsContainer.transform);
            submittableItem.GetComponent<InventoryItemButton>().SetupItem(menuItem);
        }
    }
}

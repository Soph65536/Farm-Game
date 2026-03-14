using Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> activeQuests;

    public static QuestManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null & Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        activeQuests = new List<Quest>();
    }

    public void ReceiveQuest(Quest quest)
    {
        activeQuests.Add(quest);
    }

    public void CompleteQuest(Quest quest)
    {
        activeQuests.Remove(quest);

        foreach(InventoryItem item in quest.ItemsToSubmit)
        {
            InventoryMenuItem menuItem = new(item);
            Player.Instance.inventory.RemoveItem(menuItem);
        }
    }
}

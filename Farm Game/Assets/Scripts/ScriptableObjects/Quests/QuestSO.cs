using Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Quest")]
[System.Serializable]
public class Quest : ScriptableObject
{
    [SerializeField] private string questName;
    [SerializeField] private string questDescription;
    [SerializeField] private InventoryItem[] itemsToSubmit;
    [SerializeField] private string completionEvent;

    public string QuestName { get { return questName; } }
    public string QuestDescription { get { return questDescription; } }
    public InventoryItem[] ItemsToSubmit { get { return itemsToSubmit; } }
    public string CompletionEvent { get { return completionEvent; } }
}

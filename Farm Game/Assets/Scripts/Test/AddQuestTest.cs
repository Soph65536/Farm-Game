using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddQuestTest : MonoBehaviour
{
    [SerializeField] private Quest questToAdd;

    private void Awake()
    {
        Invoke(nameof(AddQuest), 1);
    }

    private void AddQuest()
    {
        QuestManager.Instance.ReceiveQuest(questToAdd);
    }
}

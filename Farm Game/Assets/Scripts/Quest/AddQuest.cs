using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddQuest : MonoBehaviour
{
    [SerializeField] private Quest questToAdd;

    public void AddAQuest()
    {
        QuestManager.Instance.ReceiveQuest(questToAdd);
    }
}

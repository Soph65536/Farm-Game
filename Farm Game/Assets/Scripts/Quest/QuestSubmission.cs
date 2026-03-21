using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSubmission : MonoBehaviour
{
    [SerializeField] private Quest questToSubmit;

    public void InvokeQuestSubmit(float delay)
    {
        Invoke(nameof(OpenQuestSubmit), delay);
    }

    public void OpenQuestSubmit()
    {
        if (QuestManager.Instance.activeQuests.Contains(questToSubmit)) //if been given this quest then open submit menu
        {
            QuestManager.Instance.submittingQuest = questToSubmit;
            UIManager.Instance.EnterMenu("questsubmit");
        }
        else if (QuestManager.Instance.completedQuests.Contains(questToSubmit)) //if already done quest then destroy this
        {
            Destroy(gameObject);
        }
    }
}

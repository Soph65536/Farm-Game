using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestViewerButton : MonoBehaviour
{
    private Quest quest;
    private TextMeshProUGUI questText;

    private ActiveQuestDisplay activeQuestDisplay;

    private void Awake()
    {
        questText = GetComponent<TextMeshProUGUI>();
    }

    public void SetQuest(Quest questParam, ActiveQuestDisplay activeQuestDisplayParam)
    {
        quest = questParam;
        questText.text = questParam.QuestName.ToString();

        activeQuestDisplay = activeQuestDisplayParam;
    }

    public void SelectQuest()
    {
        activeQuestDisplay.SetSelectedQuest(quest);
    }
}

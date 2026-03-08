using Skills;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillLevelDisplay : MonoBehaviour
{
    [SerializeField] private Slider[] statSliders;

    private void Awake()
    {
        //set initial values

        foreach (var slider in statSliders) { slider.maxValue = StatManager.Instance.maxLevel; }

        UpdateSlider(SkillType.Farming, StatManager.Instance.farmingLevel);
        UpdateSlider(SkillType.Hunting, StatManager.Instance.huntingLevel);
        UpdateSlider(SkillType.Foraging, StatManager.Instance.foragingLevel);
    }

    public void UpdateSlider(SkillType skillType, int value)
    {
        statSliders[(int)skillType].value = value;
    }
}

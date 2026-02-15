using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    enum SkillType
    {
        Farming,
        Hunting,
        Foraging
    }

    int[] tempStats;

    private void Awake()
    {
        tempStats = new int[3];
    }

    public void IncreaseFarming()
    {
        tempStats[(int)SkillType.Farming]++;
    }

    public void IncreaseHunting()
    {
        tempStats[(int)SkillType.Hunting]++;
    }

    public void IncreaseForaging()
    {
        tempStats[(int)SkillType.Foraging]++;
    }

    public void DetermineStats()
    {
        switch (tempStats.Max())
        {

        }
    }
}

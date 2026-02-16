using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using Skills;

public class CharacterSelect : MonoBehaviour
{
    //i feel like theres a better way to make this script for the value comparisons but i cant think of how

    private int[] tempStats;
    private int[] tempLevels;

    [SerializeField] private int[] levelValues; //max to min

    private void Awake()
    {
        tempStats = new int[3];
        if(levelValues.Length != 3) { Array.Resize(ref levelValues, 3); }
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
        tempLevels = new int[3] { 9, 9, 9 }; //we will use the value 9 to later check which stat hasnt been set yet

        //set max value to contain highest level value
        tempLevels[Array.IndexOf(tempStats, tempStats.Max())] = levelValues[0];

        //set min value to contain lowest level value
        tempLevels[Array.IndexOf(tempStats, tempStats.Min())] = levelValues[2];

        //the leftover value in tempLevels that hasnt been set is the middle level value
        tempLevels[Array.IndexOf(tempLevels, 9)] = levelValues[1];

        StatManager.Instance.SetBaseStats(
            tempLevels[(int)SkillType.Farming],
            tempLevels[(int)SkillType.Hunting],
            tempLevels[(int)SkillType.Foraging]);
    }
}

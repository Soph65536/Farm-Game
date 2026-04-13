using Skills;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is a singleton that goes on the player HUD canvas
public class StatManager : MonoBehaviour
{
    //skills
    public int farmingLevel { get; private set; }
    public int huntingLevel { get; private set; }
    public int foragingLevel { get; private set; }
    private int farmingExp;
    private int huntingExp;
    private int foragingExp;

    public int money { get; private set; }
    [SerializeField] private int startingMoney = 20;
    public int hunger { get; private set; }
    public int maxHunger;

    public int maxLevel;
    [SerializeField] private int[] expToLevelUp; //each index is each level

    private SkillLevelDisplay skillLevelDisplay;
    private HUD hud;

    public static StatManager Instance { get; private set; }

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

        farmingExp = 0;
        huntingExp = 0;
        foragingExp = 0;

        money = startingMoney;
        hunger = maxHunger;

        if (maxLevel < 0) { maxLevel = 2; }
        if (expToLevelUp.Length != maxLevel) { Array.Resize(ref expToLevelUp, maxLevel); }
    }


    public void SetBaseStats(int farming, int hunting, int foraging)
    {
        //if stats have already been set then return
        if (farmingLevel != 0 && huntingLevel != 0 && foragingLevel != 0) { return; }

        farmingLevel = farming;
        huntingLevel = hunting;
        foragingLevel = foraging;
    }

    public void GainExp(int farming, int hunting, int foraging)
    {
        farmingExp += farming;
        huntingExp += hunting;
        foragingExp += foraging;

        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        if(farmingExp > expToLevelUp[farmingLevel])
        {
            farmingExp -= expToLevelUp[farmingLevel];
            LevelUp(SkillType.Farming);
        }

        if (huntingExp > expToLevelUp[huntingLevel])
        {
            huntingExp -= expToLevelUp[huntingLevel];
            LevelUp(SkillType.Hunting);
        }

        if (foragingExp > expToLevelUp[foragingLevel])
        {
            foragingExp -= expToLevelUp[foragingLevel];
            LevelUp(SkillType.Foraging);
        }
    }

    private void LevelUp(SkillType skillType)
    {
        //if havent alr found skillLevelDisplay then try find it
        if(skillLevelDisplay == null) { skillLevelDisplay = FindObjectOfType<SkillLevelDisplay>(true); }
        if (hud == null) { hud = Player.Instance.hud.GetComponent<HUD>(); }

        switch (skillType)
        {
            case SkillType.Farming:
                if (farmingLevel < maxLevel) 
                { 
                    farmingLevel++;
                    skillLevelDisplay.UpdateSlider(SkillType.Farming, farmingLevel);
                    if (hud != null) { hud.ShowLevelUp("Farming Level Up!", "Level " + farmingLevel.ToString()); }

                    //soil plot unlock
                    UnlockSoilPlot[] unlockables = GameObject.FindObjectsOfType<UnlockSoilPlot>();
                    foreach(UnlockSoilPlot unlock in unlockables)
                    {
                        if(unlock.levelToUnlock <= farmingLevel) { unlock.Unlock(); }
                    }
                }
                break;

            case SkillType.Hunting:
                if (huntingLevel < maxLevel) 
                { 
                    huntingLevel++;
                    skillLevelDisplay.UpdateSlider(SkillType.Hunting, huntingLevel);
                    if (hud != null) { hud.ShowLevelUp("Hunting Level Up!", "Level " + huntingLevel.ToString()); }
                }
                break;

            case SkillType.Foraging:
                if (foragingLevel < maxLevel) 
                { 
                    foragingLevel++;
                    skillLevelDisplay.UpdateSlider(SkillType.Foraging, foragingLevel);
                    if (hud != null) { hud.ShowLevelUp("Foraging Level Up!", "Level " + foragingLevel.ToString()); }
                }
                break;
        }
    }


    public void ChangeMoney(int amount) //set amount to negativ for money subtract
    {
        money += amount;

        if (hud == null) { hud = Player.Instance.hud.GetComponent<HUD>(); }
        hud.UpdateMoneyValue();
    }

    public void DecreaseHunger(int amount)
    {
        //decrease hunger then update hud
        hunger -= amount;

        if (hud == null) { hud = Player.Instance.hud.GetComponent<HUD>(); }
        hud.UpdateHungerSlider();
    }
}

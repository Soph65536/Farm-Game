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

    public int hunger { get; private set; }
    [SerializeField] private int maxHunger;

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

        hunger = maxHunger;
    }

    public void SetBaseStats(int farming, int hunting, int foraging)
    {
        //if stats have already been set then return
        if(farmingLevel != 0 && huntingLevel != 0 && foragingLevel != 0) { return; }

        farmingLevel = farming;
        huntingLevel = hunting;
        foragingLevel = foraging;
    }
}

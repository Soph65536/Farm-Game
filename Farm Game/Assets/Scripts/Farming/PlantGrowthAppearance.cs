using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowthAppearance : MonoBehaviour
{
    const int numOfStates = 4;
    [SerializeField] private MeshRenderer[] growthStates; //array length should be numofstates

    private void Awake()
    {
        if(growthStates.Length != numOfStates) { Array.Resize(ref growthStates, numOfStates); }
    }

    public void SetGrowthState(int state)
    {
        //set each model to active or inactive based on if the object is the current state
        foreach (MeshRenderer model in growthStates)
        {
            model.enabled = (model == growthStates[state]);
        }
    }
}

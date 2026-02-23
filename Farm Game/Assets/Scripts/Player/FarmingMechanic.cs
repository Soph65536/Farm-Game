using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmingMechanic : MonoBehaviour
{
    [SerializeField] private float maxPlantingDistance;

    public bool PlantSeed(Crop seed)
    {
        //if cant find empty plot within range then cant plant seed
        SoilPlot plantingPlot = FindNearestSoilPlot(true);
        if (plantingPlot == null) { return false; }

        plantingPlot.PlantSeed(seed);
        return true;
    }

    public SoilPlot FindNearestSoilPlot(bool empty)
    {
        return null;


        //check for soil plots within max planting distance

        //if empty is true and soil plot is occupied then skip over it
    }
}

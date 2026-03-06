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
        SoilPlot[] plotsInScene = FindObjectsByType<SoilPlot>(0);

        SoilPlot nearestSoilPlot = null;
        float nearestDistance = Mathf.Infinity;

        foreach (SoilPlot plot in plotsInScene)
        {
            if (empty && plot.currentCrop != null) { continue; } //if looking for empty plot and this is occupied then skip

            float plotDistance = Vector3.Distance(transform.position, plot.transform.position);
            if (plotDistance < nearestDistance)
            {
                nearestSoilPlot = plot;
                nearestDistance = plotDistance;
            }
        }

        if (nearestDistance > maxPlantingDistance) { return null; }
        return nearestSoilPlot;
    }
}

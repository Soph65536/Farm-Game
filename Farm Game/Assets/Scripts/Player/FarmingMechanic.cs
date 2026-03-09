using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FarmingMechanic : MonoBehaviour
{
    [SerializeField] private float maxPlantingDistance;

    private void OnEnable()
    {
        Player.Instance.input.actions["WaterCrop"].performed += WaterCrop;
        Player.Instance.input.actions["WeedCrop"].performed += WeedCrop;
        Player.Instance.input.actions["HarvestCrop"].performed += HarvestCrop;
    }

    private void OnDisable()
    {
        Player.Instance.input.actions["WaterCrop"].performed -= WaterCrop;
        Player.Instance.input.actions["WeedCrop"].performed -= WeedCrop;
        Player.Instance.input.actions["HarvestCrop"].performed -= HarvestCrop;
    }

    private void WaterCrop(InputAction.CallbackContext context)
    {
        SoilPlot plantingPlot = FindNearestSoilPlot(false);
        if (plantingPlot != null) 
        {
            plantingPlot.WaterCrop();
            //play watering animation
        }
    }

    private void WeedCrop(InputAction.CallbackContext context)
    {
        SoilPlot plantingPlot = FindNearestSoilPlot(false);
        if (plantingPlot != null) 
        {
            if (plantingPlot.hasWeeds)
            {
                plantingPlot.RemoveWeeds();
                //play weeding animation
            }
        }
    }

    private void HarvestCrop(InputAction.CallbackContext context)
    {
        SoilPlot plantingPlot = FindNearestSoilPlot(false);
        if(plantingPlot != null) { plantingPlot.RemoveCrop(); } //harvestable check is done in removecrop so dont need condition here
    }

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

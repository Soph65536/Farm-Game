using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilPlot : MonoBehaviour
{
    const float wetMultiplier = 1.2f;
    const float weedMultiplier = 0.7f;

    public Crop currentCrop { get; private set; }

    private GameObject cropObject;
    private PlantGrowthAppearance cropObjectAppearance;

    private float currentGrowth; //0 to 1 value

    public bool readyToHarvest;
    public bool isWet;
    public bool hasWeeds;

    private void Awake()
    {
        currentCrop = null;
        currentGrowth = 0;

        readyToHarvest = false;
        isWet = false;
        hasWeeds = false;
    }

    private float CalculateGrowthRate() //per minute
    {
        return currentCrop.BaseGrowthSpeed 
            * (isWet ? wetMultiplier : 1) 
            * (hasWeeds ? weedMultiplier : 1);
    }

    private void GrowPlant()
    {
        currentGrowth += CalculateGrowthRate();

        //calculate model growth stage from currentgrowth
        cropObjectAppearance.SetGrowthState(Mathf.Clamp((int)(currentGrowth * 3), 0, 3)); //clamp stops number from going outside array bounds (incase ive messed up the math)

        //stop running this function if the plant has grown
        if(currentGrowth >= 1) 
        {
            cropObjectAppearance.SetGrowthState(3); //set to final growth state
            readyToHarvest = true;
            CancelInvoke(); 
        }
    }


    public void RemoveCrop()
    {
        if (readyToHarvest)
        {
            Destroy(cropObject);
            Player.Instance.inventory.AddItem(currentCrop.HarvestableItem);

            currentCrop = null;
            currentGrowth = 0;
        }
    }

    public void PlantSeed(Crop seed)
    {
        currentCrop = seed;

        cropObject = Instantiate(currentCrop.Prefab, transform);
        cropObjectAppearance = cropObject.GetComponent<PlantGrowthAppearance>();
        cropObjectAppearance.SetGrowthState(0);

        //run plant growth every minute
        InvokeRepeating(nameof(GrowPlant), 60, 60);
    }
}

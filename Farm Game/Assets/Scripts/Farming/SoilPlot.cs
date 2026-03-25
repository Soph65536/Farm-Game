using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilPlot : MonoBehaviour
{
    const float plantGrowthUpdateFrequency = 3;

    const float wetMultiplier = 1.2f;
    const float weedMultiplier = 0.7f;

    const float chanceOfWeeds = 7; //1/chanceOfWeeds-1 chance
    const float wetDuration = 20; //time in second that crops stay wet for

    public Crop currentCrop { get; private set; }

    private GameObject cropObject;
    private PlantGrowthAppearance cropObjectAppearance;

    private float currentGrowth; //0 to 1 value

    private bool readyToHarvest;
    public bool isWet;
    public bool hasWeeds;

    private WeedGenerator weedGenerator;

    [SerializeField] private MeshRenderer soilMesh;
    [SerializeField] private Material drySoilMaterial;
    [SerializeField] private Material wetSoilMaterial;

    private void Start()
    {
        Invoke(nameof(SetRefs), 0.5f);
    }

    private void SetRefs()
    {
        currentCrop = null;
        currentGrowth = 0;

        readyToHarvest = false;
        isWet = false;
        hasWeeds = false;

        weedGenerator = GetComponentInChildren<WeedGenerator>();

        soilMesh.material = drySoilMaterial;
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

        //random small chance of weeds appearing
        if ((int)Random.Range(1, chanceOfWeeds) == 1)
        { 
            weedGenerator.SpawnWeed();
            hasWeeds = true;
        }

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

            //animate player harvesting crop
        }
    }

    public void PlantSeed(Crop seed)
    {
        currentCrop = seed;

        cropObject = Instantiate(currentCrop.Prefab, transform);
        cropObjectAppearance = cropObject.GetComponent<PlantGrowthAppearance>();
        cropObjectAppearance.SetGrowthState(0);

        //run plant growth every minute
        InvokeRepeating(nameof(GrowPlant), plantGrowthUpdateFrequency, plantGrowthUpdateFrequency);
    }

    public void WaterCrop()
    {
        StopCoroutine(nameof(WateringTimer)); //if doing watering timer then stop it because its reset

        isWet = true;
        soilMesh.material = wetSoilMaterial;

        StartCoroutine(nameof(WateringTimer));
    }

    private IEnumerator WateringTimer()
    {
        yield return new WaitForSecondsRealtime(wetDuration);
        
        isWet = false;
        soilMesh.material = drySoilMaterial;
    }

    public void RemoveWeeds()
    {
        weedGenerator.ClearWeeds();
        hasWeeds = false;
    }
}

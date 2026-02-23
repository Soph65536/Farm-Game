using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilPlot : MonoBehaviour
{
    public Crop currentCrop { get; private set; }

    public void PlantSeed(Crop seed)
    {
        currentCrop = seed;
    }
}

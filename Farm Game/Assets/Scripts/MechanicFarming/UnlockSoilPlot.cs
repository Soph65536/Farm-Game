using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockSoilPlot : MonoBehaviour
{
    [SerializeField] public int levelToUnlock;
    [SerializeField] private GameObject[] soilPlots;

    private void Awake()
    {
        if (StatManager.Instance.farmingLevel > levelToUnlock) { Unlock(); }
        else
        {
            foreach (GameObject plot in soilPlots)
            {
                plot.SetActive(false);
            }
        }
    }

    public void Unlock()
    {
        foreach (GameObject plot in soilPlots)
        {
            plot.SetActive(true);
        }
        Destroy(gameObject);
    }
}

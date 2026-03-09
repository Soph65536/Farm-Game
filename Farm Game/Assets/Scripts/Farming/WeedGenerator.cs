using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedGenerator : MonoBehaviour
{
    private List<GameObject> potentialWeeds;

    private void Awake()
    {
        potentialWeeds = new List<GameObject>();

        foreach(Transform child in transform)
        {
            potentialWeeds.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }
    }

    public void SpawnWeed()
    {
        //sets random object in list to active
        potentialWeeds[Random.Range(0, potentialWeeds.Count)].SetActive(true);
    }

    public void ClearWeeds()
    {
        foreach (GameObject obj in potentialWeeds) { obj.SetActive(false); }
    }
}

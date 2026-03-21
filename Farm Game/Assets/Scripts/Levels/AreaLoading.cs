using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaLoading : MonoBehaviour
{
    [SerializeField] private bool startAsActive;
    [SerializeField] private GameObject AreaObject;

    private void Awake()
    {
        AreaObject.SetActive(startAsActive);
    }

    private void OnTriggerEnter(Collider other)
    {
        AreaObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        AreaObject.SetActive(false);
    }
}

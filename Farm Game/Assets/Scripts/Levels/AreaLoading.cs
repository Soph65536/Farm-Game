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
        if (other.GetComponent<Player>() != null) { AreaObject.SetActive(true); }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>() != null) { AreaObject.SetActive(false); }
    }
}

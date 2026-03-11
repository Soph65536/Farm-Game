using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        EventManager.Instance.RunEvent("merchantmenugay");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainExpTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            StatManager.Instance.GainExp(10, 9, 8);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCredits : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null) { LevelLoading.Instance.EnterCredits(); }
    }
}

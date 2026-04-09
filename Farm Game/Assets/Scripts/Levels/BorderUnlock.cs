using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderUnlock : MonoBehaviour
{
    [SerializeField] private string borderUnlockEvent;
    [SerializeField] private int amountNeededForUnlock;
    private int unlockAmount;

    private void Awake()
    {
        unlockAmount = 0;
    }

    public void IncreaseUnlockAmount()
    {
        unlockAmount++;
        if (unlockAmount >= amountNeededForUnlock)
        {
            EventManager.Instance.RunEvent(borderUnlockEvent);
        }
    }
}

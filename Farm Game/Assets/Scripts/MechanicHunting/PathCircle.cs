using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCircle : Path
{
    private void OnEnable()
    {
        InvokeRepeating(nameof(MovePath), movementFrequency, movementFrequency);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    protected override void MovePath()
    {
        transform.Rotate(Vector3.up * moveSpeed);
    }
}

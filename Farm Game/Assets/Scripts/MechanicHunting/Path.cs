using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Path : MonoBehaviour
{ 
    protected const float movementFrequency = 0.01f;
    [SerializeField] protected float moveSpeed;
    abstract protected void MovePath();
}

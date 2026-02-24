using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Values")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpHeight;

    private float moveSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if(walkSpeed == 0 || runSpeed == 0 || jumpHeight == 0) { Debug.Log("Player movement values not set. Plase change in inspector."); }
        moveSpeed = walkSpeed;
    }

    
}

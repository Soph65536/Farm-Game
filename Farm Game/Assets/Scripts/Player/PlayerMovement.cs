using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    private void OnEnable()
    {
        Player.Instance.input.actions["Look"].performed += Look;
        Player.Instance.input.actions["Movement"].performed += Movement;
        Player.Instance.input.actions["Sprint"].performed += Sprint;
        Player.Instance.input.actions["Sprint"].canceled += Sprint;
        Player.Instance.input.actions["Jump"].performed += Jump;
    }

    private void OnDisable()
    {
        Player.Instance.input.actions["Look"].performed -= Look;
        Player.Instance.input.actions["Movement"].performed -= Movement;
        Player.Instance.input.actions["Sprint"].performed -= Sprint;
        Player.Instance.input.actions["Sprint"].canceled -= Sprint;
        Player.Instance.input.actions["Jump"].performed -= Jump;
    }

    private void Look(InputAction.CallbackContext context)
    {
        Vector2 look = context.ReadValue<Vector2>();

        //player.instance.camera move with look values
    }

    private void Movement(InputAction.CallbackContext context)
    {
        Vector2 movement = context.ReadValue<Vector2>();

        //rb move with movement values
    }

    private void Sprint(InputAction.CallbackContext context)
    {
        moveSpeed = context.performed ? runSpeed : walkSpeed;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        //get rb to jump
    }
}

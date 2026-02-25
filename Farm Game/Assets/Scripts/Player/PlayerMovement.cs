using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    const float baseGravity = 9.81f;

    private Rigidbody rb;

    [Header("Values")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravityScale;
    [SerializeField] private GameObject groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private float moveSpeed;
    private Vector2 movement;
    private bool grounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (walkSpeed == 0 || runSpeed == 0 || jumpHeight == 0) { Debug.Log("Player movement values not set. Plase change in inspector."); }
        moveSpeed = walkSpeed;
        movement = Vector2.zero;
        grounded = false;
    }

    private void OnEnable()
    {
        Player.Instance.input.actions["Look"].performed += Look;
        Player.Instance.input.actions["Movement"].performed += Movement;
        Player.Instance.input.actions["Movement"].canceled += Movement;
        Player.Instance.input.actions["Run"].performed += Sprint;
        Player.Instance.input.actions["Run"].canceled += Sprint;
        Player.Instance.input.actions["Jump"].performed += Jump;
    }

    private void OnDisable()
    {
        Player.Instance.input.actions["Look"].performed -= Look;
        Player.Instance.input.actions["Movement"].performed -= Movement;
        Player.Instance.input.actions["Movement"].canceled += Movement;
        Player.Instance.input.actions["Run"].performed -= Sprint;
        Player.Instance.input.actions["Run"].canceled -= Sprint;
        Player.Instance.input.actions["Jump"].performed -= Jump;
    }

    private void FixedUpdate()
    {
        //move based on input
        rb.velocity = new Vector3(movement.x * moveSpeed * Time.deltaTime, 0, movement.y * moveSpeed * Time.deltaTime);

        grounded = Gravity();
    }

    private bool Gravity()
    {
        //if found any ground within the ground check area then we are grounded
        if(Physics.OverlapBox(groundCheck.transform.position, groundCheck.transform.localScale / 2, Quaternion.identity, groundLayer).Length > 0)
        {
            return true;
        }
        else
        {
            //add gravity because we are falling
            rb.AddForce(Vector3.down * baseGravity * gravityScale * Time.deltaTime, ForceMode.Acceleration);
            return false;
        }
    }

    private void Look(InputAction.CallbackContext context)
    {
        Vector2 look = context.ReadValue<Vector2>();

        //player.instance.camera move with look values
    }

    private void Movement(InputAction.CallbackContext context)
    {
        //if pressing movement keys get input, else set movement to 0
        if (context.performed)
        {
            movement = context.ReadValue<Vector2>();
            transform.rotation = Quaternion.LookRotation(new Vector3(movement.x, 0, movement.y));
        }
        else
        {
            movement = Vector2.zero;
        }
    }

    private void Sprint(InputAction.CallbackContext context)
    {
        moveSpeed = context.performed ? runSpeed : walkSpeed;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (grounded)
        {
            rb.AddForce(Vector3.up * jumpHeight * Time.deltaTime, ForceMode.Impulse);
        }
    }
}

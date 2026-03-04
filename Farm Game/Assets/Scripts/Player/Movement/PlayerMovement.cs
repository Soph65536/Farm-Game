using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    const float baseGravity = 9.81f;

    private Rigidbody rb;
    private GameObject cameraHolder;

    [Header("Values")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private GameObject groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private float moveSpeed;
    private Vector2 movement;
    private Vector3 movementVelocity;
    [HideInInspector] public Vector3 rotation;
    private bool grounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (walkSpeed == 0 || runSpeed == 0 || jumpHeight == 0) { Debug.Log("Player movement values not set. Plase change in inspector."); }

        //set inital values for vars
        moveSpeed = walkSpeed;
        movement = Vector2.zero;
        movementVelocity = Vector3.zero;
        rotation = Vector3.zero;
        grounded = false;
    }

    private void OnEnable()
    {
        Player.Instance.input.actions["Movement"].performed += Movement;
        Player.Instance.input.actions["Movement"].canceled += Movement;
        Player.Instance.input.actions["Run"].performed += Sprint;
        Player.Instance.input.actions["Run"].canceled += Sprint;
        Player.Instance.input.actions["Jump"].performed += Jump;
    }

    private void OnDisable()
    {
        Player.Instance.input.actions["Movement"].performed -= Movement;
        Player.Instance.input.actions["Movement"].canceled += Movement;
        Player.Instance.input.actions["Run"].performed -= Sprint;
        Player.Instance.input.actions["Run"].canceled -= Sprint;
        Player.Instance.input.actions["Jump"].performed -= Jump;
    }

    private void FixedUpdate()
    {
        //rotation
        transform.localEulerAngles = rotation;
        
        //set movement velocity based on input
        movementVelocity = (transform.forward * movement.y + transform.right * movement.x) * moveSpeed * Time.deltaTime;
        rb.velocity = new Vector3 (movementVelocity.x, rb.velocity.y, movementVelocity.z);

        Gravity();
    }

    private void Gravity()
    {
        grounded = Physics.OverlapBox(groundCheck.transform.position, groundCheck.transform.localScale / 2, Quaternion.identity, groundLayer).Length > 0;

        Player.Instance.animator.SetBool("Air", !grounded);
    }

    private void Movement(InputAction.CallbackContext context)
    {
        //if pressing movement keys get input, else set movement to 0
        if (context.performed)
        {
            movement = context.ReadValue<Vector2>();
            float movementAngle = 180 / Mathf.PI * Mathf.Atan2(movement.y, -movement.x) - 90;
            Player.Instance.model.transform.localEulerAngles = new Vector3(0, movementAngle, 0);
        }
        else
        {
            movement = Vector2.zero;
            Player.Instance.model.transform.localEulerAngles = Vector3.zero;
        }

        Player.Instance.animator.SetBool("Moving", context.performed);
    }

    private void Sprint(InputAction.CallbackContext context)
    {
        moveSpeed = context.performed ? runSpeed : walkSpeed;

        Player.Instance.animator.SetBool("Sprinting", context.performed);
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (grounded)
        {
            rb.AddForce(Vector3.up * jumpHeight * Time.deltaTime, ForceMode.VelocityChange);

            Player.Instance.animator.SetTrigger("StartJump");
        }
    }
}

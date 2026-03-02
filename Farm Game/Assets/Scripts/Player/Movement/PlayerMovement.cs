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
    [HideInInspector] public Vector3 rotation;
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
        Player.Instance.model.transform.localEulerAngles = new Vector3(movement.x, 0, movement.y); //this needs fixing so it does the thing where it gets y rotation from the x and z its on deity windblast
        //move based on input
        rb.velocity = (transform.forward * movement.y + transform.right * movement.x) * moveSpeed * Time.deltaTime;

        Gravity();
    }

    private void Gravity()
    {
        grounded = Physics.OverlapBox(groundCheck.transform.position, groundCheck.transform.localScale / 2, Quaternion.identity, groundLayer).Length > 0;
    }

    private void Movement(InputAction.CallbackContext context)
    {
        //if pressing movement keys get input, else set movement to 0
        if (context.performed)
        {
            movement = context.ReadValue<Vector2>();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerInventory))]
[RequireComponent(typeof(FarmingMechanic))]
[RequireComponent(typeof(FarmTeleport))]
[RequireComponent(typeof(HuntingMechanic))]
[RequireComponent(typeof(ForagingMechanic))]
public class Player : MonoBehaviour
{
    public PlayerInput input;

    public PlayerMovement movement;
    public PlayerInventory inventory;

    public FarmingMechanic farming;
    public HuntingMechanic hunting;
    public ForagingMechanic foraging;

    public Animator animator;
    //set these manually
    public GameObject model;
    public GameObject hud;

    //make sure there is only 1 player object and it exists throughout all scenes
    public static Player Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null & Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        input = GetComponent<PlayerInput>();

        movement = GetComponent<PlayerMovement>();
        inventory = GetComponent<PlayerInventory>();
        farming = GetComponent<FarmingMechanic>();
        hunting = GetComponent<HuntingMechanic>();
        foraging = GetComponent<ForagingMechanic>();

        animator = GetComponentInChildren<Animator>();
    }

    public void EnableInput()
    {
        //reenable all input actions
        foreach (InputAction action in input.actions)
        {
            action.Enable();
        }
    }

    public void DisableInput()
    {
        foreach (InputAction action in input.actions)
        {
            //if action name doesnt contain menu then its an action and should be disabled
            if (!(action.name.Contains("Menu")))
            {
                action.Disable();
            }
        }
    }
}

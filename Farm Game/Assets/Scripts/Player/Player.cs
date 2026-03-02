using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerInventory))]
[RequireComponent(typeof(FarmingMechanic))]
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
    public GameObject model; //set manually

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
}

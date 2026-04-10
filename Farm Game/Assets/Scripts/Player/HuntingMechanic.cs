using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HuntingMechanic : MonoBehaviour
{
    [SerializeField] private GameObject aimDecal;
    [SerializeField] private GameObject arrowPrefab;

    private void Start()
    {
        aimDecal.SetActive(false);

        Player.Instance.input.actions["ShootBow"].performed += AimBow;
        Player.Instance.input.actions["ShootBow"].canceled += ShootBow;
    }

    private void OnDisable()
    {
        Player.Instance.input.actions["ShootBow"].performed -= AimBow;
        Player.Instance.input.actions["ShootBow"].canceled -= ShootBow;
    }

    private void AimBow(InputAction.CallbackContext context)
    {
        aimDecal.SetActive(true);
    }

    private void ShootBow(InputAction.CallbackContext context)
    {
        aimDecal.SetActive(false);

        Instantiate(arrowPrefab, transform.position + transform.up + transform.forward, transform.rotation);
    }
}

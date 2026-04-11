using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HuntingMechanic : MonoBehaviour
{
    [SerializeField] private float cooldownTime;
    [SerializeField] private GameObject aimDecal;
    [SerializeField] private GameObject arrowPrefab;

    private bool inCooldown;

    private void Start()
    {
        aimDecal.SetActive(false);
        inCooldown = false;

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
        if (inCooldown) { return; }
        aimDecal.SetActive(true);
    }

    private void ShootBow(InputAction.CallbackContext context)
    {
        if (inCooldown || !aimDecal.activeSelf) { return; } //can only run if aimed before shooting
        aimDecal.SetActive(false);
        Instantiate(arrowPrefab, transform.position + transform.up + transform.forward, transform.rotation);

        StartCoroutine(nameof(EnterCooldown));
    }

    private IEnumerator EnterCooldown()
    {
        inCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        inCooldown = false;
    }
}

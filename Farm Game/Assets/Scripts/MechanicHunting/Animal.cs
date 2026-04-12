using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Animal : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int health;

    [SerializeField] private InventoryItem[] potentialDeathLoot;
    [SerializeField] private float deathAnimationTime;
    [SerializeField] private GameObject deathLootPrefab;

    private Animator animator;

    private void Awake()
    {
        health = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void GetHit()
    {
        health--;
        if(health <= 0) { Die(); }
    }

    private void Die()
    {
        GameObject pickupItem = Instantiate(deathLootPrefab, transform.position, transform.rotation);
        pickupItem.GetComponentInChildren<PickupItem>().SetPickupItem(potentialDeathLoot[Random.Range(0, potentialDeathLoot.Length-1)]);

        animator.SetTrigger("Die");
        Destroy(gameObject, deathAnimationTime);
    }
}

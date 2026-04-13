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
        //generate loot
        InventoryItem[] loot = new InventoryItem[StatManager.Instance.huntingLevel];
        for (int i = 0; i < loot.Length - 1; i++) { loot[i] = potentialDeathLoot[Random.Range(0, potentialDeathLoot.Length - 1)]; }

        //create pickup object and set values
        GameObject pickupItem = Instantiate(deathLootPrefab, transform.position, transform.rotation);
        pickupItem.GetComponentInChildren<PickupItem>().SetPickupItem(loot);

        animator.SetTrigger("Die");
        Destroy(gameObject, deathAnimationTime);
    }
}

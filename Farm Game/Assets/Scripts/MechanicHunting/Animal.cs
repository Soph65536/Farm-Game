using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Animal : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int health;

    [SerializeField] private float deathAnimationTime;
    [SerializeField] private GameObject deathLoot;

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
        Instantiate(deathLoot, transform.position, transform.rotation);

        animator.SetTrigger("Die");
        Destroy(gameObject, deathAnimationTime);
    }
}

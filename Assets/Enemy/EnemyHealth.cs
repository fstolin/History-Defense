using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    [SerializeField] float armor = 0f;

    int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    // Damages a unit by an amount specified in damage
    public void DamageUnit(int damage)
    {
        this.currentHealth -= Mathf.RoundToInt((1 - armor) * damage);
        CheckHealth();
    }

    // Checks whether the enemy is dead
    private void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    // Particle event fires DamageUnit() Method
    private void OnParticleCollision(GameObject other)
    {
        int damageDone = other.GetComponentInParent<NewTargetLocator>().GetDamageDone();
        DamageUnit(damageDone);
    }
}

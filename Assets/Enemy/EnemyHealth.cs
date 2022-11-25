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
    public void damageUnit(int damage)
    {
        this.currentHealth -= Mathf.RoundToInt((1 - armor) * damage);
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

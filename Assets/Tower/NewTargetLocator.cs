using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTargetLocator : MonoBehaviour
{
    [SerializeField] int damageDone = 1;
    [SerializeField] float towerRange = 15f;
    [SerializeField] ParticleSystem weapons;

    Transform target;
    Transform weaponSystem;


    public int GetDamageDone()
    {
        return damageDone;
    }

    private void Start()
    {
        weaponSystem = this.transform.Find("BallistaTopMesh");
    }

    private void Update()
    {
        FindClosestTarget();
        
        // Check that gameObejct is active, not null, and in the towers range.
        if (target.gameObject.activeInHierarchy
            && target != null 
            && IsTargetInDistance(target))
        {
            AimWeapon();
            ShootTheWeapon();
        } else
        {
            StopShooting();
        }
            
    }

    private void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        // The distance to the current target
        float currentDistance = 0f;

        foreach (Enemy enemy in enemies)
        {
            // Only look for active enemies
            if (!enemy.gameObject.activeInHierarchy) continue;
            
            float distance = Vector3.Distance(this.transform.position, enemy.transform.position);

            if (distance < currentDistance || currentDistance == 0)
            {
                target = enemy.transform;
                currentDistance = distance;
            }
        }
    }

    private bool IsTargetInDistance(Transform target)
    {
        float distance = Vector3.Distance(target.transform.position, this.transform.position);
        if (distance > towerRange)
        {
            return false;
        } else
        {
            return true;
        }
    }

    private void AimWeapon()
    {
        weaponSystem.transform.LookAt(target);
    }

    private void ShootTheWeapon()
    {
        Debug.Log("Fire");
        var em = weapons.emission;
        em.enabled = true;
        if (!weapons.isEmitting) weapons.Play();
    }

    private void StopShooting()
    {
        Debug.Log("Stop");
        var em = weapons.emission;
        em.enabled = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTargetLocator : MonoBehaviour
{
    [SerializeField] int damageDone = 1;

    Transform target;
    Transform weapon;

    public int GetDamageDone()
    {
        return damageDone;
    }

    private void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
        weapon = this.transform.Find("BallistaTopMesh");
    }

    private void Update()
    {
        AimWeapon();
        ShootTheWeapon();
    }

    private void AimWeapon()
    {
        weapon.transform.LookAt(target);
    }

    private void ShootTheWeapon()
    {
        
    }

}

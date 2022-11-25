using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] GameObject ammo;

    Transform target;
    Transform weapon;

    private void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
        weapon = this.transform.Find("BallistaTopMesh");
    }

    private void Update()
    {
        AimWeapon();
        ShootWeapon();
    }

    private void AimWeapon()
    {
        weapon.transform.LookAt(target);
    }

    private void ShootWeapon()
    {

    }
}

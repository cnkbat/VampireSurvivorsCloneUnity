using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAreaPickerController : WeaponController
{
    
     protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();

        GameObject SpawnedWeapon = Instantiate(WeaponSO.WeaponPrefab);

        SpawnedWeapon.transform.position = transform.position;
    }
}

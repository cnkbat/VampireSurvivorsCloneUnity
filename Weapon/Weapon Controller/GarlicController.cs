using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }
    protected override void Attack()
    {
        base.Attack();

        GameObject SpawnedGarlic = Instantiate(WeaponSO.WeaponPrefab);

        SpawnedGarlic.transform.position = transform.position; // Position Setting

    }
}

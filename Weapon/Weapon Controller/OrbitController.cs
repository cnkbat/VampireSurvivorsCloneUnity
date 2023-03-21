using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitController : WeaponController
{
    OrbitBehaviour OrbitBehaviour;
    public Vector3 ProjectileSpawnOffSet;
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
         
    }

    protected override void Attack()
    {
        base.Attack();

        GameObject SpawnedWeapon = Instantiate(WeaponSO.WeaponPrefab);

        SpawnedWeapon.transform.position = transform.position + ProjectileSpawnOffSet;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearestWeaponController : WeaponController
{
    NearestWeaponBehaviour NearestWeaponBehaviour;
    [SerializeField] Vector3 ProjectileSpawnOffSet;
    GameObject NearestEnemy;
    protected override void Start()
    {
        base.Start();

        NearestEnemy = NearestWeaponBehaviour.GetNearestEnemy(); // object ref erroru var neden bilmiyorum
    }


    protected override void Update()
    {
        base.Update();
        
    }
    protected override void Attack()
    {
        base.Attack();

        GameObject SpawnedWeapon = Instantiate(WeaponSO.WeaponPrefab);

        SpawnedWeapon.transform.position = transform.position;

        Vector3 SpawnPointMultiplier = (transform.position - NearestEnemy.transform.position).normalized;

        SpawnedWeapon.transform.position = transform.position + Vector3.Scale(ProjectileSpawnOffSet , SpawnPointMultiplier) ; 
    }

   
}

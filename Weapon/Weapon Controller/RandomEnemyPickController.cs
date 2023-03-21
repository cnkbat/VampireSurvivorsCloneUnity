using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemyPickController : WeaponController
{
    [SerializeField] Vector3 ProjectileSpawnOffSet;

    RandomEnemyPickBehaviour RandomEnemyPickBehaviour;
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

        SpawnedWeapon.transform.position = transform.position;

        Vector3 SpawnPointMultiplier = (transform.position - RandomEnemyPickBehaviour.GetRandomEnemy().transform.position).normalized;

        SpawnedWeapon.transform.position = transform.position + Vector3.Scale(ProjectileSpawnOffSet , SpawnPointMultiplier) ; 
    }    
}

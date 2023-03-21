using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemyPickBehaviour : ProjectileWeaponBehaviour
{
    GameObject[] AllEnemies;

    GameObject RandEnemy;

    Vector3 TargetLocation;
    protected override void Start()
    {
        base.Start();
        FindRandomEnemy();

        TargetLocation = RandEnemy.transform.position;
    }

    void Update() 
    {
        transform.position = Vector2.MoveTowards(transform.position, 
        TargetLocation, 
        CurrentWeaponSOProjectileSpeed * base.CurrentCharSOProjectileSpeed * Time.deltaTime);    
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }

    public GameObject GetRandomEnemy()
    {
        return RandEnemy;
    }

    void FindRandomEnemy()
    {
        AllEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        int RandEnemyIndex = Random.Range(0,AllEnemies.Length);

        RandEnemy =  AllEnemies[RandEnemyIndex];
    }    
}

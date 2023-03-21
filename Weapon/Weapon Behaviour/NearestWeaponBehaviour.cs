using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearestWeaponBehaviour : ProjectileWeaponBehaviour
{
    GameObject[] AllEnemies;
    GameObject NearestEnemy = null;
    float Distance;
    float NearestEnemyDistance = 1000; // random greater number
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        FindNearestEnemy();
    }

    // Update is called once per frame
    void Update()
    {   
        if(!NearestEnemy)
        {
            FindNearestEnemy();
        }
        
        transform.position = Vector2.MoveTowards(transform.position , 
        NearestEnemy.transform.position, CurrentWeaponSOProjectileSpeed * base.CurrentCharSOProjectileSpeed
        *  Time.deltaTime);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }

    public GameObject GetNearestEnemy()
    {
        return NearestEnemy;
    }

    void FindNearestEnemy()
    {
        AllEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < AllEnemies.Length; i++)
        {
            Distance = Vector3.Distance(transform.position,AllEnemies[i].transform.position);
            
            if(Distance < NearestEnemyDistance)
            {
                NearestEnemy = AllEnemies[i];

                NearestEnemyDistance = Distance;
            }
        }
    }
}
